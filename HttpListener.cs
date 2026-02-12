using System.Reflection;
using System.Text.Json;
using NetStructre.Applications.UserManagement.Abstract;
using NetStructre.Infrastructure.DtoBase.ResponseBase;
using NetStructre.Infrastructure.ExectionHandling;
using NetStructre.UserManagement.Dto.Request;

namespace NetStructre;

public class HttpListener
{
    private readonly Dictionary<string, MethodInfo> _actions;
    private readonly Dictionary<string, Type> _parameterTypes;
    private readonly IServiceProvider _serviceProvider;
    private readonly Type _type;
    
    public HttpListener(IServiceProvider serviceProvider)
    {
        _actions = new Dictionary<string, MethodInfo>();
        _parameterTypes = new Dictionary<string, Type>();
        
        _serviceProvider = serviceProvider;
        
        using var scope = _serviceProvider.CreateScope();
        
        var methods = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IApplicationService).IsAssignableFrom(t) && t.IsInterface)
            .SelectMany(t => t.GetMethods())
            .Where(m => m.ReturnType == typeof(Task<ResponseBase>));

        
        // Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        
        foreach (var method in methods)
        {
            _actions.Add(method.Name, method);
            _parameterTypes.Add(method.Name, method.GetParameters().FirstOrDefault()?.ParameterType);
        }
    }

    public void Start()
    {
        Console.WriteLine("Starting HttpListener");
        
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", configurePolicy => {
                configurePolicy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        var webApp = builder.Build();
 
        webApp.UseCors("AllowAllOrigins");

        webApp.MapMethods("/", new[] { "GET", "PUT", "DELETE", "PATCH" }, () => "Template Project API sadece HTTP POST üzerinden gelen taleplere cevap vermektedir");

        webApp.MapPost("/", HttpRequestReceived);

        webApp.Run();
    }
    
    private async Task HttpRequestReceived(HttpContext context)
    {
        try
        {
            // if (!await CheckHttpHeaders(context))
            // {
            //     return; 
            // } 
            //
            // var result = await pendingRequest.Task;
            //
            // context.Response.Headers.Append("Content-Type", "application/json");
            // context.Response.StatusCode = result.StatusCode;
            // await context.Response.WriteAsync(result.Response);

            var actionName = "test";
            var response = "";
            if (context.Request.Headers["Action"].Count != 0)
            {
                actionName = context.Request.Headers["Action"];
            }
        
            //var request = JsonSerializer.Deserialize<SignInRequest>(context.Request.Body);
        
            if (_actions.TryGetValue(actionName!, out var actionMethod) && _parameterTypes.TryGetValue(actionName!, out var paramType))
            {
                var dtoRequest = paramType.Name != "RequestBase" ? await JsonSerializer.DeserializeAsync(context.Request.Body, paramType) : null;
            
                var serviceType = actionMethod.DeclaringType!;

                var service = _serviceProvider.GetRequiredService(serviceType);

                var responseObj = await (Task<ResponseBase>)actionMethod.Invoke(service, [dtoRequest])!;
                
                response = JsonSerializer.Serialize(responseObj, responseObj.GetType());
            }

            context.Response.Headers.Append("Content-Type", "application/json");
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(response);
        }
        catch (ServiceException exception)
        {
            context.Response.Headers.Append("Content-Type", "application/json");
            context.Response.StatusCode = (int)exception.StatusCode;
            await context.Response.WriteAsync(exception.Description);
        }
        catch (Exception exception)
        {
            context.Response.Headers.Append("Content-Type", "application/json");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(exception.ToString());
        }

    }
}