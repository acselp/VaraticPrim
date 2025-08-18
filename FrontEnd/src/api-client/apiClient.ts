import axios from "axios";
import {ValidationErrorHandler} from "@/error-handlers/validationErrorHandler.ts";

const baseUrl = "http://localhost:8081";

export const apiClient = axios.create({
    baseURL: baseUrl
})

apiClient.interceptors.request.use((config) => {
    return config;
}, (error) => {
    return Promise.reject(error);
})

apiClient.interceptors.response.use((response) => {
    console.log(response);
    return response;
}, (error) => {
    ValidationErrorHandler().handleError(error);

    return Promise.reject(error);
})