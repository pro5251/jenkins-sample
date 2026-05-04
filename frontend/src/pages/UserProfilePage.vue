<template>
  <div class="max-w-3xl mx-auto px-6 py-10">
    <h2 class="text-2xl font-bold text-gray-800 mb-6">User Profile</h2>
    <div v-if="user" class="bg-white rounded-lg shadow-md p-6 mb-8">
      <div class="space-y-2">
        <p class="text-gray-700"><span class="font-semibold w-24 inline-block">Username:</span> {{ user.username }}</p>
        <p class="text-gray-700"><span class="font-semibold w-24 inline-block">Email:</span> {{ user.email }}</p>
        <p class="text-gray-700">
          <span class="font-semibold w-24 inline-block">Role:</span>
          <span class="inline-block bg-blue-100 text-blue-700 px-2 py-0.5 rounded text-sm">{{ user.role }}</span>
        </p>
      </div>
    </div>
    <h3 class="text-xl font-bold text-gray-800 mb-4">My Orders</h3>
    <div class="space-y-3">
      <div
        v-for="order in orders"
        :key="order.id"
        class="bg-white rounded-lg shadow-sm border border-gray-200 px-5 py-4 flex items-center justify-between"
      >
        <span class="text-gray-700 font-medium">Order #{{ order.id }}</span>
        <span class="inline-block px-2 py-0.5 rounded text-sm bg-gray-100 text-gray-600">{{ order.status }}</span>
        <span class="font-bold text-blue-600">{{ order.totalAmount }}</span>
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted } from 'vue';
import { useAuthStore } from '../stores/auth';
import { useOrdersStore } from '../stores/orders';

const authStore = useAuthStore();
const ordersStore = useOrdersStore();

const user = computed(() => authStore.currentUser);
const orders = computed(() => ordersStore.orders);

onMounted(() => {
  ordersStore.fetchOrders();
});
</script>
