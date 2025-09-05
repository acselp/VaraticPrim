import type {CustomerModel} from "@/pages/admin/customer/type.ts";
import type {ColumnDef} from "@tanstack/vue-table";

export const columns: ColumnDef<CustomerModel>[] = [
    {
        accessorKey: "Id",
        header: "Id",
        cell: ({row}) => row.getValue("Id")
    },
    {
        accessorKey: "FirstName",
        header: "First Name",
        cell: ({row}) => row.getValue("FirstName")
    },
    {
        accessorKey: "LastName",
        header: "Last Name",
        cell: ({row}) => row.getValue("LastName")
    },
    {
        accessorKey: "Email",
        header: "Email",
        cell: ({row}) => row.getValue("Email")
    },
    {
        accessorKey: "Phone",
        header: "Phone",
        cell: ({row}) => row.getValue("Phone")
    },
    {
        accessorKey: "Mobile",
        header: "Mobile",
        cell: ({row}) => row.getValue("Mobile")
    },
];