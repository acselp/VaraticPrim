namespace VaraticPrim.Framework.Errors.FrontEndErrors;

public static class FrontEndErrors
{
    public static Error UserAlreadyExists { get; } = new Error()
    {
        ErrorCode    = ApiErrorCodes.Register.UserAlreadyExists,
        ErrorMessage = "User already exists"
    };
}