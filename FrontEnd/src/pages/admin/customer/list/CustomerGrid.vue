<template>
  <page-layout page-title="Customer management">
    <template #page-actions>
      <Button>
        Add new
      </Button>
    </template>
    
    <api-data-table
        :schema="tableSchema"
        :api-url="CustomerService.getAllUrl()"
    />
  </page-layout>
</template>

<script lang="ts" setup>

import PageLayout from "@/components/shared/admin-page-components/page-layout.vue";
import { getSchema } from "@/pages/admin/customer/list/schema.ts";
import ApiDataTable from "@/components/admin/api-data-table/ApiDataTable.vue";
import { CustomerService } from "@/services/customerService.ts";
import { onMounted } from "vue";
import { Button } from "@/components/ui/button";

const tableSchema = getSchema()

onMounted(() => {
  console.log(tableSchema);
})

</script>
