// See https://aka.ms/new-console-template for more information

using Infrastructure.ExceptionHandling;
using Server;
using Server.Infrastructure.ExectionHandling.Localization;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IErrorLocalizer, ErrorLocalizer>();

builder.Services.AddApplicationServices();
builder.Services.AddHostedService<Worker>();

var app = builder.Build();

await app.RunAsync();