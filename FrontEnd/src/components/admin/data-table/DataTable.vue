<template>
  <div class="w-full">
    <div class="rounded-md border">
      <Table>
        <TableHeader>
          <TableRow v-for="headerGroup in table.getHeaderGroups()" :key="headerGroup.id">
            <TableHead v-for="header in headerGroup.headers" :key="header.id">
              <FlexRender v-if="!header.isPlaceholder" :render="header.column.columnDef.header"
                          :props="header.getContext()"/>
            </TableHead>

            <TableHead class="w-1 whitespace-nowrap">
              Actions
            </TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          <template v-if="internalTableData?.length">
            <template v-for="row in internalTableData" :key="row.id">
              <TableRow>
                <TableCell v-for="cell in row.getVisibleCells()" :key="cell.id">
                  <FlexRender :render="cell.column.columnDef.cell" :props="cell.getContext()"/>
                </TableCell>

                <TableCell>
                  <div class="flex space-x-1">
                    <Button v-for="action in schema.actionConfig.rowActions.actions"
                            :class="getCbProperty(action.class, { row, tableData: internalTableData })"
                            @click="action.action({ row, tableData: internalTableData })">
                      {{ getCbProperty(action.buttonSlot, { row, tableData: internalTableData }) }}
                    </Button>
                  </div>
                </TableCell>
              </TableRow>
            </template>
          </template>

          <TableRow v-else-if="loading">
            <TableCell
                :colspan="schema.columnConfig.columnList.length"
                class="h-24"
            >
              <Loading class="mx-auto"/>
            </TableCell>
          </TableRow>
          <TableRow v-else-if="!internalTableData?.length">
            <TableCell
                :colspan="schema.columnConfig.columnList.length"
                class="h-24 text-center"
            >
              No results.
            </TableCell>
          </TableRow>
        </TableBody>
      </Table>
    </div>

    <div class="flex items-center justify-end space-x-2 py-4">
      <div class="flex-1 text-sm text-muted-foreground">
        {{ table.getFilteredSelectedRowModel().rows.length }} of
        {{ table.getFilteredRowModel().rows.length }} row(s) selected.
      </div>
      <div class="space-x-2">
        <Button
            variant="outline"
            size="sm"
            :disabled="!table.getCanPreviousPage()"
            @click="table.previousPage()"
        >
          Previous
        </Button>
        <Button
            variant="outline"
            size="sm"
            :disabled="!table.getCanNextPage()"
            @click="table.nextPage()"
        >
          Next
        </Button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">

import { Button } from "@/components/ui/button";
import type {
  ExpandedState,
} from "@tanstack/vue-table"
import {
  FlexRender,
  getCoreRowModel,
  getExpandedRowModel,
  getFilteredRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  useVueTable,
} from "@tanstack/vue-table"
import { computed, type PropType, ref } from "vue"

import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"
import Loading from "@/components/shared/loading/Loading.vue";
import type { ITableCbData, ITableSchema, TableActionValue } from "@/components/admin/data-table/types.ts";

const props = defineProps({
  schema: Object as PropType<ITableSchema<any>>,
  tableData: Array,
  loading: Boolean,
})

const expanded = ref<ExpandedState>({})

const table = useVueTable({
  columns: props.schema.columnConfig.columnList,
  get data() {
    return props.tableData as any[]
  },
  getCoreRowModel: getCoreRowModel(),
  getPaginationRowModel: getPaginationRowModel(),
  getSortedRowModel: getSortedRowModel(),
  getFilteredRowModel: getFilteredRowModel(),
  getExpandedRowModel: getExpandedRowModel(),
  state: {
    get expanded() {
      return expanded.value
    },
  },
})

const internalTableData = computed(() => {
  return table.getRowModel().rows;
})

const getCbProperty = (action: TableActionValue<any>, data: ITableCbData<any>) => {
  return !!action ? (typeof action === 'string' ? action : action(data)) : ''
}

</script>
