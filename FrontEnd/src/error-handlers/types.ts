export interface ApiErrorModel {
    Code: string;
    Message: string;
    Errors: ApiError[];
}

export interface ApiError {
    /**
     * The name of the property.
     */
    PropertyName: string;

    /**
     * The error message.
     */
    ErrorMessage: string;

    /**
     * The property value that caused the failure.
     */
    AttemptedValue: any;

    /**
     * Gets or sets the error code.
     */
    ErrorCode: string;
}