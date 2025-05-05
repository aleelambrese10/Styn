import { defineStore } from "pinia"
import { fichaAnimalApi } from "@/api/fichaAnimal"

export const useFichaAnimalStore = defineStore("fichaAnimal", {
  state: () => ({
    fichasAnimales: [],
    fichaAnimal: null,
    loading: false,
    error: null,
  }),

  getters: {
    getFichaAnimalById: (state) => (id) => {
      return state.fichasAnimales.find((ficha) => ficha.id === id)
    },
  },

  actions: {
    async fetchFichasAnimales(params = {}) {
      this.loading = true
      try {
        const response = await fichaAnimalApi.getFichasAnimales(params)
        return response
      } catch (error) {
        this.error = error.message || "Error al cargar fichas de animales"
        throw error
      } finally {
        this.loading = false
      }
    },

    async fetchFichaAnimalById(id) {
      this.loading = true
      try {
        const fichaAnimal = await fichaAnimalApi.getFichaAnimalById(id)
        this.fichaAnimal = fichaAnimal
        return fichaAnimal
      } catch (error) {
        this.error = error.message || "Error al cargar la ficha del animal"
        throw error
      } finally {
        this.loading = false
      }
    },

    async createFichaAnimal(fichaData) {
      this.loading = true
      try {
        const newFichaAnimal = await fichaAnimalApi.createFichaAnimal(fichaData)
        return newFichaAnimal
      } catch (error) {
        this.error = error.message || "Error al crear la ficha del animal"
        throw error
      } finally {
        this.loading = false
      }
    },

    async updateFichaAnimal(fichaData) {
      this.loading = true
      try {
        const updatedFichaAnimal = await fichaAnimalApi.updateFichaAnimal(fichaData.id, fichaData)
        return updatedFichaAnimal
      } catch (error) {
        this.error = error.message || "Error al actualizar la ficha del animal"
        throw error
      } finally {
        this.loading = false
      }
    },

    async deleteFichaAnimal(id) {
      this.loading = true
      try {
        await fichaAnimalApi.deleteFichaAnimal(id)
      } catch (error) {
        this.error = error.message || "Error al eliminar la ficha del animal"
        throw error
      } finally {
        this.loading = false
      }
    },
  },
})
