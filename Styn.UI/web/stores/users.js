import { defineStore } from "pinia"
import { usersApi } from "@/api/users"

export const useUsersStore = defineStore("users", {
  state: () => ({
    users: [],
    user: null,
    loading: false,
    error: null,
  }),

  getters: {
    getUserById: (state) => (id) => {
      return state.users.find((user) => user.id === id)
    },
  },

  actions: {
    async fetchUsers(params = {}) {
      this.loading = true
      try {
        const response = await usersApi.getUsers(params)
        return response
      } catch (error) {
        this.error = error.message || "Error al cargar usuarios"
        throw error
      } finally {
        this.loading = false
      }
    },

    async fetchUserById(id) {
      this.loading = true
      try {
        const user = await usersApi.getUserById(id)
        this.user = user
        return user
      } catch (error) {
        this.error = error.message || "Error al cargar el usuario"
        throw error
      } finally {
        this.loading = false
      }
    },

    async createUser(userData) {
      this.loading = true
      try {
        const newUser = await usersApi.createUser(userData)
        return newUser
      } catch (error) {
        this.error = error.message || "Error al crear el usuario"
        throw error
      } finally {
        this.loading = false
      }
    },

    async updateUser(userData) {
      this.loading = true
      try {
        const updatedUser = await usersApi.updateUser(userData.id, userData)
        return updatedUser
      } catch (error) {
        this.error = error.message || "Error al actualizar el usuario"
        throw error
      } finally {
        this.loading = false
      }
    },

    async deleteUser(id) {
      this.loading = true
      try {
        await usersApi.deleteUser(id)
      } catch (error) {
        this.error = error.message || "Error al eliminar el usuario"
        throw error
      } finally {
        this.loading = false
      }
    },
  },
})
