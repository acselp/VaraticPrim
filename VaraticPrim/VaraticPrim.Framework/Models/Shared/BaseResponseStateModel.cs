namespace VaraticPrim.Framework.Models.Shared;

public class BaseResponseModel
{
    public List<string> Errors  { get; set; }
    public bool         Success { get; set; } = true;

    public void AddError(string message)
    {
        Errors.Add(message);
        Success = false;
    }
}