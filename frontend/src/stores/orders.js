import { defineStore } from 'pinia'
import orderService from '../services/orders'

export const useOrdersStore = defineStore('orders', {
  state: () => ({
    orders: [],
    currentOrder: null
  }),
  getters: {
    allOrders: (state) => state.orders,
    currentOrder: (state) => state.currentOrder
  },
  actions: {
    async fetchOrders(params = {}) {
      const result = await orderService.getOrders(params)
      this.orders = result.orders
      return result
    },
    async fetchOrder(id) {
      const order = await orderService.getOrder(id)
      this.currentOrder = order
      return order
    },
    async createOrder(orderData) {
      const order = await orderService.checkout(orderData)
      this.orders.unshift(order)
      return order
    }
  }
})