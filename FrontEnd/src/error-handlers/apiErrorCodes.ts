export const ApiErrorCodes = {
    Forbidden: "forbidden",
    InternalServerError: "internal_server_error",
    ValidationError: "validation_error",

    Register: {
        UserAlreadyExists: "user_already_exists",
    },

    Login: {
        WrongPasswordOrEmail: "wrong_password_or_email",
        InvalidRefreshTokenOrAccessToken: "invalid_refresh_token_or_access_token",
    },

    Customer: {
        CustomerAlreadyExists: "customer_already_exists",
    },
} as const;