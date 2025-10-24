import type { ColumnDef } from "@tanstack/vue-table";

export interface ITableSchema<T> {
    columnConfig: IColumnsConfig<T>;
    actionConfig: IActionsConfig<T>;
}

export interface IColumnsConfig<T> {
    columnList: ColumnDef<T>[];
}

export interface IActionsConfig<T> {
    rowActions: ITableRowActions<T>;
}

export interface ITableRowActions<T> {
    actions: ITableAction<T>[];
}

export type TableActionCb<T> = (data: ITableCbData<T>) => any;

export type TableActionValue<T> = (string | TableActionCb<T>);

export interface ITableAction<T> {
    action: TableActionCb<T>;
    buttonSlot: TableActionValue<T>;
    class: TableActionValue<T>;
}

export interface ITableCbData<T> {
    tableData: T[];
    row: T;
}
