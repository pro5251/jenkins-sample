<template>
  <div class="product-form">
    <h3>{{ product ? 'Edit' : 'Add' }} Product</h3>
    <form @submit.prevent="handleSubmit">
      <div>
        <label>Name:</label>
        <input v-model="form.name" required />
      </div>
      <div>
        <label>Description:</label>
        <textarea v-model="form.description" />
      </div>
      <div>
        <label>Price:</label>
        <input v-model="form.price" type="number" required />
      </div>
      <div>
        <label>Stock:</label>
        <input v-model="form.stock" type="number" required />
      </div>
      <div>
        <label>Category:</label>
        <input v-model="form.category" required />
      </div>
      <div>
        <label>Image URL:</label>
        <input v-model="form.imageUrl" />
      </div>
      <button type="submit">Save</button>
      <button type="button" @click="$emit('cancel')">Cancel</button>
    </form>
  </div>
</template>

<script setup>
import { reactive } from 'vue';

const props = defineProps({
  product: Object
});

const emit = defineEmits(['save', 'cancel']);

const form = reactive({
  name: props.product?.name || '',
  description: props.product?.description || '',
  price: props.product?.price || 0,
  stock: props.product?.stock || 0,
  category: props.product?.category || '',
  imageUrl: props.product?.imageUrl || ''
});

const handleSubmit = () => {
  emit('save', { ...form });
};
</script>
