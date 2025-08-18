<template>
  <SidebarProvider>
    <AppSidebar/>
    <main class="w-full">
      <AdminHeader/>
      <slot/>
    </main>
  </SidebarProvider>
</template>
<script setup lang="ts">
import AppSidebar from "@/components/shared/app-sidebar/AppSidebar.vue";
import {SidebarProvider} from "@/components/ui/sidebar";
import AdminHeader from "@/layouts/Admin/AdminHeader.vue";
</script>