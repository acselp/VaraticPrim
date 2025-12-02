import { type ColumnFiltersState, type SortingState, type PaginationState } from '@tanstack/react-table'
import {
  type GridCommand,
  type Filter,
  type Sort,
  type FilterOperator,
  createGridCommand,
} from '../types/grid-command'

// ============================================================================
// Column Filter Configuration
// ============================================================================

/**
 * Configuration for mapping a column filter to a backend filter
 */
export type ColumnFilterMapping = {
  /**
   * The column ID from the table (e.g., 'status')
   */
  columnId: string

  /**
   * The backend field name (e.g., 'Status' or 'statusId')
   * If not provided, uses columnId
   */
  field?: string

  /**
   * The filter operator to use for this column
   * Default: 'in' for arrays, 'contains' for strings
   */
  operator?: FilterOperator

  /**
   * Optional custom transformer for the value before sending to backend
   */
  transformValue?: (value: unknown) => unknown
}

// ============================================================================
// Sorting Configuration
// ============================================================================

/**
 * Configuration for mapping a column sort to a backend sort
 */
export type SortMapping = {
  /**
   * The column ID from the table (e.g., 'createdAt')
   */
  columnId: string

  /**
   * The backend field name (e.g., 'CreatedAt' or 'created_date')
   * If not provided, uses columnId
   */
  field?: string
}

// ============================================================================
// Conversion Configuration
// ============================================================================

export type UrlToGridCommandConfig = {
  /**
   * Column filter mappings
   */
  columnFilterMappings?: ColumnFilterMapping[]

  /**
   * Sort mappings
   */
  sortMappings?: SortMapping[]

  /**
   * Default filter operator for unmapped columns
   */
  defaultFilterOperator?: FilterOperator
}

// ============================================================================
// Converter Function
// ============================================================================

/**
 * Converts URL state (from useTableUrlState and TanStack Table) to GridCommand
 *
 * @param options - The table state and configuration
 * @returns GridCommand ready to send to backend
 *
 * @example
 * ```typescript
 * const command = urlStateToGridCommand({
 *   pagination: table.getState().pagination,
 *   columnFilters: table.getState().columnFilters,
 *   sorting: table.getState().sorting,
 *   globalFilter: table.getState().globalFilter,
 *   config: {
 *     columnFilterMappings: [
 *       { columnId: 'status', field: 'Status', operator: 'in' },
 *       { columnId: 'name', field: 'Name', operator: 'contains' },
 *     ],
 *     sortMappings: [
 *       { columnId: 'createdAt', field: 'CreatedAt' },
 *     ],
 *   },
 * })
 * ```
 */
export function urlStateToGridCommand(options: {
  pagination: PaginationState
  columnFilters?: ColumnFiltersState
  sorting?: SortingState
  globalFilter?: string
  config?: UrlToGridCommandConfig
}): GridCommand {
  const {
    pagination,
    columnFilters = [],
    sorting = [],
    globalFilter,
    config = {},
  } = options

  const {
    columnFilterMappings = [],
    sortMappings = [],
    defaultFilterOperator = 'contains',
  } = config

  // Convert pagination (TanStack Table uses 0-indexed, backend uses 1-indexed)
  const page = pagination.pageIndex + 1
  const pageSize = pagination.pageSize

  // Convert column filters to Filter[]
  const filters: Filter[] = columnFilters
    .map((columnFilter) => {
      // Find mapping configuration for this column
      const mapping = columnFilterMappings.find(
        (m) => m.columnId === columnFilter.id
      )

      const field = mapping?.field || columnFilter.id
      const value = mapping?.transformValue
        ? mapping.transformValue(columnFilter.value)
        : columnFilter.value

      // Determine operator based on value type and mapping
      let operator: FilterOperator

      if (mapping?.operator) {
        operator = mapping.operator
      } else if (Array.isArray(value)) {
        operator = 'in'
      } else if (typeof value === 'string') {
        operator = 'contains'
      } else if (typeof value === 'number') {
        operator = 'equals'
      } else {
        operator = defaultFilterOperator
      }

      return {
        field,
        operator,
        value,
        logic: 'and' as const,
      }
    })
    .filter((filter) => {
      // Remove filters with empty/null values
      if (filter.value === null || filter.value === undefined) return false
      if (typeof filter.value === 'string' && filter.value.trim() === '')
        return false
      if (Array.isArray(filter.value) && filter.value.length === 0) return false
      return true
    })

  // Convert sorting to Sort[]
  const sorts: Sort[] = sorting
    .map((sort) => {
      // Find mapping configuration for this column
      const mapping = sortMappings.find((m) => m.columnId === sort.id)

      const field = mapping?.field || sort.id
      const dir = sort.desc ? ('desc' as const) : ('asc' as const)

      return {
        field,
        dir,
      }
    })
    .filter((sort) => sort.field) // Remove sorts with empty fields

  // Create GridCommand
  return createGridCommand({
    page,
    pageSize,
    filters,
    sorts,
    search: globalFilter && globalFilter.trim() !== '' ? globalFilter : undefined,
  })
}

// ============================================================================
// Helper Functions
// ============================================================================

/**
 * Creates a simple filter mapping with default operator
 */
export function createFilterMapping(
  columnId: string,
  field?: string,
  operator?: FilterOperator
): ColumnFilterMapping {
  return {
    columnId,
    field: field || columnId,
    operator,
  }
}

/**
 * Creates a simple sort mapping
 */
export function createSortMapping(
  columnId: string,
  field?: string
): SortMapping {
  return {
    columnId,
    field: field || columnId,
  }
}

/**
 * Helper to create filter mappings for multiple columns at once
 */
export function createFilterMappings(
  mappings: Array<{
    columnId: string
    field?: string
    operator?: FilterOperator
  }>
): ColumnFilterMapping[] {
  return mappings.map((m) => createFilterMapping(m.columnId, m.field, m.operator))
}

/**
 * Helper to create sort mappings for multiple columns at once
 */
export function createSortMappings(
  mappings: Array<{
    columnId: string
    field?: string
  }>
): SortMapping[] {
  return mappings.map((m) => createSortMapping(m.columnId, m.field))
}
