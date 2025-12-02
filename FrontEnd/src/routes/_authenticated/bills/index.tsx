import { z } from 'zod'
import { createFileRoute } from '@tanstack/react-router'
import { Bills } from '@/features/bills'

const billsSearchSchema = z.object({
  page: z.number().optional().catch(1),
  pageSize: z.number().optional().catch(10),
  // Global filter
  filter: z.string().optional().catch(''),
  // Faceted status filter
  status: z
    .array(z.enum(['pending', 'paid', 'overdue', 'cancelled']))
    .optional()
    .catch([]),
})

export const Route = createFileRoute('/_authenticated/bills/')({
  validateSearch: billsSearchSchema,
  component: Bills,
})
