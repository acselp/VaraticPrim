namespace VaraticPrim.Infrastructure.Options;

public class DbConnectionStringOptions
{
    public string SectionName { get; set; } = "DbConnectionStrings";
    
    public string PostgresConnection { get; set; } = string.Empty;
}