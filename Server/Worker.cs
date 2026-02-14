using System.Reflection;
using Microsoft.Extensions.Hosting;
using Server.Infrastructure.ExectionHandling.Localization;

namespace Server;

public class Worker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IErrorLocalizer _errorLocalizer;

    public Worker(IServiceProvider serviceProvider, IErrorLocalizer errorLocalizer)
    {
        _serviceProvider = serviceProvider;
        _errorLocalizer = errorLocalizer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        new HttpListener(_serviceProvider, _errorLocalizer).Start();
    }
}