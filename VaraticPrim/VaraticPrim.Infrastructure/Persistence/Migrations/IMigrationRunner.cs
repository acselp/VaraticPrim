namespace VaraticPrim.Infrastructure.Persistence.Migrations;

public interface IMigrationRunner
{
    /// <summary> Apply all pending migrations. </summary>
    void Migrate();
}