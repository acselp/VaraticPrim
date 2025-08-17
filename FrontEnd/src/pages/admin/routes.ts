import Dashboard from "@/pages/admin/dashboard/Dashboard.vue";
import Customer from "@/pages/admin/customer/Customer.vue";
import {RouterPaths} from "@/router/routerPaths.ts";
import type {RouteRecordRaw} from "vue-router";

export const adminRoutes: RouteRecordRaw[] = [
    {
        path: RouterPaths.Dashboard,
        component: Dashboard
    },
    {
        path: RouterPaths.Customer,
        component: Customer
    }
]