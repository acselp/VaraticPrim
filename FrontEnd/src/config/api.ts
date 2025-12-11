export const apiConfig = {
  baseUrl: 'http://localhost:8081/',
}

export const getUrl = (endpoint: string) => {
  return `${apiConfig.baseUrl}${endpoint}`
}
