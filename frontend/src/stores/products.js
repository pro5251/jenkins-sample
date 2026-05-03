export const state = () => ({
  products: [],
  loading: false,
  error: null
})

export const getters = {
  allProducts: (state) => state.products,
  isLoading: (state) => state.loading
}

export const mutations = {
  SET_PRODUCTS(state, products) {
    state.products = products
  },
  SET_LOADING(state, loading) {
    state.loading = loading
  },
  SET_ERROR(state, error) {
    state.error = error
  }
}

export const actions = {
  async fetchProducts({ commit }, params) {
    commit('SET_LOADING', true)
    // API call will be implemented here
    console.log('Fetch products', params)
    commit('SET_LOADING', false)
  }
}
