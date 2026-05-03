import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('../pages/HomePage.vue')
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('../pages/LoginPage.vue')
  },
  {
    path: '/register',
    name: 'Register',
    component: () => import('../pages/RegisterPage.vue')
  },
  {
    path: '/products/:id',
    name: 'ProductDetail',
    component: () => import('../pages/ProductDetailPage.vue')
  },
  {
    path: '/cart',
    name: 'Cart',
    component: () => import('../pages/CartPage.vue')
  },
  {
    path: '/checkout',
    name: 'Checkout',
    component: () => import('../pages/CheckoutPage.vue')
  },
  {
    path: '/profile',
    name: 'Profile',
    component: () => import('../pages/UserProfilePage.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/admin',
    name: 'Admin',
    component: () => import('../components/layout/AdminLayout.vue'),
    meta: { requiresAdmin: true },
    children: [
      {
        path: 'products',
        name: 'AdminProducts',
        component: () => import('../pages/admin/AdminProductsPage.vue')
      },
      {
        path: 'orders',
        name: 'AdminOrders',
        component: () => import('../pages/admin/AdminOrdersPage.vue')
      },
      {
        path: 'users',
        name: 'AdminUsers',
        component: () => import('../pages/admin/AdminUsersPage.vue')
      }
    ]
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

router.beforeEach((to, from, next) => {
  const token = localStorage.getItem('token')
  if (to.meta.requiresAuth && !token) {
    next('/login')
  } else if (to.meta.requiresAdmin && token) {
    const user = JSON.parse(localStorage.getItem('user') || '{}')
    if (user.role !== 'admin') {
      next('/')
    } else {
      next()
    }
  } else {
    next()
  }
})

export default router