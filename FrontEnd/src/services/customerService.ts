const BASE_URL = "/Customer/"

const getAllEndpoint = "GridGetAll"

const getFullUrl = (endpoint: string) => `${BASE_URL}${endpoint}`;

export const CustomerService = {
    getAllUrl() {
        return getFullUrl(getAllEndpoint);
    }
}