import axios, { type AxiosInstance, type AxiosRequestConfig } from 'axios'
import { useAuthStore } from '@/stores/auth-store'
import { type GridCommand, type GridResponse, createGridResponseSchema } from './types/grid-command'
import { type z } from 'zod'

// ============================================================================
// Axios Instance
// ============================================================================

/**
 * Base API client instance with authentication and error handling
 */
export const apiClient: AxiosInstance = axios.create({
  baseURL: import.meta.env.VITE_API_URL || 'http://localhost:5000/api',
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 30000, // 30 seconds
})

// ============================================================================
// Request Interceptor
// ============================================================================

apiClient.interceptors.request.use(
  (config) => {
    // Add authentication token if available
    const token = useAuthStore.getState().auth.accessToken

    if (token) {
      config.headers.Authorization = `Bearer ${token}`
    }

    return config
  },
  (error) => {
    return Promise.reject(error)
  }
)

// ============================================================================
// Response Interceptor
// ============================================================================

apiClient.interceptors.response.use(
  (response) => {
    return response
  },
  (error) => {
    // Handle specific error status codes
    if (error.response) {
      const status = error.response.status

      switch (status) {
        case 401:
          // Unauthorized - token expired or invalid
          // The error boundary in main.tsx will handle redirect to sign-in
          console.error('Unauthorized request:', error.response.data)
          break

        case 403:
          // Forbidden - user doesn't have permission
          console.error('Forbidden request:', error.response.data)
          break

        case 404:
          // Not found
          console.error('Resource not found:', error.response.data)
          break

        case 500:
          // Server error
          console.error('Server error:', error.response.data)
          break

        default:
          console.error('API error:', error.response.data)
      }
    } else if (error.request) {
      // Request was made but no response received
      console.error('No response from server:', error.request)
    } else {
      // Something else happened
      console.error('Request error:', error.message)
    }

    return Promise.reject(error)
  }
)

// ============================================================================
// Typed API Methods
// ============================================================================

/**
 * POST request to fetch grid data with GridCommand
 * @param url - The API endpoint (e.g., '/customers/search')
 * @param command - The GridCommand with filters, sorting, pagination
 * @param dataSchema - Zod schema for validating response data items
 * @returns Promise with GridResponse<T>
 */
export async function fetchGridData<T>(
  url: string,
  command: GridCommand,
  dataSchema: z.ZodType<T>,
  config?: AxiosRequestConfig
): Promise<GridResponse<T>> {
  const responseSchema = createGridResponseSchema(dataSchema)

  const response = await apiClient.post(url, command, config)

  // Validate response with Zod schema
  const validatedData = responseSchema.parse(response.data)

  return validatedData
}

/**
 * GET request
 */
export async function get<T>(
  url: string,
  config?: AxiosRequestConfig
): Promise<T> {
  const response = await apiClient.get<T>(url, config)
  return response.data
}

/**
 * POST request
 */
export async function post<T, D = unknown>(
  url: string,
  data?: D,
  config?: AxiosRequestConfig
): Promise<T> {
  const response = await apiClient.post<T>(url, data, config)
  return response.data
}

/**
 * PUT request
 */
export async function put<T, D = unknown>(
  url: string,
  data?: D,
  config?: AxiosRequestConfig
): Promise<T> {
  const response = await apiClient.put<T>(url, data, config)
  return response.data
}

/**
 * PATCH request
 */
export async function patch<T, D = unknown>(
  url: string,
  data?: D,
  config?: AxiosRequestConfig
): Promise<T> {
  const response = await apiClient.patch<T>(url, data, config)
  return response.data
}

/**
 * DELETE request
 */
export async function del<T>(
  url: string,
  config?: AxiosRequestConfig
): Promise<T> {
  const response = await apiClient.delete<T>(url, config)
  return response.data
}

// ============================================================================
// Export
// ============================================================================

export default apiClient
