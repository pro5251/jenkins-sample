import api from './api'

export default {
  async getCart() {
    const response = await api.get('/api/cart')
    return response.data
  },

  async addItem(productId, quantity = 1) {
    const response = await api.post('/api/cart', { product_id: productId, quantity })
    return response.data
  },

  async updateItem(id, quantity) {
    const response = await api.put(`/api/cart/${id}`, { quantity })
    return response.data
  },

  async removeItem(id) {
    const response = await api.delete(`/api/cart/${id}`)
    return response.data
  },

  async clearCart() {
    const response = await api.delete('/api/cart')
    return response.data
  }
}