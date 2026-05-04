<template>
  <div class="px-6 py-8">
    <h2 class="text-2xl font-bold text-gray-800 mb-6">Manage Users</h2>
    <div class="bg-white rounded-lg shadow-md overflow-hidden">
      <table class="w-full border-collapse">
        <thead class="bg-gray-50">
          <tr>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Username</th>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Email</th>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Role</th>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Actions</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="user in users" :key="user.id" class="hover:bg-gray-50 border-b border-gray-100">
            <td class="px-4 py-3 text-gray-800 font-medium">{{ user.username }}</td>
            <td class="px-4 py-3 text-gray-700">{{ user.email }}</td>
            <td class="px-4 py-3">
              <span class="inline-block bg-blue-100 text-blue-700 px-2 py-0.5 rounded text-sm">{{ user.role }}</span>
            </td>
            <td class="px-4 py-3 flex gap-2">
              <button
                @click="editUser(user)"
                class="bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded text-sm transition-colors"
              >
                Edit
              </button>
              <button
                @click="deactivateUser(user.id)"
                class="bg-red-600 hover:bg-red-700 text-white px-3 py-1 rounded text-sm transition-colors"
              >
                Deactivate
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';

const users = ref([]);

onMounted(async () => {
  // Fetch users implementation
});

const editUser = (user) => {
  // Implementation will be added
};

const deactivateUser = (id) => {
  // Implementation will be added
};
</script>
