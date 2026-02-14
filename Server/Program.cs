// See https://aka.ms/new-console-template for more information

using Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddHostedService<Worker>();

var app = builder.Build();

await app.RunAsync();