<template>
  <div class="max-w-4xl mx-auto px-6 py-10">
    <h2 class="text-2xl font-bold text-gray-800 mb-6">Shopping Cart</h2>
    <div v-if="cartItems.length === 0" class="text-center py-16">
      <p class="text-gray-500 text-lg mb-4">Your cart is empty.</p>
      <router-link to="/products" class="inline-block bg-blue-600 hover:bg-blue-700 text-white px-6 py-2 rounded transition-colors">
        Continue Shopping
      </router-link>
    </div>
    <div v-else>
      <div class="bg-white rounded-lg shadow-md overflow-hidden mb-6">
        <div v-for="item in cartItems" :key="item.id">
          <CartItem :item="item" @remove="removeItem" />
        </div>
      </div>
      <div class="bg-white rounded-lg shadow-md p-6 flex items-center justify-between">
        <p class="text-xl font-semibold text-gray-800">Total: <span class="text-blue-600">{{ cartTotal }}</span></p>
        <button
          @click="proceedToCheckout"
          class="bg-blue-600 hover:bg-blue-700 text-white px-6 py-2 rounded transition-colors font-medium"
        >
          Proceed to Checkout
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed } from 'vue';
import { useRouter } from 'vue-router';
import { useCartStore } from '../stores/cart';
import CartItem from '../components/CartItem.vue';

const router = useRouter();
const cartStore = useCartStore();

const cartItems = computed(() => cartStore.cartItems);
const cartTotal = computed(() => cartStore.cartTotal);

const removeItem = (itemId) => {
  // Implementation will be added
};

const proceedToCheckout = () => {
  router.push('/checkout');
};
</script>
