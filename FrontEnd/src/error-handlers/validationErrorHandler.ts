import type {AxiosError} from "axios";
import type {ApiErrorModel} from "@/error-handlers/types.ts";
import {ApiErrorCodes} from "@/error-handlers/apiErrorCodes.ts";
import {toast} from "vue-sonner";
import {markRaw} from "vue";

export const ValidationErrorHandler = () => {
    const handleError = (errorResponse: AxiosError) => {
        if (errorResponse.status === 400) {
            const errorData: ApiErrorModel = errorResponse.response.data as ApiErrorModel;
            switch (errorData.Code) {
                case ApiErrorCodes.Login.WrongPasswordOrEmail:
                    handleWrongPasswordOrEmail(errorData)
                    break;

                case ApiErrorCodes.ValidationError:
                    handleValidationError(errorData)
                    break;

                default:
                    handleSomethingWentWrong()
            }
        }
    }

    const handleWrongPasswordOrEmail = (errorData: ApiErrorModel) => {
        toast.warning(errorData.Message)
    }

    const handleValidationError = (errorData: ApiErrorModel) => {
        toast.warning(`${errorData.Message}\n${errorData.Errors.map(x => x.ErrorMessage).join('\n')}`, {class: "whitespace-pre-line"});
    }

    const handleSomethingWentWrong = () => {
        toast.warning("Something went wrong")
    }

    return {
        handleError
    }
}