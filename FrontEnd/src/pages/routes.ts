import {authRoutes} from "@/pages/auth/routes.ts";
import {adminRoutes} from "@/pages/admin/routes.ts";
import WebLayout from "@/layouts/WebLayout.vue";
import AdminLayout from "@/layouts/Admin/AdminLayout.vue";
import type {RouteRecordRaw} from "vue-router";

export const pagesRoutes: RouteRecordRaw[] = [
    {
        path: "/",
        component: WebLayout,
        children: [
            ...authRoutes
        ]
    },
    {
        path: "/admin",
        component: AdminLayout,
        children: [
            ...adminRoutes
        ]
    }
]