import type { AsyncData } from "#app";

const CONTROLLER_URL = "http://localhost:8081/customer";

const getUrl = (url: string) => `${CONTROLLER_URL}/${url}`;

const searchUsersEndpoint = "search";

export const CustomerService = {
  search: (): AsyncData<any, any> => {
    return useFetch(getUrl(searchUsersEndpoint));
  },
};
