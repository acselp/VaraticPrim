<template>
  <page-layout :page-title="`Edit customer - ${}`">
    <template #page-actions>
      <Button @click="onGoToCreateEdit">
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

import { CustomerService } from "@/services/customerService.ts";
import { Button } from "@/components/ui/button";
import PageLayout from "@/components/shared/admin-page-components/page-layout.vue";
import ApiDataTable from "@/components/admin/api-data-table/ApiDataTable.vue";
import { useRouter } from "vue-router";

const router = useRouter();

const onGoToCreateEdit = () => {
  router.push()
}

</script>
