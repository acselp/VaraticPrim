<template>
  <Sidebar>
    <SidebarHeader> Hello </SidebarHeader>
    <SidebarContent> Hello </SidebarContent>
    <SidebarFooter />
  </Sidebar>
  <Sidebar side="left" variant="sidebar" collapsible="offcanvas">
    <SidebarHeader>
      <div className="px-4 py-2 text-lg font-bold">MyApp</div>
    </SidebarHeader>

    <SidebarContent>
      <SidebarGroup>
        <SidebarGroupLabel>Main</SidebarGroupLabel>
        <SidebarMenu>
          <SidebarMenuItem>
            <SidebarMenuButton asChild href="/dashboard">
              <a className="flex items-center gap-2">
                <HomeIcon /> <span>Dashboard</span>
              </a>
            </SidebarMenuButton>
          </SidebarMenuItem>

          <SidebarMenuItem>
            <SidebarMenuButton asChild href="/users">
              <a className="flex items-center gap-2">
                <UsersIcon /> <span>Users</span>
              </a>
            </SidebarMenuButton>
          </SidebarMenuItem>
        </SidebarMenu>
      </SidebarGroup>

      <SidebarGroup>
        <SidebarGroupLabel>Settings</SidebarGroupLabel>
        <SidebarMenu>
          <SidebarMenuItem>
            <SidebarMenuButton asChild href="/settings">
              <a className="flex items-center gap-2">
                <SettingsIcon /> <span>Settings</span>
              </a>
            </SidebarMenuButton>
          </SidebarMenuItem>
        </SidebarMenu>
      </SidebarGroup>
    </SidebarContent>

    <SidebarFooter>
      <div className="px-4 py-2 text-sm">© 2025 MyApp</div>
    </SidebarFooter>
  </Sidebar>
</template>

<script lang="ts" setup></script>
