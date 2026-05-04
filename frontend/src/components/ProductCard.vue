<template>
  <div class="bg-white border border-gray-200 rounded-lg shadow-md hover:shadow-lg transition-shadow p-4 flex flex-col">
    <img :src="product.imageUrl" :alt="product.name" class="w-full h-48 object-cover rounded-md mb-3" />
    <h3 class="font-semibold text-gray-800 text-lg mb-1">{{ product.name }}</h3>
    <p class="text-gray-500 text-sm flex-1 mb-3">{{ product.description }}</p>
    <p class="text-xl font-bold text-blue-600 mb-3">{{ product.price }}</p>
    <button
      @click="$emit('add-to-cart', product.id)"
      class="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded transition-colors w-full"
    >
      Add to Cart
    </button>
  </div>
</template>

<script setup>
defineProps({
  product: Object
});
defineEmits(['add-to-cart']);
</script>
