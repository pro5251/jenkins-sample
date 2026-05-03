<template>
  <div id="app" class="min-h-screen flex flex-col">
    <Header v-if="!isAdminRoute" />
    <main class="flex-1">
      <router-view />
    </main>
    <Footer v-if="!isAdminRoute" />
  </div>
</template>

<script setup>
import { computed } from 'vue'
import { useRoute } from 'vue-router'
import Header from './components/layout/Header.vue'
import Footer from './components/layout/Footer.vue'

const route = useRoute()

const isAdminRoute = computed(() => route.path.startsWith('/admin'))
</script>