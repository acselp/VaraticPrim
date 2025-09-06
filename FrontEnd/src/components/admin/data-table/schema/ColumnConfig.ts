import type {IColumnsConfig} from "@/components/admin/data-table/types.ts";
import type {ColumnDef} from "@tanstack/vue-table";

export class ColumnConfig<T> implements IColumnsConfig<T> {
    columnList: ColumnDef<T>[] = [];
}