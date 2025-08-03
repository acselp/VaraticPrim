namespace VaraticPrim.Framework.Models.Shared;

public class ResponseModel<T> : BaseResponseModel
{
    public T Data { get; set; }
}