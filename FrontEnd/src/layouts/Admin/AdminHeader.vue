<template>
  <header
      class="bg-sidebar justify-between flex px-4 h-16 shrink-0 items-center w-full gap-2 transition-[width,height] ease-linear group-has-[[data-collapsible=icon]]/sidebar-wrapper:h-12">
    <div class="flex justify-between items-center gap-2 pr-4 w-full">
      <SidebarTrigger class="-ml-1"/>
      <div class="flex">
        <button @click="toggleTheme" :class="cn(buttonVariants({ variant: 'ghost' }))">
          <Sun v-if="theme === AppThemes.Dark"/>
          <Moon v-else/>
        </button>
        <button @click="onLogout" :class="cn(buttonVariants({ variant: 'ghost' }))">
          Logout
        </button>
      </div>
    </div>
  </header>
</template>
<script setup lang="ts">
import {SidebarTrigger} from "@/components/ui/sidebar";
import {cn} from "@/lib/utils.ts";
import {buttonVariants} from "@/components/ui/button";
import {useAuthStore} from "@/stores/authStore.ts";
import {AppThemes, useTheme} from "@/composables/useTheme.ts";
import {Sun, Moon} from 'lucide-vue-next';

const authStore = useAuthStore();
const {theme, toggleTheme} = useTheme();

const onLogout = () => {
  authStore.logout();
}

</script>