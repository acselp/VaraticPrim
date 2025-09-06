import Dashboard from "@/pages/admin/dashboard/Dashboard.vue";
import CustomerGrid from "@/pages/admin/customer/list/CustomerGrid.vue";
import {RouterPaths} from "@/router/routerPaths.ts";
import type {RouteRecordRaw} from "vue-router";

export const adminRoutes: RouteRecordRaw[] = [
    {
        path: RouterPaths.Dashboard,
        component: Dashboard
    },
    {
        path: RouterPaths.CustomerGrid,
        component: CustomerGrid
    },
    {
        path: RouterPaths.CustomerEdit,
        component: CustomerGrid
    }
]