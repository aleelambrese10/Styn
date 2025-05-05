import { defineStore } from "pinia"
import { productsApi } from "@/api/products"

export const useProductsStore = defineStore("products", {
  state: () => ({
    products: [],
    product: null,
    loading: false,
    error: null,
  }),

  getters: {
    getProductById: (state) => (id) => {
      return state.products.find((product) => product.id === id)
    },
  },

  actions: {
    async fetchProducts(params = {}) {
      this.loading = true
      try {
        const response = await productsApi.getProducts(params)
        return response
      } catch (error) {
        this.error = error.message || "Error al cargar productos"
        throw error
      } finally {
        this.loading = false
      }
    },

    async fetchProductById(id) {
      this.loading = true
      try {
        const product = await productsApi.getProductById(id)
        this.product = product
        return product
      } catch (error) {
        this.error = error.message || "Error al cargar el producto"
        throw error
      } finally {
        this.loading = false
      }
    },

    async createProduct(productData) {
      this.loading = true
      try {
        const newProduct = await productsApi.createProduct(productData)
        return newProduct
      } catch (error) {
        this.error = error.message || "Error al crear el producto"
        throw error
      } finally {
        this.loading = false
      }
    },

    async updateProduct(productData) {
      this.loading = true
      try {
        const updatedProduct = await productsApi.updateProduct(productData.id, productData)
        return updatedProduct
      } catch (error) {
        this.error = error.message || "Error al actualizar el producto"
        throw error
      } finally {
        this.loading = false
      }
    },

    async deleteProduct(id) {
      this.loading = true
      try {
        await productsApi.deleteProduct(id)
      } catch (error) {
        this.error = error.message || "Error al eliminar el producto"
        throw error
      } finally {
        this.loading = false
      }
    },
  },
})
