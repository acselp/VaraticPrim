import { CheckCircle, Circle, Clock } from 'lucide-react'

export const customerStatuses = [
  {
    label: 'Active',
    value: 'active' as const,
    icon: CheckCircle,
  },
  {
    label: 'Inactive',
    value: 'inactive' as const,
    icon: Circle,
  },
  {
    label: 'Pending',
    value: 'pending' as const,
    icon: Clock,
  },
]
