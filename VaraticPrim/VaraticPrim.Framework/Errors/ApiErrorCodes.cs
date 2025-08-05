namespace VaraticPrim.Framework.Errors;

public static class ApiErrorCodes
{
    public const string Forbidden           = "forbidden";
    public const string InternalServerError = "internal_server_error";

    public static class Register
    {
        public const string UserAlreadyExists = "user_already_exists";
    }
}