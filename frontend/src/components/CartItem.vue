<template>
  <div class="flex gap-4 p-4 border-b border-gray-200 items-start">
    <img :src="item.imageUrl" :alt="item.name" class="w-20 h-20 object-cover rounded" />
    <div class="flex-1">
      <h4 class="font-semibold text-gray-800 text-lg">{{ item.name }}</h4>
      <p class="text-gray-600 mt-1">Price: <span class="font-medium text-gray-800">{{ item.price }}</span></p>
      <p class="text-gray-600">Quantity: <span class="font-medium text-gray-800">{{ item.quantity }}</span></p>
      <button
        @click="$emit('remove', item.id)"
        class="mt-2 text-sm text-red-600 hover:text-red-800 hover:underline transition-colors"
      >
        Remove
      </button>
    </div>
  </div>
</template>

<script setup>
defineProps({
  item: Object
});
defineEmits(['remove']);
</script>
