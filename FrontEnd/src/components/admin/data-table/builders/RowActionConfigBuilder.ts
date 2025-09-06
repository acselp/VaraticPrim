import type {ITableAction, ITableRowActions} from "@/components/admin/data-table/types.ts";
import {ActionBuilder} from "@/components/admin/data-table/builders/ActionBuilder.ts";
import {TableRowActions} from "@/components/admin/data-table/schema/TableRowActions.ts";

export class RowActionConfigBuilder<T> {
    private _rowActionConfig: ITableRowActions<T> = new TableRowActions();

    constructor(rowActionConfig: ITableRowActions<T>) {
        this._rowActionConfig = rowActionConfig;
    }

    public AddAction(builderCb: ((builder: ActionBuilder<T>) => void)): RowActionConfigBuilder<T> {
        let action: ITableAction<T> = {} as ITableAction<T>;
        builderCb(new ActionBuilder<T>(action))

        this._rowActionConfig.actions.push(action)

        return this;
    }
}