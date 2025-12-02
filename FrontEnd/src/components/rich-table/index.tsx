import { useEffect } from 'react'
import { flexRender } from '@tanstack/react-table'
import { cn } from '@/lib/utils'
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table'
import { DataTablePagination, DataTableToolbar } from '@/components/data-table'
import { type RichTableSchema } from './types'
import { useRichTable } from './hooks/use-rich-table'
import { RichTableBulkActions } from './components/rich-table-bulk-actions'
import { RichTableSkeleton } from './components/rich-table-skeleton'
import { RichTableError } from './components/rich-table-error'

type RichTableProps<TData> = {
  schema: RichTableSchema<TData>
}

export function RichTable<TData>({ schema }: RichTableProps<TData>) {
  const {
    table,
    ensurePageInRange,
    isLoading,
    error,
    isFetching,
    refetch,
    isBackendStrategy,
  } = useRichTable({ schema })

  const {
    columns,
    filters,
    toolbar,
    bulkActions,
    styling,
    emptyState: EmptyState,
    loadingState: LoadingState,
    errorState: ErrorState,
  } = schema

  // Ensure page index is valid when page count changes
  const pageCount = table.getPageCount()
  useEffect(() => {
    ensurePageInRange(pageCount)
  }, [pageCount, ensurePageInRange])

  // Prepare toolbar filters
  const toolbarFilters = filters?.columnFilters?.map((filter) => ({
    columnId: filter.columnId,
    title: filter.title || filter.columnId,
    options: filter.options || [],
  }))

  // Render custom toolbar if provided
  const renderToolbar = () => {
    if (toolbar?.customToolbar) {
      const CustomToolbar = toolbar.customToolbar
      return <CustomToolbar table={table} />
    }

    // Show default toolbar only if we have search or filters
    const hasGlobalFilter = filters?.globalFilter?.enabled
    const hasColumnFilters = (filters?.columnFilters?.length ?? 0) > 0
    const showToolbar = hasGlobalFilter || hasColumnFilters

    if (!showToolbar) return null

    return (
      <DataTableToolbar
        table={table}
        searchPlaceholder={toolbar?.searchPlaceholder || 'Search...'}
        filters={toolbarFilters}
      />
    )
  }

  // Render empty state
  const renderEmptyState = () => {
    if (EmptyState) {
      return (
        <TableRow>
          <TableCell colSpan={columns.length} className='h-24 text-center'>
            <EmptyState />
          </TableCell>
        </TableRow>
      )
    }

    return (
      <TableRow>
        <TableCell colSpan={columns.length} className='h-24 text-center'>
          No results.
        </TableCell>
      </TableRow>
    )
  }

  // Show loading state (only for initial load with backend strategy)
  if (isLoading && isBackendStrategy) {
    if (LoadingState) {
      return <LoadingState />
    }
    return <RichTableSkeleton columns={columns.length} />
  }

  // Show error state (only for backend strategy)
  if (error && isBackendStrategy) {
    if (ErrorState) {
      return <ErrorState error={error} retry={refetch} />
    }
    return <RichTableError error={error} retry={refetch} />
  }

  return (
    <div
      className={cn(
        'max-sm:has-[div[role="toolbar"]]:mb-16', // Add margin bottom on mobile when toolbar is visible
        'flex flex-1 flex-col gap-4',
        styling?.container
      )}
    >
      {renderToolbar()}

      <div
        className={cn(
          'overflow-hidden rounded-md border',
          styling?.tableWrapper,
          // Add opacity when fetching new data (for backend strategy)
          isFetching && isBackendStrategy && 'opacity-60 pointer-events-none'
        )}
      >
        <Table className={styling?.table}>
          <TableHeader>
            {table.getHeaderGroups().map((headerGroup) => (
              <TableRow key={headerGroup.id}>
                {headerGroup.headers.map((header) => {
                  return (
                    <TableHead
                      key={header.id}
                      colSpan={header.colSpan}
                      className={cn(
                        header.column.columnDef.meta?.className,
                        header.column.columnDef.meta?.thClassName
                      )}
                    >
                      {header.isPlaceholder
                        ? null
                        : flexRender(
                            header.column.columnDef.header,
                            header.getContext()
                          )}
                    </TableHead>
                  )
                })}
              </TableRow>
            ))}
          </TableHeader>
          <TableBody>
            {table.getRowModel().rows?.length ? (
              table.getRowModel().rows.map((row) => (
                <TableRow
                  key={row.id}
                  data-state={row.getIsSelected() && 'selected'}
                >
                  {row.getVisibleCells().map((cell) => (
                    <TableCell
                      key={cell.id}
                      className={cn(
                        cell.column.columnDef.meta?.className,
                        cell.column.columnDef.meta?.tdClassName
                      )}
                    >
                      {flexRender(
                        cell.column.columnDef.cell,
                        cell.getContext()
                      )}
                    </TableCell>
                  ))}
                </TableRow>
              ))
            ) : (
              renderEmptyState()
            )}
          </TableBody>
        </Table>
      </div>

      <DataTablePagination
        table={table}
        className={cn('mt-auto', styling?.pagination)}
      />

      {bulkActions && (
        <RichTableBulkActions table={table} config={bulkActions} />
      )}
    </div>
  )
}

// Re-export types and utilities for convenience
export * from './types'
export * from './utils/create-schema'
export { RichTableRowActions } from './components/rich-table-row-actions'
export { RichTableBulkActions } from './components/rich-table-bulk-actions'
export { RichTableSkeleton } from './components/rich-table-skeleton'
export { RichTableError } from './components/rich-table-error'
