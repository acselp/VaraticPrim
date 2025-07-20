using Npgsql;
using VaraticPrim.Migrations.Scripts.Abstractions;

namespace VaraticPrim.Migrations.Evolve;

public class EvolveMigrationRunner : IMigrationRunner
{
    private readonly EvolveDb.Evolve _evolve;
    
    public EvolveMigrationRunner(string connectionString)
    {
        var cnx = new NpgsqlConnection(connectionString);
        var locations = new []
        {
            "../VaraticPrim.Migrations/Scripts"
        };
        
        _evolve = new EvolveDb.Evolve(cnx)
        {
            Locations = locations,
            IsEraseDisabled = true,
            MetadataTableSchema = "public",
        };

        _evolve.Placeholders = new Dictionary<string, string>
        {
            ["${database}"] = "postgres",
            ["${schema}"] = "public",
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
            throw new Exception($"Failed to run migration", ex);
        }
    }
}