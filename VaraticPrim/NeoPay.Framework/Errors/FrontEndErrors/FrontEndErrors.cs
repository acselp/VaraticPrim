namespace NeoPay.Framework.Errors.FrontEndErrors;

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

    public static Error CustomerAccountNrAlreadyExists { get; } = new()
    {
        ErrorCode    = ApiErrorCodes.Customer.CustomerAlreadyExists,
        ErrorMessage = "Customer account number already exists"
    };
    
    public static Error CustomerCouldNotBeFound { get; } = new()
    {
        ErrorCode    = ApiErrorCodes.Customer.CustomerCouldNotBeFound,
        ErrorMessage = "Customer could not be found"
    };

    public static Error WrongPasswordOrEmailError { get; } = new()
    {
        ErrorCode    = ApiErrorCodes.Login.WrongPasswordOrEmail,
        ErrorMessage = "Wrong password or email"
    };

    public static Error InvalidRefreshTokenOrAccessTokenError { get; } = new()
    {
        ErrorCode    = ApiErrorCodes.Login.InvalidRefreshTokenOrAccessToken,
        ErrorMessage = "Invalid refresh token or access token"
    };
}