<template>
  <div class="max-w-xl mx-auto px-6 py-10">
    <h2 class="text-2xl font-bold text-gray-800 mb-6">Checkout</h2>
    <form @submit.prevent="handleCheckout" class="bg-white rounded-lg shadow-md p-6 space-y-5">
      <div>
        <label class="block text-sm font-medium text-gray-700 mb-1">Shipping Address:</label>
        <textarea
          v-model="form.shippingAddress"
          required
          rows="3"
          class="border border-gray-300 rounded px-3 py-2 w-full focus:outline-none focus:ring-2 focus:ring-blue-500"
        ></textarea>
      </div>
      <div>
        <label class="block text-sm font-medium text-gray-700 mb-1">Contact Phone:</label>
        <input
          v-model="form.contactPhone"
          type="tel"
          required
          class="border border-gray-300 rounded px-3 py-2 w-full focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
      </div>
      <div class="border border-gray-100 rounded-lg bg-gray-50 p-4">
        <h3 class="text-lg font-semibold text-gray-800 mb-2">Order Summary</h3>
        <p class="text-gray-700">Total: <span class="font-bold text-blue-600">{{ cartTotal }}</span></p>
        <p class="text-gray-500 text-sm mt-1">Payment: 貨到付款</p>
      </div>
      <button
        type="submit"
        class="w-full bg-blue-600 hover:bg-blue-700 text-white py-2.5 rounded font-medium transition-colors"
      >
        Place Order
      </button>
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
