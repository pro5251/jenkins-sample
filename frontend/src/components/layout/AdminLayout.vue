<template>
  <div class="flex min-h-screen">
    <aside class="w-64 bg-gray-800 text-white flex-shrink-0 flex flex-col">
      <div class="px-6 py-5 border-b border-gray-700">
        <h3 class="text-lg font-bold tracking-wide">Admin Panel</h3>
      </div>
      <nav class="flex flex-col p-4 gap-1">
        <router-link
          to="/admin/products"
          class="block text-gray-300 hover:text-white hover:bg-gray-700 px-3 py-2 rounded transition-colors"
        >
          Products
        </router-link>
        <router-link
          to="/admin/orders"
          class="block text-gray-300 hover:text-white hover:bg-gray-700 px-3 py-2 rounded transition-colors"
        >
          Orders
        </router-link>
        <router-link
          to="/admin/users"
          class="block text-gray-300 hover:text-white hover:bg-gray-700 px-3 py-2 rounded transition-colors"
        >
          Users
        </router-link>
        <router-link
          to="/"
          class="block text-gray-400 hover:text-white hover:bg-gray-700 px-3 py-2 rounded transition-colors mt-4 border-t border-gray-700 pt-4"
        >
          &larr; Back to Site
        </router-link>
      </nav>
    </aside>
    <main class="flex-1 p-8 bg-gray-50 overflow-auto">
      <router-view />
    </main>
  </div>
</template>

<script setup>
</script>
