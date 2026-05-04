<template>
  <div class="flex flex-col min-h-screen">
    <header class="bg-gray-900 text-white shadow-md">
      <div class="max-w-7xl mx-auto px-6 py-4 flex items-center justify-between">
        <h1 class="text-xl font-bold tracking-wide">🛍️ Shopping Website</h1>
        <nav class="flex items-center gap-4">
          <router-link to="/" class="text-gray-300 hover:text-white transition-colors">Home</router-link>
          <router-link to="/products" class="text-gray-300 hover:text-white transition-colors">Products</router-link>
          <router-link to="/cart" class="text-gray-300 hover:text-white transition-colors">Cart</router-link>
          <router-link v-if="!isAuthenticated" to="/login" class="bg-blue-600 hover:bg-blue-700 text-white px-4 py-1.5 rounded transition-colors text-sm">Login</router-link>
          <button v-else @click="logout" class="bg-red-600 hover:bg-red-700 text-white px-4 py-1.5 rounded transition-colors text-sm">Logout</button>
        </nav>
      </div>
    </header>
    <main class="flex-1">
      <router-view />
    </main>
    <footer class="bg-gray-100 border-t border-gray-200 py-4 text-center text-gray-500 text-sm">
      <p>&copy; 2026 Shopping Website</p>
    </footer>
  </div>
</template>

<script setup>
import { computed } from 'vue';
import { useRouter } from 'vue-router';
import { useAuthStore } from '../../stores/auth';

const authStore = useAuthStore();
const router = useRouter();
const isAuthenticated = computed(() => authStore.isAuthenticated);

const logout = async () => {
  await authStore.logout();
  router.push('/login');
};
</script>
