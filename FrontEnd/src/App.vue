<template>
  <sidebar-provider>
    <app-sidebar />
    <main>
      <sidebar-trigger />
      Content
    </main>
  </sidebar-provider>
</template>

<script lang="ts" setup>

import {SidebarProvider, SidebarTrigger} from "@/components/ui/sidebar";
import AppSidebar from "@/components/shared/app-sidebar/AppSidebar.vue";
</script>