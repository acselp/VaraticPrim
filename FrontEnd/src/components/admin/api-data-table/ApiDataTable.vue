<template>
  <data-table
      :columns="columns"
      :table-data="tableData"
  />
</template>

<script lang="ts" setup>

import DataTable from "@/components/admin/data-table/DataTable.vue";
import {onMounted, type PropType, ref} from "vue";
import type {ColumnDef} from "@tanstack/vue-table";
import {apiClient} from "@/api-client/apiClient.ts";

const props = defineProps({
  columns: Array as PropType<ColumnDef<any>[]>,
  apiUrl: String,
})

const tableData = ref([])

const onFetchDataSuccess = (res) => {
  tableData.value = res.data;
}

const onFetchDataFailure = (err) => {

}

const fetchData = () => {
  apiClient.post(props.apiUrl)
      .then((res) => {
        onFetchDataSuccess(res)
      })
      .catch((err) => {
        onFetchDataFailure(err)
      })
}

onMounted(() => {
  fetchData();
})

</script>