import { User, List } from "lucide-vue-next"
import type {Router} from "vue-router";
import {RouterPaths} from "@/router/routerPaths.ts";

export const getAppSidebarItems = (router: Router) => {
    return [
        {
            title: "Customer",
            icon: User,
            click: () => router.push(RouterPaths.Customer),
        },
        {
            title: "Dashboard",
            icon: List,
            click: () => router.push(RouterPaths.Dashboard),
        }
    ];
}