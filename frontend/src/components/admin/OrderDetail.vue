<template>
  <div class="fixed inset-0 bg-black/50 flex items-center justify-center z-50">
    <div class="bg-white rounded-lg shadow-xl p-6 w-full max-w-lg">
      <h3 class="text-xl font-bold text-gray-800 mb-4">Order #{{ order.id }}</h3>
      <div class="space-y-2 mb-4">
        <p class="text-gray-700"><span class="font-medium">Customer:</span> {{ order.userName }}</p>
        <p class="text-gray-700"><span class="font-medium">Total:</span> {{ order.totalAmount }}</p>
        <p class="text-gray-700">
          <span class="font-medium">Status:</span>
          <span class="ml-1 inline-block px-2 py-0.5 rounded text-sm bg-blue-100 text-blue-700">{{ order.status }}</span>
        </p>
      </div>
      <h4 class="font-semibold text-gray-700 mb-2">Items:</h4>
      <ul class="divide-y divide-gray-100 border border-gray-100 rounded mb-4">
        <li v-for="item in order.items" :key="item.id" class="px-3 py-2 text-gray-700 text-sm">
          {{ item.productName }} &mdash; {{ item.quantity }} &times; {{ item.price }}
        </li>
      </ul>
      <button
        @click="$emit('close')"
        class="bg-gray-600 hover:bg-gray-700 text-white px-4 py-2 rounded transition-colors"
      >
        Close
      </button>
    </div>
  </div>
</template>

<script setup>
defineProps({
  order: Object
});

defineEmits(['close']);
</script>
