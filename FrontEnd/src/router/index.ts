import {createRouter, createWebHistory, type RouteRecordRaw} from 'vue-router'
import {pagesRoutes} from "@/pages/routes.ts";

const routes: RouteRecordRaw[] = [
    ...pagesRoutes
]

export const router = createRouter({
    history: createWebHistory(),
    routes
})