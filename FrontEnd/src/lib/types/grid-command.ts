import { z } from 'zod'

// ============================================================================
// Filter Operators
// ============================================================================

export const filterOperatorSchema = z.enum([
  // Text operators
  'contains',
  'notContains',
  'equals',
  'notEquals',
  'startsWith',
  'endsWith',
  // Array operators
  'in',
  'notIn',
  // Comparison operators
  'gt', // greater than
  'gte', // greater than or equal
  'lt', // less than
  'lte', // less than or equal
  // Range operators
  'between', // for date ranges and number ranges
])

export type FilterOperator = z.infer<typeof filterOperatorSchema>

// ============================================================================
// Logic Operators
// ============================================================================

export const logicOperatorSchema = z.enum(['and', 'or'])
export type LogicOperator = z.infer<typeof logicOperatorSchema>

// ============================================================================
// Filter Model
// ============================================================================

export const filterSchema = z.object({
  /**
   * The field name to filter on (matches backend property name)
   */
  field: z.string(),

  /**
   * The filter operator
   */
  operator: filterOperatorSchema,

  /**
   * The value to filter by
   * - For 'in' operator: array of values
   * - For 'between' operator: array of [min, max]
   * - For other operators: single value
   */
  value: z.unknown(),

  /**
   * Logic operator for combining with other filters (default: 'and')
   */
  logic: logicOperatorSchema.optional().default('and'),
})

export type Filter = z.infer<typeof filterSchema>

// ============================================================================
// Sort Model
// ============================================================================

export const sortDirectionSchema = z.enum(['asc', 'desc'])
export type SortDirection = z.infer<typeof sortDirectionSchema>

export const sortSchema = z.object({
  /**
   * The field name to sort by (matches backend property name)
   */
  field: z.string(),

  /**
   * Sort direction
   */
  dir: sortDirectionSchema,
})

export type Sort = z.infer<typeof sortSchema>

// ============================================================================
// Grid Command Model (Request)
// ============================================================================

export const gridCommandSchema = z.object({
  /**
   * Page number (1-indexed)
   */
  page: z.number().int().min(1).default(1),

  /**
   * Number of items per page
   */
  pageSize: z.number().int().min(1).max(100).default(10),

  /**
   * Array of filters to apply
   */
  filters: z.array(filterSchema).optional().default([]),

  /**
   * Array of sorts to apply (applied in order)
   */
  sorts: z.array(sortSchema).optional().default([]),

  /**
   * Global search string (searches across multiple fields)
   * Backend determines which fields to search
   */
  search: z.string().optional(),
})

export type GridCommand = z.infer<typeof gridCommandSchema>

// ============================================================================
// Grid Response Model (Response from Backend)
// ============================================================================

/**
 * Creates a Zod schema for grid responses with typed data
 */
export const createGridResponseSchema = <T extends z.ZodType>(
  dataSchema: T
) => {
  return z.object({
    /**
     * Array of data items for the current page
     */
    data: z.array(dataSchema),

    /**
     * Total number of items across all pages
     */
    total: z.number().int().min(0),

    /**
     * Current page number (1-indexed)
     */
    page: z.number().int().min(1),

    /**
     * Number of items per page
     */
    pageSize: z.number().int().min(1),

    /**
     * Total number of pages
     */
    totalPages: z.number().int().min(0),
  })
}

/**
 * Grid response type
 */
export type GridResponse<T> = {
  data: T[]
  total: number
  page: number
  pageSize: number
  totalPages: number
}

// ============================================================================
// Helper Functions
// ============================================================================

/**
 * Creates a GridCommand with default values
 */
export function createGridCommand(
  partial?: Partial<GridCommand>
): GridCommand {
  return gridCommandSchema.parse({
    page: 1,
    pageSize: 10,
    filters: [],
    sorts: [],
    ...partial,
  })
}

/**
 * Helper to create a filter
 */
export function createFilter(
  field: string,
  operator: FilterOperator,
  value: unknown,
  logic: LogicOperator = 'and'
): Filter {
  return {
    field,
    operator,
    value,
    logic,
  }
}

/**
 * Helper to create a sort
 */
export function createSort(field: string, dir: SortDirection = 'asc'): Sort {
  return {
    field,
    dir,
  }
}

// ============================================================================
// Type Guards
// ============================================================================

/**
 * Check if a value is a GridCommand
 */
export function isGridCommand(value: unknown): value is GridCommand {
  return gridCommandSchema.safeParse(value).success
}

/**
 * Check if a value is a Filter
 */
export function isFilter(value: unknown): value is Filter {
  return filterSchema.safeParse(value).success
}

/**
 * Check if a value is a Sort
 */
export function isSort(value: unknown): value is Sort {
  return sortSchema.safeParse(value).success
}
