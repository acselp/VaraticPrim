import { type IRichTableProps } from '@/components/rich-table/types.ts'
import { RichTableService } from '@/services/rich-teble-service.ts'
import { useState } from 'react'
import { toast } from 'sonner'

export interface ITableSourceProps {
  data: unknown[],
  isLoading: boolean
}

export const useTableSource = (schema: IRichTableProps): ITableSourceProps => {
  if (Array.isArray(schema.Source)) {
    return setupFrontendSource(schema)
  }
  else {
    return setupBackendSource(schema)
  }
}

export const setupBackendSource = (schema: IRichTableProps) => {
  const [data, setData] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  RichTableService.search(schema.Source as string)
    .then(res => {
      setData(res.data);
    })
    .catch(err => {
      toast.error(err.message)
    })
    .finally(() => {
      setIsLoading(false);
    })

  return { data, isLoading };
}

export const setupFrontendSource = (schema: IRichTableProps) => {
  return { data: schema.Source as [], isLoading: false };
}
