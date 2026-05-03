<template>
  <div class="admin-products">
    <h2>Manage Products</h2>
    <button @click="showForm = true">Add Product</button>
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Price</th>
          <th>Stock</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="product in products" :key="product.id">
          <td>{{ product.name }}</td>
          <td>{{ product.price }}</td>
          <td>{{ product.stock }}</td>
          <td>
            <button @click="editProduct(product)">Edit</button>
            <button @click="deleteProduct(product.id)">Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
    <ProductForm v-if="showForm" :product="editingProduct" @save="saveProduct" @cancel="showForm = false" />
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useProductsStore } from '../../stores/products';
import ProductForm from '../../components/admin/ProductForm.vue';

const productsStore = useProductsStore();
const products = ref([]);
const showForm = ref(false);
const editingProduct = ref(null);

onMounted(async () => {
  await productsStore.fetchProducts();
  products.value = productsStore.products;
});

const editProduct = (product) => {
  editingProduct.value = product;
  showForm.value = true;
};

const saveProduct = () => {
  showForm.value = false;
  editingProduct.value = null;
};

const deleteProduct = (id) => {
  // Implementation will be added
};
</script>
