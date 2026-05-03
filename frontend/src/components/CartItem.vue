<template>
  <div class="cart-item">
    <img :src="item.imageUrl" :alt="item.name" />
    <div>
      <h4>{{ item.name }}</h4>
      <p>Price: {{ item.price }}</p>
      <p>Quantity: {{ item.quantity }}</p>
      <button @click="$emit('remove', item.id)">Remove</button>
    </div>
  </div>
</template>

<script setup>
defineProps({
  item: Object
});
defineEmits(['remove']);
</script>

<style scoped>
.cart-item {
  display: flex;
  gap: 1rem;
  padding: 1rem;
  border-bottom: 1px solid #ddd;
}
</style>
