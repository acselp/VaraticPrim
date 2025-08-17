import {defineStore} from "pinia";

export const useAuthStore = defineStore("authStore", {
    state: () => {
        return {
            loggedIn: false,
            accessToken: null,
            user: null,
        }
    },
    getters: {
        isLoggedIn: state => state.loggedIn
    },
    actions: {
        login(token: string) {
            this.loggedIn = true;
            this.accessToken = token;
        },
        logout() {
            this.loggedIn = false;
            this.accessToken = null;
        }
    }
});