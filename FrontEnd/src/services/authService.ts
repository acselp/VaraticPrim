import type {LoginModel, LoginResponseModel} from "@/pages/auth/types.ts";
import {apiClient} from "@/api-client/apiClient.ts";
import type {AxiosPromise} from "axios";

const loginEndpoint = "/auth/login";

export const AuthService = {
    login: (model: LoginModel): AxiosPromise<LoginResponseModel> => {
        return apiClient.post(loginEndpoint, model)
    }
}