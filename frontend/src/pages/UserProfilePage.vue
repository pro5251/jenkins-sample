<template>
  <div class="profile-page">
    <h2>User Profile</h2>
    <div v-if="user">
      <p>Username: {{ user.username }}</p>
      <p>Email: {{ user.email }}</p>
      <p>Role: {{ user.role }}</p>
    </div>
    <h3>My Orders</h3>
    <div v-for="order in orders" :key="order.id">
      <p>Order #{{ order.id }} - {{ order.status }} - {{ order.totalAmount }}</p>
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
