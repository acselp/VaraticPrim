import type {IActionsConfig, ITableRowActions} from "@/components/admin/data-table/types.ts";
import {ActionConfig} from "@/components/admin/data-table/schema/ActionConfig.ts";
import {RowActionConfigBuilder} from "@/components/admin/data-table/builders/RowActionConfigBuilder.ts";

export class ActionConfigBuilder<T> {
    private _actionConfig: IActionsConfig<T> = new ActionConfig();

    constructor(actionConfig: IActionsConfig<T>) {
        this._actionConfig = actionConfig;
    }

    public WithRowActionsConfig(builderCb: ((builder: RowActionConfigBuilder<T>) => void)): ActionConfigBuilder<T> {
        builderCb(new RowActionConfigBuilder(this._actionConfig.rowActions));

        return this;
    }

    public Build() {
        return this._actionConfig;
    }
}