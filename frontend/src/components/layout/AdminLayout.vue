<template>
  <div class="admin-layout">
    <aside class="sidebar">
      <h3>Admin Panel</h3>
      <nav>
        <router-link to="/admin/products">Products</router-link>
        <router-link to="/admin/orders">Orders</router-link>
        <router-link to="/admin/users">Users</router-link>
        <router-link to="/">Back to Site</router-link>
      </nav>
    </aside>
    <main class="content">
      <router-view />
    </main>
  </div>
</template>

<script setup>
</script>

<style scoped>
.admin-layout {
  display: flex;
  min-height: 100vh;
}
.sidebar {
  width: 250px;
  background: #2c3e50;
  color: white;
  padding: 1rem;
}
.sidebar nav a {
  display: block;
  color: white;
  padding: 0.5rem;
  text-decoration: none;
}
.content {
  flex: 1;
  padding: 2rem;
}
</style>
