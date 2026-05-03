<template>
  <div class="admin-orders">
    <h2>Manage Orders</h2>
    <table>
      <thead>
        <tr>
          <th>Order ID</th>
          <th>Customer</th>
          <th>Total</th>
          <th>Status</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="order in orders" :key="order.id">
          <td>{{ order.id }}</td>
          <td>{{ order.userName }}</td>
          <td>{{ order.totalAmount }}</td>
          <td>
            <select v-model="order.status" @change="updateStatus(order)">
              <option value="pending">Pending</option>
              <option value="confirmed">Confirmed</option>
              <option value="shipped">Shipped</option>
              <option value="delivered">Delivered</option>
              <option value="cancelled">Cancelled</option>
            </select>
          </td>
          <td>
            <button @click="viewOrder(order)">View</button>
          </td>
        </tr>
      </tbody>
    </table>
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
