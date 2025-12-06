using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VaraticPrim.Infrastructure.Persistence.Migrations;

namespace VaraticPrim.Infrastructure.HostedServices;

public class MigrationHostedService : IHostedService
{
    private readonly ILogger<MigrationHostedService> _logger;
    private readonly IMigrationRunner                _runner;

    public MigrationHostedService(IMigrationRunner runner, ILogger<MigrationHostedService> logger)
    {
        _runner = runner;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _runner.Migrate();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("StopAsync lifecycle...");

        return Task.CompletedTask;
    }
}