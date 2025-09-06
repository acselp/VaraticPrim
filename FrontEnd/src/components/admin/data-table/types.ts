import type {ColumnDef} from "@tanstack/vue-table";

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

export type TableActionCb<T> = (string | (data: ITableCbData<T>) => any);

export interface ITableAction<T> {
    action: TableActionCb<T>;
    buttonSlot: TableActionCb<T>;
    class: TableActionCb<T>;
}

export interface ITableCbData<T> {
    tableData: T[];
    row: T;
}