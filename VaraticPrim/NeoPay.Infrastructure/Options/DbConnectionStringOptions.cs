namespace NeoPay.Infrastructure.Options;

public class DbConnectionStringOptions
{
    public static string SectionName { get; set; } = "ConnectionStrings";
    
    public string PostgresConnection { get; set; } = string.Empty;
}