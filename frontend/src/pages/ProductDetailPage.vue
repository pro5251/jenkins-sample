<template>
  <div class="max-w-5xl mx-auto px-6 py-10">
    <div class="flex flex-col md:flex-row gap-8 bg-white rounded-lg shadow-md overflow-hidden p-6">
      <img :src="product.imageUrl" :alt="product.name" class="w-full md:w-80 h-72 object-cover rounded-lg flex-shrink-0" />
      <div class="flex flex-col justify-center">
        <h2 class="text-3xl font-bold text-gray-800 mb-3">{{ product.name }}</h2>
        <p class="text-gray-500 mb-4 leading-relaxed">{{ product.description }}</p>
        <p class="text-3xl font-bold text-blue-600 mb-2">{{ product.price }}</p>
        <p class="text-gray-500 text-sm mb-6">Stock: <span class="font-medium text-gray-700">{{ product.stock }}</span></p>
        <button
          @click="addToCart"
          class="bg-blue-600 hover:bg-blue-700 text-white px-8 py-3 rounded-lg font-medium transition-colors w-fit"
        >
          Add to Cart
        </button>
      </div>
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
