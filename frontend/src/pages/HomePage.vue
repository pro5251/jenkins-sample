<template>
  <div class="home">
    <h2>Welcome to Shopping Website</h2>
    <p>Browse our products and enjoy shopping!</p>
    <router-link to="/products" class="btn">View Products</router-link>
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

<style scoped>
.home {
  text-align: center;
  padding: 2rem;
}
.btn {
  display: inline-block;
  padding: 0.5rem 1rem;
  background-color: #007bff;
  color: white;
  text-decoration: none;
  border-radius: 4px;
}
</style>
