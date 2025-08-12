import type {Component} from "vue";

export interface SidebarAction {
    title: string,
    icon: Component,
    click: Function,
}