import {defineStore} from "pinia";
import {computed, ref} from "vue";
import type {LoginModel, LoginResponseModel} from "@/pages/auth/types.ts";
import {useRouter} from "vue-router";
import {RouterPaths} from "@/router/routerPaths.ts";

export const useAuthStore = defineStore("authStore", () => {
    const isLoggedIn = ref<boolean>(false);
    const accessToken = ref<string>(null);
    const validUntil = ref<Date>(null);
    const isTokenValid = computed(() => new Date(validUntil.value).getTime() - new Date().getTime() > 0);

    const router = useRouter();

    const login = (model: LoginResponseModel) => {
        isLoggedIn.value = true;
        accessToken.value = `${model.TokenType} ${model.AccessToken}`;
        validUntil.value = model.ExpiresIn;
    }

    const logout = () => {
        isLoggedIn.value = false;
        accessToken.value = null;
        validUntil.value = null;
        router.push(RouterPaths.Login);
    }

    return {
        isLoggedIn,
        accessToken,
        isTokenValid,
        login,
        logout
    }
});