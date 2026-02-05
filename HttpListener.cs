using System.Reflection;

namespace NetStructre;

public class HttpListener
{
    private readonly Dictionary<string, MethodInfo> _actions;
    private Dictionary<string, Type> _parameterTypes;
    private readonly IServiceProvider _serviceProvider;
    private readonly Type _type;
    
    public HttpListener(IServiceProvider serviceProvider)
    {
        _actions = new Dictionary<string, MethodInfo>();
        _parameterTypes = new Dictionary<string, Type>();
        
        _serviceProvider = serviceProvider;
        
        using var scope = _serviceProvider.CreateScope();
        
        var methods = typeof(ApplicationStorage).GetMethods().Where(m => m.ReturnType == typeof(Task<ResponseBase>));
        
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
        
        context.Response.Headers.Append("Content-Type", "application/json");
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("Successful");
    }
}