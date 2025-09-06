import type {IActionsConfig, IColumnsConfig, ITableSchema} from "@/components/admin/data-table/types.ts";
import {ActionConfig} from "@/components/admin/data-table/schema/ActionConfig.ts";
import {ColumnConfig} from "@/components/admin/data-table/schema/ColumnConfig.ts";

export default class TableSchema<T> implements ITableSchema<T> {
    public actionConfig: IActionsConfig<T>;
    public columnConfig: IColumnsConfig<T>;

    constructor() {
        this.actionConfig = new ActionConfig<T>();
        this.columnConfig = new ColumnConfig<T>();
    }
}