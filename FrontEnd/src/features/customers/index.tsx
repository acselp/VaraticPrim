import { getRouteApi } from '@tanstack/react-router'
import { Checkbox } from '@/components/ui/checkbox'
import { Badge } from '@/components/ui/badge'
import { DataTableColumnHeader } from '@/components/data-table'
import { RichTable, type RichTableSchema, RichTableRowActions } from '@/components/rich-table'
import { customerStatuses } from './data/data'
import { type Customer } from './data/schema'
import { customersData } from './data/customers'
import { Mail, Phone, Trash2, Edit } from 'lucide-react'
import { toast } from 'sonner'

const route = getRouteApi('/_authenticated/customers/')

export function Customers() {
  // Row actions configuration
  const rowActionsConfig: RichTableSchema<Customer>['rowActions'] = [
    {
      label: 'Edit',
      icon: Edit,
      onClick: (customer) => {
        toast.info(`Edit customer: ${customer.name}`)
      },
    },
    {
      label: 'Send Email',
      icon: Mail,
      onClick: (customer) => {
        toast.info(`Send email to: ${customer.email}`)
      },
    },
    {
      label: 'Call',
      icon: Phone,
      onClick: (customer) => {
        toast.info(`Call: ${customer.phone}`)
      },
    },
    {
      label: 'Delete',
      icon: Trash2,
      variant: 'destructive',
      separator: true,
      onClick: (customer) => {
        toast.error(`Delete customer: ${customer.name}`)
      },
    },
  ]

  // Create the schema configuration (FRONTEND STRATEGY)
  const schema: RichTableSchema<Customer> = {
    // Frontend strategy - pass array of data directly
    dataSource: customersData,

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
      // Name column
      {
        accessorKey: 'name',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Name' />
        ),
        cell: ({ row }) => (
          <div className='font-medium'>{row.getValue('name')}</div>
        ),
      },
      // Email column
      {
        accessorKey: 'email',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Email' />
        ),
        cell: ({ row }) => (
          <div className='text-muted-foreground'>{row.getValue('email')}</div>
        ),
      },
      // Phone column
      {
        accessorKey: 'phone',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Phone' />
        ),
      },
      // City column
      {
        accessorKey: 'city',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='City' />
        ),
      },
      // Status column
      {
        accessorKey: 'status',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Status' />
        ),
        cell: ({ row }) => {
          const status = customerStatuses.find(
            (s) => s.value === row.getValue('status')
          )

          if (!status) return null

          return (
            <div className='flex items-center gap-2'>
              {status.icon && (
                <status.icon className='text-muted-foreground size-4' />
              )}
              <Badge variant={status.value === 'active' ? 'default' : 'outline'}>
                {status.label}
              </Badge>
            </div>
          )
        },
        filterFn: (row, id, value) => {
          return value.includes(row.getValue(id))
        },
      },
      // Total Orders column
      {
        accessorKey: 'totalOrders',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Orders' />
        ),
        cell: ({ row }) => (
          <div className='text-center'>{row.getValue('totalOrders')}</div>
        ),
      },
      // Total Spent column
      {
        accessorKey: 'totalSpent',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Total Spent' />
        ),
        cell: ({ row }) => {
          const amount = parseFloat(row.getValue('totalSpent'))
          const formatted = new Intl.NumberFormat('en-US', {
            style: 'currency',
            currency: 'USD',
          }).format(amount)

          return <div className='font-medium'>{formatted}</div>
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
        filterFn: (row, _columnId, filterValue) => {
          const name = String(row.getValue('name')).toLowerCase()
          const email = String(row.getValue('email')).toLowerCase()
          const phone = String(row.getValue('phone')).toLowerCase()
          const city = String(row.getValue('city')).toLowerCase()
          const searchValue = String(filterValue).toLowerCase()

          return (
            name.includes(searchValue) ||
            email.includes(searchValue) ||
            phone.includes(searchValue) ||
            city.includes(searchValue)
          )
        },
      },
      columnFilters: [
        {
          columnId: 'status',
          searchKey: 'status',
          type: 'array',
          title: 'Status',
          options: customerStatuses,
        },
      ],
    },

    // Row actions configuration
    rowActions: rowActionsConfig,

    // Bulk actions configuration
    bulkActions: {
      entityName: 'customer',
      actions: [
        {
          id: 'export',
          label: 'Export selected',
          icon: Mail,
          onClick: (selectedCustomers, table) => {
            toast.success(`Exported ${selectedCustomers.length} customer(s)`)
            table.resetRowSelection()
          },
        },
        {
          id: 'delete',
          label: 'Delete selected',
          icon: Trash2,
          variant: 'destructive',
          onClick: (selectedCustomers, table) => {
            toast.error(`Deleted ${selectedCustomers.length} customer(s)`)
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
      searchPlaceholder: 'Search customers by name, email, phone, or city...',
      showViewOptions: true,
      showFilters: true,
    },
  }

  return (
    // <ContentLayout title='Customers'>
      <RichTable schema={schema} />
    // </ContentLayout>
  )
}
