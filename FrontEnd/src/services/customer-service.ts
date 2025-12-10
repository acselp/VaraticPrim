import { getUrl } from '@/config/api.ts'

const CUSTOMER_CONTROLLER = "api/Customer";

const getAbsoluteUrl = (endpoint: string) => getUrl(`${CUSTOMER_CONTROLLER}/${endpoint}`)

const getAllEndpoint = "GetAll";

export const CustomerService = {
  getAllPaginatedUrl: () => {
    return getAbsoluteUrl(getAllEndpoint)
  }
}
