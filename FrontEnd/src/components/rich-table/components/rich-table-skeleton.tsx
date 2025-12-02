import { Skeleton } from '@/components/ui/skeleton'
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table'

type RichTableSkeletonProps = {
  /**
   * Number of columns to display
   */
  columns?: number

  /**
   * Number of rows to display
   */
  rows?: number
}

/**
 * Loading skeleton for RichTable
 * Displays while data is being fetched from backend
 */
export function RichTableSkeleton({
  columns = 6,
  rows = 10,
}: RichTableSkeletonProps) {
  return (
    <div className='space-y-4'>
      {/* Toolbar skeleton */}
      <div className='flex items-center justify-between'>
        <div className='flex flex-1 items-center space-x-2'>
          <Skeleton className='h-8 w-[250px]' />
          <Skeleton className='h-8 w-[120px]' />
          <Skeleton className='h-8 w-[120px]' />
        </div>
        <Skeleton className='h-8 w-[70px]' />
      </div>

      {/* Table skeleton */}
      <div className='overflow-hidden rounded-md border'>
        <Table>
          <TableHeader>
            <TableRow>
              {Array.from({ length: columns }).map((_, i) => (
                <TableHead key={i}>
                  <Skeleton className='h-4 w-full' />
                </TableHead>
              ))}
            </TableRow>
          </TableHeader>
          <TableBody>
            {Array.from({ length: rows }).map((_, rowIndex) => (
              <TableRow key={rowIndex}>
                {Array.from({ length: columns }).map((_, colIndex) => (
                  <TableCell key={colIndex}>
                    <Skeleton className='h-4 w-full' />
                  </TableCell>
                ))}
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>

      {/* Pagination skeleton */}
      <div className='flex items-center justify-between'>
        <Skeleton className='h-8 w-[200px]' />
        <div className='flex items-center space-x-2'>
          <Skeleton className='h-8 w-8' />
          <Skeleton className='h-8 w-8' />
          <Skeleton className='h-8 w-8' />
          <Skeleton className='h-8 w-8' />
          <Skeleton className='h-8 w-8' />
        </div>
      </div>
    </div>
  )
}
