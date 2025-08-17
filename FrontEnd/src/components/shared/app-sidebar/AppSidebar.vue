<template>
  <sidebar>
    <sidebar-header>
      <SidebarMenuButton
          size="lg"
          class="data-[state=open]:bg-sidebar-accent data-[state=open]:text-sidebar-accent-foreground"
      >
        <div class="flex flex-col gap-0.5 leading-none">
          <span class="font-semibold">Varatic Prim</span>
        </div>
      </SidebarMenuButton>
    </sidebar-header>
    <sidebar-content>
      <sidebar-group>
        <sidebar-group-content>
          <sidebar-menu>
            <sidebar-menu-item v-for="item in appSidebarItems" :key="item.title">
              <sidebar-menu-button asChild @click="item.click">
                <a>
                  <component :is="item.icon" />
                  <span>{{item.title}}</span>
                </a>
              </sidebar-menu-button>
            </sidebar-menu-item>
          </sidebar-menu>
        </sidebar-group-content>
      </sidebar-group>
    </sidebar-content>
  </sidebar>
</template>
<script lang="ts" setup>
import {
  Sidebar,
  SidebarContent,
  SidebarGroup,
  SidebarGroupContent, SidebarHeader, SidebarMenu, SidebarMenuButton, SidebarMenuItem,
} from "@/components/ui/sidebar";
import {getAppSidebarItems} from "@/components/shared/app-sidebar/constants.ts";
import {useRouter} from "vue-router";

const router = useRouter();

const appSidebarItems = getAppSidebarItems(router);
</script>