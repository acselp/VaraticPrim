import { useState, useMemo } from 'react'
import {
  type SortingState,
  type VisibilityState,
  getCoreRowModel,
  getFacetedRowModel,
  getFacetedUniqueValues,
  getFilteredRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  useReactTable,
} from '@tanstack/react-table'
import { useTableUrlState } from '@/hooks/use-table-url-state'
import { type RichTableSchema } from '../types'
import { useRichTableQuery } from './use-rich-table-query'

type UseRichTableOptions<TData> = {
  schema: RichTableSchema<TData>
}

export function useRichTable<TData>({ schema }: UseRichTableOptions<TData>) {
  const {
    dataSource,
    columns,
    router,
    filters,
    pagination: paginationConfig,
    backend: backendConfig,
  } = schema

  // Local UI-only states (not synced with URL)
  const [rowSelection, setRowSelection] = useState({})
  const [sorting, setSorting] = useState<SortingState>([])
  const [columnVisibility, setColumnVisibility] = useState<VisibilityState>({})

  // Prepare URL state configuration
  const urlStateConfig = {
    search: router.search,
    navigate: router.navigate,
    pagination: {
      defaultPage: paginationConfig?.defaultPage || 1,
      defaultPageSize: paginationConfig?.defaultPageSize || 10,
    },
    globalFilter: filters?.globalFilter?.enabled
      ? {
          enabled: true,
          key: filters.globalFilter.key || 'filter',
        }
      : undefined,
    columnFilters: filters?.columnFilters || [],
  }

  // URL-synced states
  const {
    globalFilter,
    onGlobalFilterChange,
    columnFilters,
    onColumnFiltersChange,
    pagination,
    onPaginationChange,
    ensurePageInRange,
  } = useTableUrlState(urlStateConfig)

  // Fetch data using query hook (handles both frontend and backend strategies)
  const queryResult = useRichTableQuery({
    dataSource,
    pagination,
    columnFilters,
    sorting,
    globalFilter,
    backendConfig,
  })

  // Determine if we need manual pagination (backend strategy) or client-side (frontend strategy)
  const manualPagination = queryResult.isBackendStrategy

  // For backend strategy, calculate page count from server response
  // For frontend strategy, let TanStack Table calculate it
  const pageCount = useMemo(() => {
    if (manualPagination) {
      return queryResult.totalPages
    }
    return undefined // Let TanStack Table calculate it
  }, [manualPagination, queryResult.totalPages])

  // Create the table instance
  // eslint-disable-next-line react-hooks/incompatible-library
  const table = useReactTable({
    data: queryResult.data,
    columns,
    pageCount,
    state: {
      sorting,
      columnVisibility,
      rowSelection,
      columnFilters,
      globalFilter,
      pagination,
    },
    enableRowSelection: true,
    onRowSelectionChange: setRowSelection,
    onSortingChange: setSorting,
    onColumnVisibilityChange: setColumnVisibility,
    globalFilterFn: filters?.globalFilter?.filterFn,
    // For backend strategy, disable client-side filtering/pagination/sorting
    manualPagination,
    manualFiltering: manualPagination,
    manualSorting: manualPagination,
    getCoreRowModel: getCoreRowModel(),
    getFilteredRowModel: manualPagination ? undefined : getFilteredRowModel(),
    getPaginationRowModel: manualPagination ? undefined : getPaginationRowModel(),
    getSortedRowModel: manualPagination ? undefined : getSortedRowModel(),
    getFacetedRowModel: getFacetedRowModel(),
    getFacetedUniqueValues: getFacetedUniqueValues(),
    onPaginationChange,
    onGlobalFilterChange,
    onColumnFiltersChange,
  })

  return {
    table,
    ensurePageInRange,
    // Query states
    isLoading: queryResult.isLoading,
    error: queryResult.error,
    isFetching: queryResult.isFetching,
    refetch: queryResult.refetch,
    isBackendStrategy: queryResult.isBackendStrategy,
  }
}
