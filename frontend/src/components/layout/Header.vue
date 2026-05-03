<template>
  <div class="layout">
    <header>
      <h1>Shopping Website</h1>
      <nav>
        <router-link to="/">Home</router-link>
        <router-link to="/products">Products</router-link>
        <router-link to="/cart">Cart</router-link>
        <router-link v-if="!isAuthenticated" to="/login">Login</router-link>
        <button v-else @click="logout">Logout</button>
      </nav>
    </header>
    <main>
      <router-view />
    </main>
    <footer>
      <p>&copy; 2026 Shopping Website</p>
    </footer>
  </div>
</template>

<script setup>
import { computed } from 'vue';
import { useRouter } from 'vue-router';
import { useAuthStore } from '../stores/auth';

const authStore = useAuthStore();
const router = useRouter();
const isAuthenticated = computed(() => authStore.isAuthenticated);

const logout = async () => {
  await authStore.logout();
  router.push('/login');
};
</script>
