namespace VaraticPrim.Framework.Errors;

public static class ApiErrorCodes
{
    public const string Forbidden           = "forbidden";
    public const string InternalServerError = "internal_server_error";
    public const string ValidationError     = "validation_error";

    public static class Register
    {
        public const string UserAlreadyExists = "user_already_exists";
    }

    public static class Login
    {
        public const string WrongPasswordOrEmail             = "wrong_password_or_email";
        public const string InvalidRefreshTokenOrAccessToken = "invalid_refresh_token_or_access_token";
    }
}