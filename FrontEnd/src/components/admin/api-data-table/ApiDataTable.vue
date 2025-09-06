<template>
  <data-table
      :schema="schema"
      :table-data="tableData"
      :loading="isLoading"
  />
</template>

<script lang="ts" setup>

import DataTable from "@/components/admin/data-table/DataTable.vue";
import {onMounted, type PropType, ref} from "vue";
import {apiClient} from "@/api-client/apiClient.ts";
import type {ITableSchema} from "@/components/admin/data-table/types.ts";

const props = defineProps({
  schema: Object as PropType<ITableSchema<any>>,
  apiUrl: String,
})

const tableData = ref([])
const isLoading = ref(false)

const onFetchDataSuccess = (res) => {
  tableData.value = [...res.data];
}

const onFetchDataFailure = (err) => {

}

const fetchData = () => {
  isLoading.value = true;
  apiClient.post(props.apiUrl)
      .then((res) => {
        onFetchDataSuccess(res)
      })
      .catch((err) => {
        onFetchDataFailure(err)
      })
      .finally(() => {
        isLoading.value = false;
      })
}

onMounted(() => {
  fetchData();
})

</script>