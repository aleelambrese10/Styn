import { apiClient } from "./client"

export const usersApi = {
  getUsers: async (params = {}) => {
    try {
      const response = await apiClient.get("/users", { params })
      return response.data
    } catch (error) {
      console.error("Error fetching users:", error)
      throw error
    }
  },

  getUserById: async (id) => {
    try {
      const response = await apiClient.get(`/users/${id}`)
      return response.data
    } catch (error) {
      console.error(`Error fetching user ${id}:`, error)
      throw error
    }
  },

  createUser: async (userData) => {
    try {
      const response = await apiClient.post("/users", userData)
      return response.data
    } catch (error) {
      console.error("Error creating user:", error)
      throw error
    }
  },

  updateUser: async (id, userData) => {
    try {
      const response = await apiClient.put(`/users/${id}`, userData)
      return response.data
    } catch (error) {
      console.error(`Error updating user ${id}:`, error)
      throw error
    }
  },

  deleteUser: async (id) => {
    try {
      const response = await apiClient.delete(`/users/${id}`)
      return response.data
    } catch (error) {
      console.error(`Error deleting user ${id}:`, error)
      throw error
    }
  },
}
