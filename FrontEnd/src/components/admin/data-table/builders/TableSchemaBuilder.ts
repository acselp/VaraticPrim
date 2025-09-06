import type {IActionsConfig, IColumnsConfig, ITableSchema} from "@/components/admin/data-table/types.ts";
import TableSchema from "@/components/admin/data-table/schema/TableSchema.ts";
import {ColumnConfigBuilder} from "@/components/admin/data-table/builders/ColumnConfigBuilder.ts";
import {ActionConfigBuilder} from "@/components/admin/data-table/builders/ActionConfigBuilder.ts";

export class TableSchemaBuilder<T> {
    private _schema: ITableSchema<T> = new TableSchema<T>();

    public WithColumnsConfig(builderCb: ((builder: ColumnConfigBuilder<T>) => void)): TableSchemaBuilder<T> {
        builderCb(new ColumnConfigBuilder<T>(this._schema.columnConfig));

        return this;
    }

    public WithActionsConfig(builderCb: ((builder: ActionConfigBuilder<T>) => void)): TableSchemaBuilder<T> {
        builderCb(new ActionConfigBuilder<T>(this._schema.actionConfig));

        return this;
    }

    public Build() {
        return this._schema;
    }
}