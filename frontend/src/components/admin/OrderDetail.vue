<template>
  <div class="order-detail">
    <h3>Order #{{ order.id }}</h3>
    <p>Customer: {{ order.userName }}</p>
    <p>Total: {{ order.totalAmount }}</p>
    <p>Status: {{ order.status }}</p>
    <h4>Items:</h4>
    <ul>
      <li v-for="item in order.items" :key="item.id">
        {{ item.productName }} - {{ item.quantity }} x {{ item.price }}
      </li>
    </ul>
    <button @click="$emit('close')">Close</button>
  </div>
</template>

<script setup>
defineProps({
  order: Object
});

defineEmits(['close']);
</script>
