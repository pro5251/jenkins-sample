<template>
  <div class="register">
    <h2>Register</h2>
    <form @submit.prevent="handleSubmit">
      <div>
        <label>Username:</label>
        <input v-model="form.username" type="text" required />
      </div>
      <div>
        <label>Email:</label>
        <input v-model="form.email" type="email" required />
      </div>
      <div>
        <label>Password:</label>
        <input v-model="form.password" type="password" required />
      </div>
      <div>
        <label>Confirm Password:</label>
        <input v-model="form.confirmPassword" type="password" required />
      </div>
      <button type="submit">Register</button>
    </form>
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
