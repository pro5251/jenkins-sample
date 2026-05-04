<template>
  <div class="min-h-screen flex items-center justify-center bg-gray-50 px-4">
    <div class="bg-white rounded-lg shadow-md p-8 w-full max-w-sm">
      <h2 class="text-2xl font-bold text-gray-800 mb-6 text-center">Register</h2>
      <form @submit.prevent="handleSubmit" class="space-y-4">
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Username:</label>
          <input
            v-model="form.username"
            type="text"
            required
            class="border border-gray-300 rounded px-3 py-2 w-full focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Email:</label>
          <input
            v-model="form.email"
            type="email"
            required
            class="border border-gray-300 rounded px-3 py-2 w-full focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Password:</label>
          <input
            v-model="form.password"
            type="password"
            required
            class="border border-gray-300 rounded px-3 py-2 w-full focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Confirm Password:</label>
          <input
            v-model="form.confirmPassword"
            type="password"
            required
            class="border border-gray-300 rounded px-3 py-2 w-full focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>
        <button
          type="submit"
          class="w-full bg-blue-600 hover:bg-blue-700 text-white py-2.5 rounded font-medium transition-colors mt-2"
        >
          Register
        </button>
      </form>
      <p class="text-center text-sm text-gray-500 mt-4">
        Already have an account?
        <router-link to="/login" class="text-blue-600 hover:underline">Login</router-link>
      </p>
    </div>
  </div>
</template>

<script setup>
import { reactive } from 'vue';
import { useRouter } from 'vue-router';
import { useAuthStore } from '../stores/auth';

const router = useRouter();
const authStore = useAuthStore();

const form = reactive({
  username: '',
  email: '',
  password: '',
  confirmPassword: ''
});

const handleSubmit = async () => {
  if (form.password !== form.confirmPassword) {
    alert('Passwords do not match');
    return;
  }
  await authStore.register(form);
  router.push('/login');
};
</script>
