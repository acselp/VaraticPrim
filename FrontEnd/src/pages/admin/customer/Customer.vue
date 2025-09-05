<template>
  <page-layout page-title="Customer management">
    <api-data-table
        :columns="columns"
        :api-url="CustomerService.getAllUrl()"
    />
  </page-layout>
</template>

<script lang="ts" setup>

import PageLayout from "@/components/shared/admin-page-components/page-layout.vue";
import {columns} from "@/pages/admin/customer/columns.ts";
import ApiDataTable from "@/components/admin/api-data-table/ApiDataTable.vue";
import {CustomerService} from "@/services/customerService.ts";

</script>