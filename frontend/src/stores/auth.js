import { defineStore } from 'pinia'
import authService from '../services/auth'

export const useAuthStore = defineStore('auth', {
  state: () => ({
    user: null,
    isAuthenticated: false
  }),
  getters: {
    currentUser: (state) => state.user,
    isAuthenticated: (state) => state.isAuthenticated
  },
  actions: {
    async login(credentials) {
      const user = await authService.login(credentials)
      this.user = user
      this.isAuthenticated = true
      return user
    },
    async logout() {
      await authService.logout()
      this.user = null
      this.isAuthenticated = false
    },
    async fetchCurrentUser() {
      try {
        const user = await authService.getCurrentUser()
        this.user = user
        this.isAuthenticated = true
        return user
      } catch (error) {
        this.user = null
        this.isAuthenticated = false
        return null
      }
    },
    async register(userData) {
      const user = await authService.register(userData)
      return user
    }
  }
})