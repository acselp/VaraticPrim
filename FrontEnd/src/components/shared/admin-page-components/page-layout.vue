<template>
  <div class="p-6 relative">
    <div class="flex justify-between">
      <page-title>
        {{ props.pageTitle }}
      </page-title>
      <div class="page-actions">
        <slot name="page-actions"/>
      </div>
    </div>
    <slot/>
  </div>
</template>
<script setup lang="ts">
import PageTitle from "@/components/shared/admin-page-components/page-title.vue";

const props = defineProps({
  pageTitle: String,
})

</script>
