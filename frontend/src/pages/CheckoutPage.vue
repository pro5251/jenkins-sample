<template>
  <div class="checkout-page">
    <h2>Checkout</h2>
    <form @submit.prevent="handleCheckout">
      <div>
        <label>Shipping Address:</label>
        <textarea v-model="form.shippingAddress" required></textarea>
      </div>
      <div>
        <label>Contact Phone:</label>
        <input v-model="form.contactPhone" type="tel" required />
      </div>
      <div>
        <h3>Order Summary</h3>
        <p>Total: {{ cartTotal }}</p>
        <p>Payment: 貨到付款</p>
      </div>
      <button type="submit">Place Order</button>
    </form>
  </div>
</template>

<script setup>
import { reactive } from 'vue';
import { useRouter } from 'vue-router';
import { useCartStore } from '../stores/cart';
import { useOrdersStore } from '../stores/orders';

const router = useRouter();
const cartStore = useCartStore();
const ordersStore = useOrdersStore();

const form = reactive({
  shippingAddress: '',
  contactPhone: ''
});

const cartTotal = computed(() => cartStore.cartTotal);

const handleCheckout = async () => {
  await ordersStore.createOrder({
    shippingAddress: form.shippingAddress,
    contactPhone: form.contactPhone
  });
  router.push('/profile');
};
</script>

<style scoped>
.checkout-page {
  padding: 2rem;
  max-width: 600px;
  margin: 0 auto;
}
</style>
