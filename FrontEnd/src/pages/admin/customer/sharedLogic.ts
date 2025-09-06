import {router} from "@/router";

export const goToCustomerEditPage = (id: number) => {
    router.push(`/admin/customer/${id}`);
}