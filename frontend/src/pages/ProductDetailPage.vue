<template>
  <div class="product-detail">
    <img :src="product.imageUrl" :alt="product.name" />
    <div>
      <h2>{{ product.name }}</h2>
      <p>{{ product.description }}</p>
      <p class="price">{{ product.price }}</p>
      <p>Stock: {{ product.stock }}</p>
      <button @click="addToCart">Add to Cart</button>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { useProductsStore } from '../stores/products';
import { useCartStore } from '../stores/cart';

const route = useRoute();
const router = useRouter();
const productsStore = useProductsStore();
const cartStore = useCartStore();

const product = computed(() => productsStore.products.find(p => p.id === parseInt(route.params.id)));

onMounted(() => {
  if (!product.value) {
    // Fetch product details
  }
});

const addToCart = () => {
  if (product.value) {
    cartStore.addToCart({ productId: product.value.id, quantity: 1 });
  }
};
</script>

<style scoped>
.product-detail {
  display: flex;
  gap: 2rem;
  padding: 2rem;
}
.price {
  font-size: 1.5rem;
  font-weight: bold;
  color: #e44d26;
}
</style>
