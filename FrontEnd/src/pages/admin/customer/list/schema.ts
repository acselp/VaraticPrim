import type { CustomerModel } from "@/pages/admin/customer/type.ts";
import { TableSchemaBuilder } from "@/components/admin/data-table/builders/TableSchemaBuilder.ts";
import type { ColumnConfigBuilder } from "@/components/admin/data-table/builders/ColumnConfigBuilder.ts";
import type { ActionConfigBuilder } from "@/components/admin/data-table/builders/ActionConfigBuilder.ts";
import { buttonVariants } from "@/components/ui/button";


export const getSchema = () => {
    return new TableSchemaBuilder<CustomerModel>()
        .WithColumnsConfig(getColumns())
        .WithActionsConfig(getActions())
        .Build();
}

const getActions = () => {
    return (builder: ActionConfigBuilder<CustomerModel>) =>
        builder
            .WithRowActionsConfig(builder =>
                builder
                    .AddAction(builder =>
                        builder
                            .WithButtonSlot("Edit")
                            .WithAction(() => {
                            })
                    )
                    .AddAction(builder =>
                        builder
                            .WithButtonSlot("Delete")
                            .WithAction(() => {
                            })
                            .WithClass(buttonVariants({ variant: 'destructive' }))
                    )
            )
}

const getColumns = () => {
    return (builder: ColumnConfigBuilder<CustomerModel>) =>
        builder
            .AddColumn((builder) => builder
                .WithCell(({ row }) => row.getValue("Id"))
                .WithAccessorKey("Id")
                .WithHeader("Id")
            )
            .AddColumn((builder) => builder
                .WithCell(({ row }) => row.getValue("AccountNr"))
                .WithAccessorKey("AccountNr")
                .WithHeader("AccountNr")
            )
            .AddColumn((builder) => builder
                .WithCell(({ row }) => row.getValue("FirstName"))
                .WithAccessorKey("FirstName")
                .WithHeader("FirstName")
            )
            .AddColumn((builder) => builder
                .WithCell(({ row }) => row.getValue("LastName"))
                .WithAccessorKey("LastName")
                .WithHeader("LastName")
            )
            .AddColumn((builder) => builder
                .WithCell(({ row }) => row.getValue("Phone"))
                .WithAccessorKey("Phone")
                .WithHeader("Phone")
            )
            .AddColumn((builder) => builder
                .WithCell(({ row }) => row.getValue("Mobile"))
                .WithAccessorKey("Mobile")
                .WithHeader("Mobile")
            )
}
