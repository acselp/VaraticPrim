<template>
  <AdminLayout>
    <PageBreadcrumb pageTitle="Manage customers" />
    <div class="space-y-5 sm:space-y-6">
      <ComponentCard title="Basic Table 1">
        <BasicTableOne />
      </ComponentCard>
    </div>
  </AdminLayout>
</template>

<script lang="ts" setup>

import BasicTableOne from '@/components/tables/basic-tables/BasicTableOne.vue'
import AdminLayout from '@/components/layout/AdminLayout.vue'
import PageBreadcrumb from '@/components/common/PageBreadcrumb.vue'
import ComponentCard from '@/components/common/ComponentCard.vue'
</script>
