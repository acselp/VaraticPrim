import type {ColumnDef, ColumnDef as ColumnDefType} from "@tanstack/vue-table";
import type {IColumnsConfig} from "@/components/admin/data-table/types.ts";
import {ColumnConfig} from "@/components/admin/data-table/schema/ColumnConfig.ts";
import {ColumnBuilder} from "@/components/admin/data-table/builders/ColumnBuilder.ts";

export class ColumnConfigBuilder<T> {
    private _columns: IColumnsConfig<T> = new ColumnConfig<T>();

    constructor(columns: IColumnsConfig<T>) {
        this._columns = columns;
    }

    public AddColumn(builderCb: ((builder: ColumnBuilder<T>) => void)): ColumnConfigBuilder<T> {
        let column: ColumnDef<T> = {} as ColumnDef<T>;
        builderCb(new ColumnBuilder<T>(column))

        this._columns.columnList.push(column);

        return this;
    }
}