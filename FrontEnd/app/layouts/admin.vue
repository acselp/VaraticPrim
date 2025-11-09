<template>
  <SidebarProvider>
    <AdminSidebar />
    <main>
      <SidebarTrigger />
      <slot />
    </main>
  </SidebarProvider>
</template>
