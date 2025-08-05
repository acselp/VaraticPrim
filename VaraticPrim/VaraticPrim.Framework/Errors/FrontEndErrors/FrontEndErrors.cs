namespace VaraticPrim.Framework.Errors.FrontEndErrors;

public static class FrontEndErrors
{
    public static Error UserAlreadyExists { get; } = new()
                                                     {
                                                         ErrorCode    = ApiErrorCodes.Register.UserAlreadyExists,
                                                         ErrorMessage = "User already exists"
                                                     };

    public static Error ValidationError { get; } = new()
                                                   {
                                                       ErrorCode    = ApiErrorCodes.ValidationError,
                                                       ErrorMessage = "Could not validate the model"
                                                   };
}