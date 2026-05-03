<template>
  <div class="product-card">
    <img :src="product.imageUrl" :alt="product.name" />
    <h3>{{ product.name }}</h3>
    <p>{{ product.description }}</p>
    <p class="price">{{ product.price }}</p>
    <button @click="$emit('add-to-cart', product.id)">Add to Cart</button>
  </div>
</template>

<script setup>
defineProps({
  product: Object
});
defineEmits(['add-to-cart']);
</script>

<style scoped>
.product-card {
  border: 1px solid #ddd;
  padding: 1rem;
  border-radius: 8px;
}
.price {
  font-weight: bold;
  color: #e44d26;
}
</style>
