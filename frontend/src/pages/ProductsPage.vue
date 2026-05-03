<template>
  <div class="products">
    <h2>Products</h2>
    <div class="product-list">
      <div v-for="product in products" :key="product.id" class="product-card">
        <img :src="product.imageUrl" :alt="product.name" />
        <h3>{{ product.name }}</h3>
        <p>{{ product.description }}</p>
        <p class="price">{{ product.price }}</p>
        <button @click="addToCart(product.id)">Add to Cart</button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted } from 'vue';
import { useProductsStore } from '../stores/products';
import { useCartStore } from '../stores/cart';

const productsStore = useProductsStore();
const cartStore = useCartStore();

const products = computed(() => productsStore.products);

onMounted(() => {
  productsStore.fetchProducts();
});

const addToCart = (productId) => {
  cartStore.addToCart({ productId, quantity: 1 });
};
</script>
