export const state = () => ({
  items: [],
  totalAmount: 0,
  itemCount: 0
})

export const getters = {
  cartItems: (state) => state.items,
  cartTotal: (state) => state.totalAmount,
  itemCount: (state) => state.itemCount
}

export const mutations = {
  SET_CART(state, { items, totalAmount, itemCount }) {
    state.items = items
    state.totalAmount = totalAmount
    state.itemCount = itemCount
  },
  ADD_ITEM(state, item) {
    state.items.push(item)
  }
}

export const actions = {
  async fetchCart({ commit }) {
    // API call will be implemented here
    console.log('Fetch cart')
  },
  async addToCart({ commit }, { productId, quantity }) {
    // API call will be implemented here
    console.log('Add to cart', productId, quantity)
  }
}
