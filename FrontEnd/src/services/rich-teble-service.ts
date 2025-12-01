import { api } from '@/axios'

export const RichTableService = {
  search: (url: string) => {
    return api.get(url);
  }
}
