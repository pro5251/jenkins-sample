import { defineStore } from 'pinia'
import productService from '../services/products'

export const useProductsStore = defineStore('products', {
  state: () => ({
    products: [],
    currentProduct: null,
    categories: [],
    loading: false,
    error: null,
    pagination: {
      page: 1,
      pageSize: 20,
      totalCount: 0,
      totalPages: 0
    }
  }),
  getters: {
    allProducts: (state) => state.products,
    currentProduct: (state) => state.currentProduct,
    categories: (state) => state.categories,
    isLoading: (state) => state.loading,
    pagination: (state) => state.pagination
  },
  actions: {
    async fetchProducts(params = {}) {
      this.loading = true
      this.error = null
      try {
        const result = await productService.getProducts(params)
        this.products = result.products
        this.pagination = {
          ...this.pagination,
          totalCount: result.total_count,
          page: result.page,
          totalPages: result.total_pages
        }
        return result
      } catch (error) {
        this.error = error.message
        throw error
      } finally {
        this.loading = false
      }
    },
    async fetchProduct(id) {
      this.loading = true
      this.error = null
      try {
        const product = await productService.getProduct(id)
        this.currentProduct = product
        return product
      } catch (error) {
        this.error = error.message
        throw error
      } finally {
        this.loading = false
      }
    },
    async fetchCategories() {
      const result = await productService.getCategories()
      this.categories = result.categories
      return result
    }
  }
})