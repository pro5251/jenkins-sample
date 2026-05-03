import api from './api'

export default {
  async register(userData) {
    const response = await api.post('/api/auth/register', userData)
    return response.data
  },

  async login(credentials) {
    const response = await api.post('/api/auth/login', credentials)
    if (response.data.token) {
      localStorage.setItem('token', response.data.token)
    }
    return response.data
  },

  async logout() {
    const response = await api.post('/api/auth/logout')
    localStorage.removeItem('token')
    return response.data
  },

  async getCurrentUser() {
    const response = await api.get('/api/auth/me')
    return response.data
  }
}