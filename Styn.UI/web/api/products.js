import { apiClient } from "./client"

export const productsApi = {
  getProducts: async (params = {}) => {
    try {
      const response = await apiClient.get("/products", { params })
      return response.data
    } catch (error) {
      console.error("Error fetching products:", error)
      throw error
    }
  },

  getProductById: async (id) => {
    try {
      const response = await apiClient.get(`/products/${id}`)
      return response.data
    } catch (error) {
      console.error(`Error fetching product ${id}:`, error)
      throw error
    }
  },

  createProduct: async (productData) => {
    try {
      const response = await apiClient.post("/products", productData)
      return response.data
    } catch (error) {
      console.error("Error creating product:", error)
      throw error
    }
  },

  updateProduct: async (id, productData) => {
    try {
      const response = await apiClient.put(`/products/${id}`, productData)
      return response.data
    } catch (error) {
      console.error(`Error updating product ${id}:`, error)
      throw error
    }
  },

  deleteProduct: async (id) => {
    try {
      const response = await apiClient.delete(`/products/${id}`)
      return response.data
    } catch (error) {
      console.error(`Error deleting product ${id}:`, error)
      throw error
    }
  },
}
