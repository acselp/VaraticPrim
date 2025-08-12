import { Calendar, Home, Inbox, Search, Settings } from "lucide-vue-next"
import type {SidebarAction} from "@/components/shared/app-sidebar/types.ts";

export const appSidebarItems: SidebarAction[] =
[
    {
        title: "Home",
        icon: Home,
        click: () => { console.log("Home clicked"); },
    },
    {
        title: "Inbox",
        icon: Inbox,
        click: () => { console.log("Inbox clicked"); },
    },
    {
        title: "Calendar",
        icon: Calendar,
        click: () => { console.log("Calendar clicked"); },
    },
    {
        title: "Search",
        icon: Search,
        click: () => { console.log("Search clicked"); },
    },
    {
        title: "Settings",
        icon: Settings,
        click: () => { console.log("Settings clicked"); },
    },
];