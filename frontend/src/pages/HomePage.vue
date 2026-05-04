<template>
  <div class="text-center py-20 px-6">
    <h2 class="text-4xl font-bold text-gray-800 mb-4">Welcome to Shopping Website</h2>
    <p class="text-lg text-gray-500 mb-8">Browse our products and enjoy shopping!</p>
    <router-link
      to="/products"
      class="inline-block bg-blue-600 hover:bg-blue-700 text-white px-8 py-3 rounded-lg font-medium transition-colors text-lg"
    >
      View Products
    </router-link>
  </div>
</template>

<script setup>
import { onMounted } from 'vue';
import { useProductsStore } from '../stores/products';

const productsStore = useProductsStore();

onMounted(() => {
  productsStore.fetchProducts();
});
</script>
