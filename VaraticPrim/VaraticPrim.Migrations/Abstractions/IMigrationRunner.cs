namespace VaraticPrim.Migrations.Scripts.Abstractions;

public interface IMigrationRunner
{
    /// <summary> Apply all pending migrations. </summary>
    void Migrate();
}