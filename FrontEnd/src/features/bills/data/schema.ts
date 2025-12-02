import { z } from 'zod'

// ============================================================================
// Bill Status Schema
// ============================================================================

export const billStatusSchema = z.enum(['pending', 'paid', 'overdue', 'cancelled'])
export type BillStatus = z.infer<typeof billStatusSchema>

// ============================================================================
// Bill Schema
// ============================================================================

export const billSchema = z.object({
  id: z.string(),
  billNumber: z.string(),
  customerName: z.string(),
  customerId: z.string(),
  amount: z.number().nonnegative(),
  status: billStatusSchema,
  dueDate: z.coerce.date(),
  paidDate: z.coerce.date().nullable(),
  description: z.string(),
  createdAt: z.coerce.date(),
  updatedAt: z.coerce.date(),
})

export type Bill = z.infer<typeof billSchema>

// ============================================================================
// Bill List Schema
// ============================================================================

export const billListSchema = z.array(billSchema)
