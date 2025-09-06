import type {CellContext, ColumnDef} from "@tanstack/vue-table";

export class ColumnBuilder<T> {
    private _column: ColumnDef<T> = {} as ColumnDef<T>;

    constructor(column: ColumnDef<T>) {
        this._column = column;
    }

    public WithAccessorKey(key: string & keyof T): ColumnBuilder<T> {
        this._column.accessorKey = key;

        return this;
    }

    public WithCell(cell: string | ((props: CellContext<T, unknown>) => any)): ColumnBuilder<T> {
        this._column.cell = cell;

        return this;
    }

    public WithHeader(header: string): ColumnBuilder<T> {
        this._column.header = header;

        return this;
    }
}