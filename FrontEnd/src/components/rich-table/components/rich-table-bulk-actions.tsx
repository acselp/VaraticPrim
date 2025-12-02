import { useState } from 'react'
import { type Table } from '@tanstack/react-table'
import { Button } from '@/components/ui/button'
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu'
import {
  Tooltip,
  TooltipContent,
  TooltipTrigger,
} from '@/components/ui/tooltip'
import { DataTableBulkActions as BulkActionsToolbar } from '@/components/data-table'
import { type RichTableBulkActions } from '../types'

type RichTableBulkActionsProps<TData> = {
  table: Table<TData>
  config: RichTableBulkActions<TData>
}

export function RichTableBulkActions<TData>({
  table,
  config,
}: RichTableBulkActionsProps<TData>) {
  const [activeDialogs, setActiveDialogs] = useState<Record<string, boolean>>({})
  const selectedRows = table.getFilteredSelectedRowModel().rows
  const selectedData = selectedRows.map((row) => row.original)

  const handleDialogToggle = (dialogKey: string, open: boolean) => {
    setActiveDialogs((prev) => ({ ...prev, [dialogKey]: open }))
  }

  return (
    <>
      <BulkActionsToolbar table={table} entityName={config.entityName}>
        {config.actions.map((action) => {
          const Icon = action.icon

          // Handle dropdown actions (e.g., status/priority updates)
          if (action.dropdownOptions) {
            return (
              <DropdownMenu key={action.id}>
                <Tooltip>
                  <TooltipTrigger asChild>
                    <DropdownMenuTrigger asChild>
                      <Button
                        variant={action.variant || 'outline'}
                        size='icon'
                        className='size-8'
                        aria-label={action.label}
                        title={action.label}
                      >
                        <Icon className='h-4 w-4' />
                        <span className='sr-only'>{action.label}</span>
                      </Button>
                    </DropdownMenuTrigger>
                  </TooltipTrigger>
                  <TooltipContent>
                    <p>{action.label}</p>
                  </TooltipContent>
                </Tooltip>
                <DropdownMenuContent sideOffset={14}>
                  {action.dropdownOptions.options.map((option) => {
                    const OptionIcon = option.icon
                    return (
                      <DropdownMenuItem
                        key={option.value}
                        onClick={() =>
                          action.dropdownOptions!.onSelect(
                            option.value,
                            selectedData,
                            table
                          )
                        }
                      >
                        {OptionIcon && (
                          <OptionIcon className='text-muted-foreground mr-2 size-4' />
                        )}
                        {option.label}
                      </DropdownMenuItem>
                    )
                  })}
                </DropdownMenuContent>
              </DropdownMenu>
            )
          }

          // Handle dialog-triggering actions
          if (action.dialogKey && config.dialogs?.[action.dialogKey]) {
            return (
              <Tooltip key={action.id}>
                <TooltipTrigger asChild>
                  <Button
                    variant={action.variant || 'outline'}
                    size='icon'
                    onClick={() => handleDialogToggle(action.dialogKey!, true)}
                    className='size-8'
                    aria-label={action.label}
                    title={action.label}
                  >
                    <Icon className='h-4 w-4' />
                    <span className='sr-only'>{action.label}</span>
                  </Button>
                </TooltipTrigger>
                <TooltipContent>
                  <p>{action.label}</p>
                </TooltipContent>
              </Tooltip>
            )
          }

          // Handle regular click actions
          return (
            <Tooltip key={action.id}>
              <TooltipTrigger asChild>
                <Button
                  variant={action.variant || 'outline'}
                  size='icon'
                  onClick={() => action.onClick?.(selectedData, table)}
                  className='size-8'
                  aria-label={action.label}
                  title={action.label}
                >
                  <Icon className='h-4 w-4' />
                  <span className='sr-only'>{action.label}</span>
                </Button>
              </TooltipTrigger>
              <TooltipContent>
                <p>{action.label}</p>
              </TooltipContent>
            </Tooltip>
          )
        })}
      </BulkActionsToolbar>

      {/* Render dialogs */}
      {config.dialogs &&
        Object.entries(config.dialogs).map(([key, DialogComponent]) => (
          <DialogComponent
            key={key}
            open={activeDialogs[key] || false}
            onOpenChange={(open) => handleDialogToggle(key, open)}
            table={table}
          />
        ))}
    </>
  )
}
