<template>
  <div class="space-y-4">
    <div>
      <h1 class="text-3xl font-bold">Customers</h1>
      <p class="text-muted-foreground">Manage your customer base</p>
    </div>

    <data-table :columns="columns" :data="data" />
  </div>
</template>

<script setup lang="ts">
import DataTable from "~/components/ui/data-table/DataTable.vue";
import { CustomerService } from "~/services/CustomerService";
import { GetColumns } from "~/pages/admin/customers/column-schema";

definePageMeta({
  layout: "admin",
});

const { data, error, pending, status } = await CustomerService.search();
const columns = GetColumns();
</script>
