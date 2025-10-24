namespace VaraticPrim.Framework.GridModels;

public class GridCommand
{
    public int                              PageSize  { get; set; }
    public int                              PageIndex { get; set; }
    public List<Dictionary<string, string>> Filters   { get; set; } = new();
}