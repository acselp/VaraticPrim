namespace VaraticPrim.Infrastructure.Options;

public class DbConnectionStringOptions
{
    public string SectionName { get; set; } = "ConnectionStrings";
    
    public string PostgresConnection { get; set; } = string.Empty;
}