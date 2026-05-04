<template>
  <div class="px-6 py-8">
    <div class="flex items-center justify-between mb-6">
      <h2 class="text-2xl font-bold text-gray-800">Manage Products</h2>
      <button
        @click="showForm = true"
        class="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded transition-colors font-medium"
      >
        + Add Product
      </button>
    </div>
    <div class="bg-white rounded-lg shadow-md overflow-hidden">
      <table class="w-full border-collapse">
        <thead class="bg-gray-50">
          <tr>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Name</th>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Price</th>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Stock</th>
            <th class="text-left px-4 py-3 text-sm font-semibold text-gray-600 border-b border-gray-200">Actions</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="product in products" :key="product.id" class="hover:bg-gray-50 border-b border-gray-100">
            <td class="px-4 py-3 text-gray-800 font-medium">{{ product.name }}</td>
            <td class="px-4 py-3 text-gray-700">{{ product.price }}</td>
            <td class="px-4 py-3 text-gray-700">{{ product.stock }}</td>
            <td class="px-4 py-3 flex gap-2">
              <button
                @click="editProduct(product)"
                class="bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded text-sm transition-colors"
              >
                Edit
              </button>
              <button
                @click="deleteProduct(product.id)"
                class="bg-red-600 hover:bg-red-700 text-white px-3 py-1 rounded text-sm transition-colors"
              >
                Delete
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
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
