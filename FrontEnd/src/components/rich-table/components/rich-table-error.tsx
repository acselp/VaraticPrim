import { AlertCircle, RefreshCcw } from 'lucide-react'
import { Button } from '@/components/ui/button'
import { Alert, AlertDescription, AlertTitle } from '@/components/ui/alert'

type RichTableErrorProps = {
  /**
   * The error object
   */
  error: Error

  /**
   * Retry function to refetch data
   */
  retry: () => void
}

/**
 * Error state component for RichTable
 * Displays when backend API request fails
 */
export function RichTableError({ error, retry }: RichTableErrorProps) {
  return (
    <div className='flex min-h-[400px] items-center justify-center p-8'>
      <Alert variant='destructive' className='max-w-lg'>
        <AlertCircle className='h-4 w-4' />
        <AlertTitle>Failed to load data</AlertTitle>
        <AlertDescription className='mt-2 space-y-4'>
          <p className='text-sm'>
            {error.message || 'An unexpected error occurred while fetching data.'}
          </p>
          <Button
            variant='outline'
            size='sm'
            onClick={retry}
            className='gap-2'
          >
            <RefreshCcw className='h-4 w-4' />
            Try again
          </Button>
        </AlertDescription>
      </Alert>
    </div>
  )
}
