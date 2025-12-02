import { CheckCircle, Clock, XCircle, AlertCircle } from 'lucide-react'

export const billStatuses = [
  {
    label: 'Pending',
    value: 'pending' as const,
    icon: Clock,
  },
  {
    label: 'Paid',
    value: 'paid' as const,
    icon: CheckCircle,
  },
  {
    label: 'Overdue',
    value: 'overdue' as const,
    icon: AlertCircle,
  },
  {
    label: 'Cancelled',
    value: 'cancelled' as const,
    icon: XCircle,
  },
]
