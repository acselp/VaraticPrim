import type {ITableAction, TableActionCb} from "@/components/admin/data-table/types.ts";

export class ActionBuilder<T> {
    private _action: ITableAction<T> = {} as ITableAction<T>;

    constructor(action: ITableAction<T>) {
        this._action = action;
    }

    public WithAction(action: TableActionCb<T>): ActionBuilder<T> {
        this._action.action = action;

        return this;
    }

    public WithButtonSlot(buttonSlot: TableActionCb<T>): ActionBuilder<T> {
        this._action.buttonSlot = buttonSlot;

        return this;
    }

    public WithClass(classAttr: TableActionCb<T>): ActionBuilder<T> {
        this._action.class = classAttr;

        return this;
    }
}