import { type ColumnDef, type FilterFn, type Table } from '@tanstack/react-table'
import { type LucideIcon } from 'lucide-react'
import { type z } from 'zod'
import {
  type ColumnFilterMapping,
  type SortMapping,
} from '@/lib/utils/url-to-grid-command'

// ============================================================================
// Data Source Types
// ============================================================================

/**
 * Frontend strategy - array of data (client-side filtering/pagination)
 */
export type RichTableDataSourceFrontend<TData> = TData[]

/**
 * Backend strategy - API endpoint (server-side filtering/pagination)
 */
export type RichTableDataSourceBackend = {
  /**
   * API endpoint URL (e.g., '/api/bills/search')
   */
  url: string

  /**
   * HTTP method (default: 'POST')
   */
  method?: 'POST' | 'GET'

  /**
   * Zod schema for validating individual data items
   */
  dataSchema: z.ZodType<any>
}

/**
 * Data source can be either frontend (array) or backend (API config)
 */
export type RichTableDataSource<TData> =
  | RichTableDataSourceFrontend<TData>
  | RichTableDataSourceBackend

// ============================================================================
// Backend Configuration Types
// ============================================================================

/**
 * Backend integration configuration for GridCommand mapping
 */
export type RichTableBackendConfig = {
  /**
   * Mappings for column filters to backend fields
   */
  columnFilterMappings?: ColumnFilterMapping[]

  /**
   * Mappings for sorting to backend fields
   */
  sortMappings?: SortMapping[]
}

// ============================================================================
// Core Schema Types
// ============================================================================

export type RichTableSchema<TData> = {
  /**
   * Data source - either array of data (frontend) or API config (backend)
   *
   * Frontend strategy (client-side):
   * ```typescript
   * dataSource: customersData // TData[]
   * ```
   *
   * Backend strategy (server-side):
   * ```typescript
   * dataSource: {
   *   url: '/api/bills/search',
   *   method: 'POST',
   *   dataSchema: billSchema
   * }
   * ```
   */
  dataSource: RichTableDataSource<TData>

  /**
   * Column definitions using TanStack Table's ColumnDef
   */
  columns: ColumnDef<TData>[]

  /**
   * Router configuration for URL state management (required)
   */
  router: {
    search: Record<string, any>
    navigate: (opts: { search: (prev: any) => any; replace?: boolean }) => void
  }

  /**
   * Filter configurations
   */
  filters?: RichTableFilters<TData>

  /**
   * Row action configurations
   */
  rowActions?: RichTableRowAction<TData>[]

  /**
   * Bulk action configurations
   */
  bulkActions?: RichTableBulkActions<TData>

  /**
   * Pagination configuration
   */
  pagination?: RichTablePaginationConfig

  /**
   * Toolbar configuration
   */
  toolbar?: RichTableToolbarConfig<TData>

  /**
   * Backend integration configuration (only needed for backend strategy)
   * Maps table columns to backend field names for GridCommand
   */
  backend?: RichTableBackendConfig

  /**
   * Optional styling customization
   */
  styling?: RichTableStyling

  /**
   * Optional custom empty state component
   */
  emptyState?: React.ComponentType

  /**
   * Optional custom loading state component
   */
  loadingState?: React.ComponentType

  /**
   * Optional custom error state component
   */
  errorState?: React.ComponentType<{ error: Error; retry: () => void }>
}

// ============================================================================
// Filter Types
// ============================================================================

export type RichTableFilters<TData> = {
  /**
   * Global filter configuration (searches across multiple fields)
   */
  globalFilter?: {
    enabled: boolean
    key?: string
    filterFn?: FilterFn<TData>
  }

  /**
   * Column-specific filters with faceted options
   */
  columnFilters?: RichTableColumnFilter[]
}

export type RichTableColumnFilter = {
  columnId: string
  searchKey: string
  type: 'string' | 'array' | 'date' | 'number'
  title?: string
  options?: RichTableFilterOption[]
}

export type RichTableFilterOption = {
  label: string
  value: string
  icon?: React.ComponentType<{ className?: string }> | LucideIcon
}

// ============================================================================
// Action Types
// ============================================================================

export type RichTableRowAction<TData> = {
  /**
   * Action label displayed in the dropdown
   */
  label: string

  /**
   * Optional icon component
   */
  icon?: React.ComponentType<{ className?: string }> | LucideIcon

  /**
   * Click handler - receives the row data
   */
  onClick: (row: TData) => void | Promise<void>

  /**
   * Optional function to determine if action should be disabled
   */
  disabled?: (row: TData) => boolean

  /**
   * Optional variant for styling (destructive, default, etc.)
   */
  variant?: 'default' | 'destructive'

  /**
   * Optional keyboard shortcut to display
   */
  shortcut?: string

  /**
   * For nested sub-menus
   */
  subActions?: RichTableRowSubAction<TData>[]

  /**
   * Show separator after this action
   */
  separator?: boolean
}

export type RichTableRowSubAction<TData> = {
  label: string
  value: string
  onClick: (row: TData, value: string) => void | Promise<void>
}

export type RichTableBulkActions<TData> = {
  /**
   * Name of the entity (e.g., "task", "user") for display purposes
   */
  entityName: string

  /**
   * Bulk action items
   */
  actions: RichTableBulkActionItem<TData>[]

  /**
   * Optional dialog component for confirmation/forms
   */
  dialogs?: {
    [key: string]: React.ComponentType<{
      open: boolean
      onOpenChange: (open: boolean) => void
      table: Table<TData>
    }>
  }
}

export type RichTableBulkActionItem<TData> = {
  /**
   * Unique identifier for this action
   */
  id: string

  /**
   * Action label for tooltip/aria-label
   */
  label: string

  /**
   * Icon component
   */
  icon: React.ComponentType<{ className?: string }> | LucideIcon

  /**
   * Click handler - receives selected rows
   */
  onClick?: (selectedRows: TData[], table: Table<TData>) => void | Promise<void>

  /**
   * Optional variant for styling
   */
  variant?: 'default' | 'outline' | 'destructive'

  /**
   * For dropdown actions (like status/priority updates)
   */
  dropdownOptions?: {
    options: RichTableFilterOption[]
    onSelect: (
      value: string,
      selectedRows: TData[],
      table: Table<TData>
    ) => void | Promise<void>
  }

  /**
   * Optional dialog key to open from bulkActions.dialogs
   */
  dialogKey?: string
}

// ============================================================================
// Pagination Types
// ============================================================================

export type RichTablePaginationConfig = {
  /**
   * Default page number (1-indexed)
   */
  defaultPage?: number

  /**
   * Default page size
   */
  defaultPageSize?: number

  /**
   * Available page size options
   */
  pageSizeOptions?: number[]
}

// ============================================================================
// Toolbar Types
// ============================================================================

export type RichTableToolbarConfig<TData> = {
  /**
   * Placeholder text for search input
   */
  searchPlaceholder?: string

  /**
   * Show/hide the view options button
   */
  showViewOptions?: boolean

  /**
   * Show/hide the filters
   */
  showFilters?: boolean

  /**
   * Custom toolbar component (replaces default)
   */
  customToolbar?: React.ComponentType<{
    table: Table<TData>
  }>
}

// ============================================================================
// Styling Types
// ============================================================================

export type RichTableStyling = {
  /**
   * Class name for the main container
   */
  container?: string

  /**
   * Class name for the table wrapper
   */
  tableWrapper?: string

  /**
   * Class name for the table itself
   */
  table?: string

  /**
   * Class name for the pagination
   */
  pagination?: string

  /**
   * Class name for the toolbar
   */
  toolbar?: string
}
