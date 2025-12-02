import { getRouteApi } from '@tanstack/react-router'
import { Checkbox } from '@/components/ui/checkbox'
import { Badge } from '@/components/ui/badge'
import { DataTableColumnHeader } from '@/components/data-table'
import { RichTable, type RichTableSchema, RichTableRowActions } from '@/components/rich-table'
import { labels, priorities, statuses } from '../data/data'
import { type Task } from '../data/schema'
import { useTasks } from './tasks-provider'
import { Download, Trash2, CircleArrowUp, ArrowUpDown } from 'lucide-react'
import { toast } from 'sonner'
import { sleep } from '@/lib/utils'
import { TasksMultiDeleteDialog } from './tasks-multi-delete-dialog'

const route = getRouteApi('/_authenticated/tasks/')

type TasksTableProps = {
  data: Task[]
}

export function TasksTable({ data }: TasksTableProps) {
  const { setOpen, setCurrentRow } = useTasks()

  // Define row actions first (to avoid circular reference)
  const rowActionsConfig: RichTableSchema<Task>['rowActions'] = [
    {
      label: 'Edit',
      onClick: (task) => {
        setCurrentRow(task)
        setOpen('update')
      },
    },
    {
      label: 'Make a copy',
      onClick: () => {},
      disabled: () => true,
    },
    {
      label: 'Favorite',
      onClick: () => {},
      disabled: () => true,
    },
    {
      label: 'Labels',
      separator: true,
      subActions: labels.map((label) => ({
        label: label.label,
        value: label.value,
        onClick: (task, value) => {
          console.log('Update label for task:', task, 'to:', value)
        },
      })),
    },
    {
      label: 'Delete',
      icon: Trash2,
      variant: 'destructive',
      onClick: (task) => {
        setCurrentRow(task)
        setOpen('delete')
      },
    },
  ]

  // Create the schema configuration
  const schema: RichTableSchema<Task> = {
    dataSource: data,

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
      // ID column
      {
        accessorKey: 'id',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Task' />
        ),
        cell: ({ row }) => <div className='w-[80px]'>{row.getValue('id')}</div>,
        enableSorting: false,
        enableHiding: false,
      },
      // Title column
      {
        accessorKey: 'title',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Title' />
        ),
        meta: { className: 'ps-1', tdClassName: 'ps-4' },
        cell: ({ row }) => {
          const label = labels.find((label) => label.value === row.original.label)

          return (
            <div className='flex space-x-2'>
              {label && <Badge variant='outline'>{label.label}</Badge>}
              <span className='max-w-32 truncate font-medium sm:max-w-72 md:max-w-[31rem]'>
                {row.getValue('title')}
              </span>
            </div>
          )
        },
      },
      // Status column
      {
        accessorKey: 'status',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Status' />
        ),
        meta: { className: 'ps-1', tdClassName: 'ps-4' },
        cell: ({ row }) => {
          const status = statuses.find(
            (status) => status.value === row.getValue('status')
          )

          if (!status) {
            return null
          }

          return (
            <div className='flex w-[100px] items-center gap-2'>
              {status.icon && (
                <status.icon className='text-muted-foreground size-4' />
              )}
              <span>{status.label}</span>
            </div>
          )
        },
        filterFn: (row, id, value) => {
          return value.includes(row.getValue(id))
        },
      },
      // Priority column
      {
        accessorKey: 'priority',
        header: ({ column }) => (
          <DataTableColumnHeader column={column} title='Priority' />
        ),
        meta: { className: 'ps-1', tdClassName: 'ps-3' },
        cell: ({ row }) => {
          const priority = priorities.find(
            (priority) => priority.value === row.getValue('priority')
          )

          if (!priority) {
            return null
          }

          return (
            <div className='flex items-center gap-2'>
              {priority.icon && (
                <priority.icon className='text-muted-foreground size-4' />
              )}
              <span>{priority.label}</span>
            </div>
          )
        },
        filterFn: (row, id, value) => {
          return value.includes(row.getValue(id))
        },
      },
      // Actions column
      {
        id: 'actions',
        cell: ({ row }) => (
          <RichTableRowActions row={row} actions={rowActionsConfig || []} />
        ),
      },
    ],

    // Filter configuration
    filters: {
      globalFilter: {
        enabled: true,
        key: 'filter',
        filterFn: (row, _columnId, filterValue) => {
          const id = String(row.getValue('id')).toLowerCase()
          const title = String(row.getValue('title')).toLowerCase()
          const searchValue = String(filterValue).toLowerCase()

          return id.includes(searchValue) || title.includes(searchValue)
        },
      },
      columnFilters: [
        {
          columnId: 'status',
          searchKey: 'status',
          type: 'array',
          title: 'Status',
          options: statuses,
        },
        {
          columnId: 'priority',
          searchKey: 'priority',
          type: 'array',
          title: 'Priority',
          options: priorities,
        },
      ],
    },

    // Row actions configuration
    rowActions: rowActionsConfig,

    // Bulk actions configuration
    bulkActions: {
      entityName: 'task',
      actions: [
        {
          id: 'update-status',
          label: 'Update status',
          icon: CircleArrowUp,
          dropdownOptions: {
            options: statuses,
            onSelect: (status, selectedTasks, table) => {
              toast.promise(sleep(2000), {
                loading: 'Updating status...',
                success: () => {
                  table.resetRowSelection()
                  return `Status updated to "${status}" for ${selectedTasks.length} task${selectedTasks.length > 1 ? 's' : ''}.`
                },
                error: 'Error',
              })
              table.resetRowSelection()
            },
          },
        },
        {
          id: 'update-priority',
          label: 'Update priority',
          icon: ArrowUpDown,
          dropdownOptions: {
            options: priorities,
            onSelect: (priority, selectedTasks, table) => {
              toast.promise(sleep(2000), {
                loading: 'Updating priority...',
                success: () => {
                  table.resetRowSelection()
                  return `Priority updated to "${priority}" for ${selectedTasks.length} task${selectedTasks.length > 1 ? 's' : ''}.`
                },
                error: 'Error',
              })
              table.resetRowSelection()
            },
          },
        },
        {
          id: 'export',
          label: 'Export tasks',
          icon: Download,
          onClick: (selectedTasks, table) => {
            toast.promise(sleep(2000), {
              loading: 'Exporting tasks...',
              success: () => {
                table.resetRowSelection()
                return `Exported ${selectedTasks.length} task${selectedTasks.length > 1 ? 's' : ''} to CSV.`
              },
              error: 'Error',
            })
            table.resetRowSelection()
          },
        },
        {
          id: 'delete',
          label: 'Delete selected tasks',
          icon: Trash2,
          variant: 'destructive',
          dialogKey: 'delete',
        },
      ],
      dialogs: {
        delete: TasksMultiDeleteDialog,
      },
    },

    // Pagination configuration
    pagination: {
      defaultPage: 1,
      defaultPageSize: 10,
      pageSizeOptions: [10, 20, 30, 40, 50],
    },

    // Toolbar configuration
    toolbar: {
      searchPlaceholder: 'Filter by title or ID...',
      showViewOptions: true,
      showFilters: true,
    },
  }

  return <RichTable schema={schema} />
}
