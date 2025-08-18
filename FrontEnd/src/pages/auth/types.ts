export interface LoginModel {
    Email: string;
    Password: string;
}

export interface LoginResponseModel {
    AccessToken: string;
    ExpiresIn: Date;
    RefreshToken: string;
    RefreshTokenExpirationTime: Date;
    TokenType: string;
}