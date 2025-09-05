<template>
  <div class="p-6 relative">
    <page-title>
      {{ props.pageTitle }}
    </page-title>
    <slot/>
  </div>
</template>
<script setup lang="ts">
import PageTitle from "@/components/shared/admin-page-components/page-title.vue";

const props = defineProps({
  pageTitle: String,
})

</script>