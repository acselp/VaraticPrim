import type { ITableAction, TableActionValue } from "@/components/admin/data-table/types.ts";

export class TableAction<T> implements ITableAction<T> {
    action: TableActionValue<T>;
    buttonSlot: TableActionValue<T>;
    class: TableActionValue<T>;
}
