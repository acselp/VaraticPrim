import { useState } from 'react'
import { getRouteApi } from '@tanstack/react-router'
import { RichTable, type RichTableSchema } from '@/components/rich-table'
import { type Customer } from '@/features/customers/data/schema.ts'
import { getSchema } from '@/features/customers/table-schema.tsx'

const route = getRouteApi('/_authenticated/customers/')

export function Customers() {
  const [schema] = useState<RichTableSchema<Customer>>(getSchema(route))

  return <RichTable schema={schema} />
}
