<template>
  <header
      class="flex px-4 h-16 shrink-0 items-center w-full gap-2 transition-[width,height] ease-linear group-has-[[data-collapsible=icon]]/sidebar-wrapper:h-12">
    <div class="flex items-center gap-2 pr-4">
      <SidebarTrigger class="-ml-1"/>
      <button @click="onLogout" :class="cn(buttonVariants({ variant: 'ghost' }), 'absolute right-0')">
        Logout
      </button>
    </div>
  </header>
</template>
<script setup lang="ts">
import {SidebarTrigger} from "@/components/ui/sidebar";
import {cn} from "@/lib/utils.ts";
import {buttonVariants} from "@/components/ui/button";
import {useAuthStore} from "@/stores/authStore.ts";

const authStore = useAuthStore();

const onLogout = () => {
  authStore.logout();
}
</script>