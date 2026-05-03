export const state = () => ({
  user: null,
  isAuthenticated: false
})

export const getters = {
  currentUser: (state) => state.user,
  isAuthenticated: (state) => state.isAuthenticated
}

export const mutations = {
  SET_USER(state, user) {
    state.user = user
    state.isAuthenticated = !!user
  },
  LOGOUT(state) {
    state.user = null
    state.isAuthenticated = false
  }
}

export const actions = {
  async login({ commit }, credentials) {
    // API call will be implemented here
    console.log('Login action', credentials)
  },
  async logout({ commit }) {
    // API call will be implemented here
    commit('LOGOUT')
  }
}
