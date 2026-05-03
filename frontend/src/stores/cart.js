import { defineStore } from 'pinia'
import cartService from '../services/cart'

export const useCartStore = defineStore('cart', {
  state: () => ({
    items: [],
    totalAmount: 0,
    itemCount: 0
  }),
  getters: {
    cartItems: (state) => state.items,
    cartTotal: (state) => state.totalAmount,
    itemCount: (state) => state.itemCount
  },
  actions: {
    async fetchCart() {
      const cart = await cartService.getCart()
      this.items = cart.items
      this.totalAmount = cart.total_amount
      this.itemCount = cart.item_count
      return cart
    },
    async addToCart(productId, quantity = 1) {
      const item = await cartService.addItem(productId, quantity)
      const existingItem = this.items.find(i => i.id === item.id)
      if (existingItem) {
        existingItem.quantity = item.quantity
        existingItem.subtotal = item.subtotal
      } else {
        this.items.push(item)
      }
      this.totalAmount += item.price * quantity
      this.itemCount += quantity
      return item
    },
    async updateQuantity(id, quantity) {
      const item = await cartService.updateItem(id, quantity)
      const cartItem = this.items.find(i => i.id === id)
      if (cartItem) {
        cartItem.quantity = item.quantity
        cartItem.subtotal = item.subtotal
      }
      await this.fetchCart()
      return item
    },
    async removeFromCart(id) {
      await cartService.removeItem(id)
      this.items = this.items.filter(i => i.id !== id)
      await this.fetchCart()
    },
    async clearCart() {
      await cartService.clearCart()
      this.items = []
      this.totalAmount = 0
      this.itemCount = 0
    }
  }
})