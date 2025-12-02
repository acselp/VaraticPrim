import { useMemo } from 'react'
import { useQuery, type UseQueryResult } from '@tanstack/react-query'
import { type PaginationState, type SortingState, type ColumnFiltersState } from '@tanstack/react-table'
import { fetchGridData } from '@/lib/api-client'
import { type GridResponse, type GridCommand } from '@/lib/types/grid-command'
import { urlStateToGridCommand } from '@/lib/utils/url-to-grid-command'
import {
  type RichTableDataSource,
  type RichTableDataSourceBackend,
  type RichTableBackendConfig,
} from '../types'

// ============================================================================
// Type Guards
// ============================================================================

/**
 * Check if data source is backend (API) strategy
 */
function isBackendDataSource<TData>(
  dataSource: RichTableDataSource<TData>
): dataSource is RichTableDataSourceBackend {
  return (
    typeof dataSource === 'object' &&
    'url' in dataSource &&
    typeof dataSource.url === 'string'
  )
}

/**
 * Check if data source is frontend (array) strategy
 */
function isFrontendDataSource<TData>(
  dataSource: RichTableDataSource<TData>
): dataSource is TData[] {
  return Array.isArray(dataSource)
}

// ============================================================================
// Hook Options
// ============================================================================

export type UseRichTableQueryOptions<TData> = {
  /**
   * Data source - either array (frontend) or API config (backend)
   */
  dataSource: RichTableDataSource<TData>

  /**
   * Current pagination state from table
   */
  pagination: PaginationState

  /**
   * Current column filters state from table
   */
  columnFilters?: ColumnFiltersState

  /**
   * Current sorting state from table
   */
  sorting?: SortingState

  /**
   * Global filter (search) value
   */
  globalFilter?: string

  /**
   * Backend configuration (mappings for filters and sorts)
   */
  backendConfig?: RichTableBackendConfig

  /**
   * Enable/disable the query (default: true)
   */
  enabled?: boolean
}

// ============================================================================
// Hook Return Type
// ============================================================================

export type UseRichTableQueryReturn<TData> = {
  /**
   * The data to display (either from frontend array or backend API)
   */
  data: TData[]

  /**
   * Loading state
   */
  isLoading: boolean

  /**
   * Error state
   */
  error: Error | null

  /**
   * Is the query currently fetching
   */
  isFetching: boolean

  /**
   * Total number of items (for pagination)
   */
  total: number

  /**
   * Total number of pages
   */
  totalPages: number

  /**
   * Refetch function
   */
  refetch: () => void

  /**
   * Is this using backend strategy
   */
  isBackendStrategy: boolean
}

// ============================================================================
// Hook Implementation
// ============================================================================

/**
 * Hook to handle data fetching for RichTable with support for both
 * frontend (array) and backend (API) strategies
 *
 * @example
 * ```typescript
 * // Frontend strategy
 * const query = useRichTableQuery({
 *   dataSource: customersData,
 *   pagination: table.getState().pagination,
 * })
 *
 * // Backend strategy
 * const query = useRichTableQuery({
 *   dataSource: {
 *     url: '/api/bills/search',
 *     dataSchema: billSchema
 *   },
 *   pagination: table.getState().pagination,
 *   columnFilters: table.getState().columnFilters,
 *   sorting: table.getState().sorting,
 *   globalFilter: table.getState().globalFilter,
 *   backendConfig: {
 *     columnFilterMappings: [...],
 *     sortMappings: [...]
 *   }
 * })
 * ```
 */
export function useRichTableQuery<TData>({
  dataSource,
  pagination,
  columnFilters = [],
  sorting = [],
  globalFilter,
  backendConfig,
  enabled = true,
}: UseRichTableQueryOptions<TData>): UseRichTableQueryReturn<TData> {
  // Determine strategy
  const isBackendStrategy = isBackendDataSource(dataSource)

  // Create GridCommand for backend strategy
  const gridCommand: GridCommand | null = useMemo(() => {
    if (!isBackendStrategy) return null

    return urlStateToGridCommand({
      pagination,
      columnFilters,
      sorting,
      globalFilter,
      config: backendConfig,
    })
  }, [
    isBackendStrategy,
    pagination,
    columnFilters,
    sorting,
    globalFilter,
    backendConfig,
  ])

  // Backend query (only runs if backend strategy)
  const backendQuery: UseQueryResult<GridResponse<TData>, Error> = useQuery({
    queryKey: ['rich-table', dataSource, gridCommand],
    queryFn: async () => {
      if (!isBackendStrategy || !gridCommand) {
        throw new Error('Invalid backend configuration')
      }

      const backendSource = dataSource as RichTableDataSourceBackend

      return await fetchGridData<TData>(
        backendSource.url,
        gridCommand,
        backendSource.dataSchema
      )
    },
    enabled: enabled && isBackendStrategy && !!gridCommand,
    // Keep previous data while fetching new data
    placeholderData: (previousData) => previousData,
  })

  // Frontend strategy - return static data
  if (isFrontendDataSource(dataSource)) {
    return {
      data: dataSource,
      isLoading: false,
      error: null,
      isFetching: false,
      total: dataSource.length,
      totalPages: Math.ceil(dataSource.length / pagination.pageSize),
      refetch: () => {}, // No-op for frontend strategy
      isBackendStrategy: false,
    }
  }

  // Backend strategy - return query results
  return {
    data: backendQuery.data?.data ?? [],
    isLoading: backendQuery.isLoading,
    error: backendQuery.error,
    isFetching: backendQuery.isFetching,
    total: backendQuery.data?.total ?? 0,
    totalPages: backendQuery.data?.totalPages ?? 0,
    refetch: () => backendQuery.refetch(),
    isBackendStrategy: true,
  }
}
