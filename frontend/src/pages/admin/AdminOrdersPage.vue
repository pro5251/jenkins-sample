<template>
  <div class="px-6 py-8">
    <h2 class="text-2xl font-bold text-gray-800 mb-6">Manage Orders</h2>
    <div class="bg-white rounded-lg shadow-md overflow-hidden">
      <table class="w-full border-collapse">
        <thead class="bg-gray-50">
          <tr>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Order ID</th>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Customer</th>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Total</th>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Status</th>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Actions</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="order in orders" :key="order.id" class="hover:bg-gray-50 border-b border-gray-100">
            <td class="px-4 py-3 text-gray-700">#{{ order.id }}</td>
            <td class="px-4 py-3 text-gray-700">{{ order.userName }}</td>
            <td class="px-4 py-3 text-gray-700 font-medium">{{ order.totalAmount }}</td>
            <td class="px-4 py-3">
              <select
                v-model="order.status"
                @change="updateStatus(order)"
                class="border border-gray-300 rounded px-2 py-1 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
              >
                <option value="pending">Pending</option>
                <option value="confirmed">Confirmed</option>
                <option value="shipped">Shipped</option>
                <option value="delivered">Delivered</option>
                <option value="cancelled">Cancelled</option>
              </select>
            </td>
            <td class="px-4 py-3">
              <button
                @click="viewOrder(order)"
                class="bg-blue-600 hover:bg-blue-700 text-white px-3 py-1 rounded text-sm transition-colors"
              >
                View
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <OrderDetail v-if="selectedOrder" :order="selectedOrder" @close="selectedOrder = null" />
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useOrdersStore } from '../../stores/orders';
import OrderDetail from '../../components/admin/OrderDetail.vue';

const ordersStore = useOrdersStore();
const orders = ref([]);
const selectedOrder = ref(null);

onMounted(async () => {
  // Fetch orders implementation
});

const updateStatus = (order) => {
  // Implementation will be added
};

const viewOrder = (order) => {
  selectedOrder.value = order;
};
</script>
