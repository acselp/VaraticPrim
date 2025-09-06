import type {IActionsConfig, ITableRowActions} from "@/components/admin/data-table/types.ts";
import {TableRowActions} from "@/components/admin/data-table/schema/TableRowActions.ts";

export class ActionConfig<T> implements IActionsConfig<T> {
    rowActions: ITableRowActions<T> = new TableRowActions<T>();
}