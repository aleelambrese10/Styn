<template>
  <div class="min-h-screen bg-gray-50 dark:bg-gray-900">
    <Sidebar :is-open="isSidebarOpen" @toggle="toggleSidebar" />
    
    <div :class="[
      'transition-all duration-300 ease-in-out',
      isSidebarOpen ? 'sm:ml-64' : 'sm:ml-16'
    ]">
      <Navbar @toggle-sidebar="toggleSidebar" />
      
      <main class="p-4 md:p-6">
        <slot />
      </main>
      
      <Footer />
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'

const isSidebarOpen = ref(true)

const toggleSidebar = () => {
  isSidebarOpen.value = !isSidebarOpen.value
}
</script>
