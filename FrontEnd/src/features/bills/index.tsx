import { getRouteApi } from '@tanstack/react-router'
import { Checkbox } from '@/components/ui/checkbox'
import { Badge } from '@/components/ui/badge'
import { DataTableColumnHeader } from '@/components/data-table'
import { RichTable, type RichTableSchema, RichTableRowActions } from '@/components/rich-table'
import { billStatuses } from './data/data'
import { type Bill, billSchema } from './data/schema'
import { Trash2, Edit, Eye, Download, CheckCircle } from 'lucide-react'
import { toast } from 'sonner'
import { createFilterMappings, createSortMappings } from '@/lib/utils/url-to-grid-command'
import { format } from 'date-fns'

const route = getRouteApi('/_authenticated/bills/')

export function Bills() {
  // Row actions configuration
  const rowActionsConfig: RichTableSchema<Bill>['rowActions'] = [
    {
      label: 'View Details',
      icon: Eye,
      onClick: (bill) => {
        toast.info(`View bill: ${bill.billNumber}`)
      },
    },
    {
      label: 'Edit',
      icon: Edit,
      onClick: (bill) => {
        toast.info(`Edit bill: ${bill.billNumber}`)
      },
    },
    {
      label: 'Mark as Paid',
      icon: CheckCircle,
      onClick: (bill) => {
        toast.success(`Marked bill ${bill.billNumber} as paid`)
      },
      disabled: (bill) => bill.status === 'paid' || bill.status === 'cancelled',
    },
    {
      label: 'Download PDF',
      icon: Download,
      separator: true,
      onClick: (bill) => {
        toast.info(`Download bill: ${bill.billNumber}`)
      },
    },
    {
      label: 'Delete',
      icon: Trash2,
      variant: 'destructive',
      onClick: (bill) => {
        toast.error(`Delete bill: ${bill.billNumber}`)
      },
    },
  ]

  // Create the schema configuration (BACKEND STRATEGY)
  const schema: RichTableSchema<Bill> = {
    // Backend strategy - API endpoint configuration
    dataSource: {
      url: '/api/bills/search',
      method: 'POST',
      dataSchema: billSchema,
    },

    // Router configuration for URL state
    router: {
      search: route.useSearch(),
      navigate: route.useNavigate(),
    },

    // Column definitions
    columns: [
      // Select column
      {
        id: 'select',
        header: ({ table }) => (
          <Checkbox
            checked={
              table.getIsAllPageRowsSelected() ||
              (table.getIsSomePageRowsSelected() && 'indeterminate')
            }
            onCheckedChange={(value) => table.toggleAllPageRowsSelected(!!value)}
            aria-label='Select all'
            className='translate-y-[2px]'
          />
        ),
        cell: ({ row }) => (
          <Checkbox
            checked={row.getIsSelected()}
            onCheckedChange={(value) => row.toggleSelected(!!value)}
            aria-label='Select row'
            className='translate-y-[2px]'
          />
        ),
        enableSorting: false,
        enableHiding: false,
      },
      // Bill Number column
      {
        accessorKey: 'billNumber',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Bill #' />
        ),
        cell: ({ row }) => (
          <div className='font-mono font-medium'>{row.getValue('billNumber')}</div>
        ),
      },
      // Customer Name column
      {
        accessorKey: 'customerName',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Customer' />
        ),
        cell: ({ row }) => (
          <div className='font-medium'>{row.getValue('customerName')}</div>
        ),
      },
      // Amount column
      {
        accessorKey: 'amount',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Amount' />
        ),
        cell: ({ row }) => {
          const amount = parseFloat(row.getValue('amount'))
          const formatted = new Intl.NumberFormat('en-US', {
            style: 'currency',
            currency: 'USD',
          }).format(amount)

          return <div className='font-medium'>{formatted}</div>
        },
      },
      // Status column
      {
        accessorKey: 'status',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Status' />
        ),
        cell: ({ row }) => {
          const status = billStatuses.find(
            (s) => s.value === row.getValue('status')
          )

          if (!status) return null

          const variantMap = {
            paid: 'default' as const,
            pending: 'secondary' as const,
            overdue: 'destructive' as const,
            cancelled: 'outline' as const,
          }

          return (
            <div className='flex items-center gap-2'>
              {status.icon && (
                <status.icon className='text-muted-foreground size-4' />
              )}
              <Badge variant={variantMap[status.value]}>
                {status.label}
              </Badge>
            </div>
          )
        },
        filterFn: (row, id, value) => {
          return value.includes(row.getValue(id))
        },
      },
      // Due Date column
      {
        accessorKey: 'dueDate',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Due Date' />
        ),
        cell: ({ row }) => {
          const date = row.getValue('dueDate') as Date
          return (
            <div className='text-muted-foreground'>
              {format(date, 'MMM dd, yyyy')}
            </div>
          )
        },
      },
      // Created At column
      {
        accessorKey: 'createdAt',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Created' />
        ),
        cell: ({ row }) => {
          const date = row.getValue('createdAt') as Date
          return (
            <div className='text-muted-foreground text-sm'>
              {format(date, 'MMM dd, yyyy')}
            </div>
          )
        },
      },
      // Actions column
      {
        id: 'actions',
        cell: ({ row }) => (
          <RichTableRowActions row={row} actions={rowActionsConfig} />
        ),
      },
    ],

    // Filter configuration
    filters: {
      globalFilter: {
        enabled: true,
        key: 'filter',
        // For backend strategy, filterFn is not used (backend handles it)
      },
      columnFilters: [
        {
          columnId: 'status',
          searchKey: 'status',
          type: 'array',
          title: 'Status',
          options: billStatuses,
        },
      ],
    },

    // Backend configuration - map frontend fields to backend fields
    backend: {
      columnFilterMappings: createFilterMappings([
        { columnId: 'status', field: 'Status', operator: 'in' },
      ]),
      sortMappings: createSortMappings([
        { columnId: 'billNumber', field: 'BillNumber' },
        { columnId: 'customerName', field: 'CustomerName' },
        { columnId: 'amount', field: 'Amount' },
        { columnId: 'status', field: 'Status' },
        { columnId: 'dueDate', field: 'DueDate' },
        { columnId: 'createdAt', field: 'CreatedAt' },
      ]),
    },

    // Row actions configuration
    rowActions: rowActionsConfig,

    // Bulk actions configuration
    bulkActions: {
      entityName: 'bill',
      actions: [
        {
          id: 'mark-paid',
          label: 'Mark as Paid',
          icon: CheckCircle,
          onClick: (selectedBills, table) => {
            toast.success(`Marked ${selectedBills.length} bill(s) as paid`)
            table.resetRowSelection()
          },
        },
        {
          id: 'export',
          label: 'Export selected',
          icon: Download,
          onClick: (selectedBills, table) => {
            toast.success(`Exported ${selectedBills.length} bill(s)`)
            table.resetRowSelection()
          },
        },
        {
          id: 'delete',
          label: 'Delete selected',
          icon: Trash2,
          variant: 'destructive',
          onClick: (selectedBills, table) => {
            toast.error(`Deleted ${selectedBills.length} bill(s)`)
            table.resetRowSelection()
          },
        },
      ],
    },

    // Pagination configuration
    pagination: {
      defaultPage: 1,
      defaultPageSize: 10,
      pageSizeOptions: [10, 20, 30, 40, 50],
    },

    // Toolbar configuration
    toolbar: {
      searchPlaceholder: 'Search bills by number, customer, or description...',
      showViewOptions: true,
      showFilters: true,
    },
  }

  return (
      <RichTable schema={schema} />
  )
}
