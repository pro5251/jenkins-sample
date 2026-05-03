<template>
  <div class="cart-page">
    <h2>Shopping Cart</h2>
    <div v-if="cartItems.length === 0">
      <p>Your cart is empty.</p>
      <router-link to="/products">Continue Shopping</router-link>
    </div>
    <div v-else>
      <div v-for="item in cartItems" :key="item.id">
        <CartItem :item="item" @remove="removeItem" />
      </div>
      <div class="cart-summary">
        <p>Total: {{ cartTotal }}</p>
        <button @click="proceedToCheckout">Proceed to Checkout</button>
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

<style scoped>
.cart-page {
  padding: 2rem;
}
.cart-summary {
  margin-top: 2rem;
  padding: 1rem;
  background-color: #f8f9fa;
}
</style>
