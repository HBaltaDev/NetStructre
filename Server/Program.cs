// See https://aka.ms/new-console-template for more information

using Infrastructure.ExceptionHandling;
using Server;
using Server.Infrastructure.ExectionHandling.Localization;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddHostedService<Worker>();
        
builder.Services.AddSingleton<IErrorLocalizer, ErrorLocalizer>();

var app = builder.Build();

ServiceException.Configure(app.Services.GetRequiredService<IErrorLocalizer>());

await app.RunAsync();