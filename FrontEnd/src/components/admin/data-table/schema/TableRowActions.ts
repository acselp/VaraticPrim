import type {ITableAction, ITableRowActions} from "@/components/admin/data-table/types.ts";

export class TableRowActions<T> implements ITableRowActions<T> {
    actions: ITableAction<T>[] = [];
}