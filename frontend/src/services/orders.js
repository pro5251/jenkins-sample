import api from './api'

export default {
  async checkout(orderData) {
    const response = await api.post('/api/orders/checkout', orderData)
    return response.data
  },

  async getOrders(params = {}) {
    const response = await api.get('/api/orders', { params })
    return response.data
  },

  async getOrder(id) {
    const response = await api.get(`/api/orders/${id}`)
    return response.data
  },

  async updateOrderStatus(id, status) {
    const response = await api.put(`/api/orders/${id}/status`, { status })
    return response.data
  }
}