import { type ColumnDef } from '@tanstack/react-table'
import {
  type RichTableSchema,
  type RichTableFilters,
  type RichTablePaginationConfig,
  type RichTableToolbarConfig,
  type RichTableRowAction,
  type RichTableBulkActions,
} from '../types'

/**
 * Helper function to create a RichTable schema with type safety
 */
export function createRichTableSchema<TData>(
  schema: RichTableSchema<TData>
): RichTableSchema<TData> {
  return schema
}

/**
 * Helper to create filter configuration
 */
export function createFilters<TData>(
  filters: RichTableFilters<TData>
): RichTableFilters<TData> {
  return filters
}

/**
 * Helper to create pagination configuration with defaults
 */
export function createPaginationConfig(
  config?: Partial<RichTablePaginationConfig>
): RichTablePaginationConfig {
  return {
    defaultPage: 1,
    defaultPageSize: 10,
    pageSizeOptions: [10, 20, 30, 40, 50],
    ...config,
  }
}

/**
 * Helper to create toolbar configuration with defaults
 */
export function createToolbarConfig<TData>(
  config?: Partial<RichTableToolbarConfig<TData>>
): RichTableToolbarConfig<TData> {
  return {
    searchPlaceholder: 'Search...',
    showViewOptions: true,
    showFilters: true,
    ...config,
  }
}

/**
 * Helper to create row actions
 */
export function createRowActions<TData>(
  actions: RichTableRowAction<TData>[]
): RichTableRowAction<TData>[] {
  return actions
}

/**
 * Helper to create bulk actions configuration
 */
export function createBulkActions<TData>(
  config: RichTableBulkActions<TData>
): RichTableBulkActions<TData> {
  return config
}

/**
 * Helper to create a column with common defaults
 */
export function createColumn<TData, TValue = unknown>(
  column: ColumnDef<TData, TValue>
): ColumnDef<TData, TValue> {
  return column
}

/**
 * Helper to create multiple columns
 */
export function createColumns<TData>(
  columns: ColumnDef<TData>[]
): ColumnDef<TData>[] {
  return columns
}
