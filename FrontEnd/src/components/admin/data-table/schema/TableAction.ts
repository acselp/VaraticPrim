import type {ITableAction, TableActionCb} from "@/components/admin/data-table/types.ts";

export class TableAction<T> implements ITableAction<T> {
    action: TableActionCb<T>;
    buttonSlot: TableActionCb<T>;
    class: TableActionCb<T>;
}