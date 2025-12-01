import { type ColumnDef } from '@tanstack/react-table'

export interface IRichTableProps {
  Source: string | [],
  Columns: ColumnDef<unknown>[],
  EnableRowSelection: boolean,
}
