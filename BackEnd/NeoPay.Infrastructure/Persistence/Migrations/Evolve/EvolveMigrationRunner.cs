using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using NeoPay.Infrastructure.Options;

namespace NeoPay.Infrastructure.Persistence.Migrations.Evolve;

public class EvolveMigrationRunner : IMigrationRunner
{
    private readonly EvolveDb.Evolve _evolve;

    public EvolveMigrationRunner(ILogger<EvolveMigrationRunner>      logger,
                                 IOptions<DbConnectionStringOptions> options)
    {
        var cnx = new NpgsqlConnection(options.Value.PostgresConnection);

        var schema = "public";
        var dbName = "postgres";
        _evolve = new EvolveDb.Evolve(cnx, message => { logger.Log(LogLevel.Information, message); })
        {
            IsEraseDisabled            = true,
            EmbeddedResourceAssemblies = [typeof(EvolveMigrationRunner).Assembly],
            EmbeddedResourceFilters    = ["NeoPay.Infrastructure.Persistence.Migrations.Evolve.Scripts"]
        };

        _evolve.Placeholders = new Dictionary<string, string>
        {
            ["${database}"] = dbName,
            ["${schema}"]   = schema
        };
    }

    public void Migrate()
    {
        try
        {
            _evolve.Migrate();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to run migration", ex);
        }
    }
}