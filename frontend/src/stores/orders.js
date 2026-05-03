export const state = () => ({
  orders: [],
  currentOrder: null
})

export const getters = {
  allOrders: (state) => state.orders,
  currentOrder: (state) => state.currentOrder
})

export const mutations = {
  SET_ORDERS(state, orders) {
    state.orders = orders
  },
  SET_CURRENT_ORDER(state, order) {
    state.currentOrder = order
  }
}

export const actions = {
  async fetchOrders({ commit }) {
    // API call will be implemented here
    console.log('Fetch orders')
  },
  async createOrder({ commit }, orderData) {
    // API call will be implemented here
    console.log('Create order', orderData)
  }
}
