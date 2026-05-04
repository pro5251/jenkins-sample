<template>
  <div class="max-w-7xl mx-auto px-6 py-10">
    <h2 class="text-2xl font-bold text-gray-800 mb-8">Products</h2>
    <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
      <div
        v-for="product in products"
        :key="product.id"
        class="bg-white border border-gray-200 rounded-lg shadow-md hover:shadow-lg transition-shadow p-4 flex flex-col"
      >
        <img :src="product.imageUrl" :alt="product.name" class="w-full h-48 object-cover rounded-md mb-3" />
        <h3 class="font-semibold text-gray-800 text-lg mb-1">{{ product.name }}</h3>
        <p class="text-gray-500 text-sm flex-1 mb-3">{{ product.description }}</p>
        <p class="text-xl font-bold text-blue-600 mb-3">{{ product.price }}</p>
        <button
          @click="addToCart(product.id)"
          class="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded transition-colors w-full"
        >
          Add to Cart
        </button>
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
