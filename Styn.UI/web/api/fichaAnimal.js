import { apiClient } from "./client"

export const fichaAnimalApi = {
  getFichasAnimales: async (params = {}) => {
    try {
      const response = await apiClient.get("/fichaanimal", { params })
      return response.data
    } catch (error) {
      console.error("Error fetching fichas animales:", error)
      throw error
    }
  },

  getFichaAnimalById: async (id) => {
    try {
      const response = await apiClient.get(`/fichaanimal/${id}`)
      return response.data
    } catch (error) {
      console.error(`Error fetching ficha animal ${id}:`, error)
      throw error
    }
  },

  createFichaAnimal: async (fichaData) => {
    try {
      const response = await apiClient.post("/fichaanimal", fichaData)
      return response.data
    } catch (error) {
      console.error("Error creating ficha animal:", error)
      throw error
    }
  },

  updateFichaAnimal: async (id, fichaData) => {
    try {
      const response = await apiClient.put(`/fichaanimal/${id}`, fichaData)
      return response.data
    } catch (error) {
      console.error(`Error updating ficha animal ${id}:`, error)
      throw error
    }
  },

  deleteFichaAnimal: async (id) => {
    try {
      const response = await apiClient.delete(`/fichaanimal/${id}`)
      return response.data
    } catch (error) {
      console.error(`Error deleting ficha animal ${id}:`, error)
      throw error
    }
  },
}
