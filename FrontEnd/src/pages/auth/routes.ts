import Login from "@/pages/auth/Login.vue";
import {RouterPaths} from "@/router/routerPaths.ts";
import type {RouteRecordRaw} from "vue-router";
export const authRoutes: RouteRecordRaw[] = [
    {
        path: RouterPaths.Login,
        component: Login
    }
]