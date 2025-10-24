import type { RouteRecordRaw } from "vue-router";
import { RouterPaths } from "@/router/routerPaths.ts";
import Dashboard from "@/pages/admin/dashboard/Dashboard.vue";
import CustomerGrid from "@/pages/admin/customer/list/CustomerGrid.vue";

export const customerRoutes: RouteRecordRaw[] = [
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
