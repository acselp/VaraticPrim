
export interface SidebarGroup {
  title: string,
  items: SidebarItem[]
}

export interface SidebarItem {
  icon: never,
  name: string,
  path: string,
  subItems: SidebarSubItem[],
}

export interface SidebarSubItem {
  name: string,
  path: string,
  pro?: boolean,
}
