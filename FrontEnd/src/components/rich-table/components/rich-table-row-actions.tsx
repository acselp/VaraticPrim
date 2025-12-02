import { DotsHorizontalIcon } from '@radix-ui/react-icons'
import { type Row } from '@tanstack/react-table'
import { Button } from '@/components/ui/button'
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuRadioGroup,
  DropdownMenuRadioItem,
  DropdownMenuSeparator,
  DropdownMenuShortcut,
  DropdownMenuSub,
  DropdownMenuSubContent,
  DropdownMenuSubTrigger,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu'
import { type RichTableRowAction } from '../types'

type RichTableRowActionsProps<TData> = {
  row: Row<TData>
  actions: RichTableRowAction<TData>[]
}

export function RichTableRowActions<TData>({
  row,
  actions,
}: RichTableRowActionsProps<TData>) {
  const rowData = row.original

  return (
    <DropdownMenu modal={false}>
      <DropdownMenuTrigger asChild>
        <Button
          variant='ghost'
          className='data-[state=open]:bg-muted flex h-8 w-8 p-0'
        >
          <DotsHorizontalIcon className='h-4 w-4' />
          <span className='sr-only'>Open menu</span>
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent align='end' className='w-[160px]'>
        {actions.map((action, index) => {
          const isDisabled = action.disabled?.(rowData) ?? false
          const Icon = action.icon

          // Handle sub-actions (nested menu)
          if (action.subActions && action.subActions.length > 0) {
            return (
              <div key={`${action.label}-${index}`}>
                <DropdownMenuSub>
                  <DropdownMenuSubTrigger disabled={isDisabled}>
                    {Icon && <Icon className='mr-2 h-4 w-4' />}
                    {action.label}
                  </DropdownMenuSubTrigger>
                  <DropdownMenuSubContent>
                    <DropdownMenuRadioGroup>
                      {action.subActions.map((subAction) => (
                        <DropdownMenuRadioItem
                          key={subAction.value}
                          value={subAction.value}
                          onClick={() => subAction.onClick(rowData, subAction.value)}
                        >
                          {subAction.label}
                        </DropdownMenuRadioItem>
                      ))}
                    </DropdownMenuRadioGroup>
                  </DropdownMenuSubContent>
                </DropdownMenuSub>
                {action.separator && <DropdownMenuSeparator />}
              </div>
            )
          }

          // Handle regular actions
          return (
            <div key={`${action.label}-${index}`}>
              <DropdownMenuItem
                onClick={() => action.onClick(rowData)}
                disabled={isDisabled}
                className={
                  action.variant === 'destructive'
                    ? 'text-destructive focus:text-destructive'
                    : undefined
                }
              >
                {Icon && <Icon className='mr-2 h-4 w-4' />}
                {action.label}
                {action.shortcut && (
                  <DropdownMenuShortcut>{action.shortcut}</DropdownMenuShortcut>
                )}
              </DropdownMenuItem>
              {action.separator && <DropdownMenuSeparator />}
            </div>
          )
        })}
      </DropdownMenuContent>
    </DropdownMenu>
  )
}
