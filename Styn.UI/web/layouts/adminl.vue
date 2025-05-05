<template>
    <div class="min-h-screen bg-gray-100">
      <AppSidebar :is-open="isSidebarOpen" @toggle="toggleSidebar" />
      
      <div class="flex flex-col" :class="{ 'md:ml-64': isSidebarOpen, 'md:ml-16': !isSidebarOpen }">
        <AppNavbar @toggle-sidebar="toggleSidebar" />
        
        <main class="flex-1 p-6">
          <slot />
        </main>
        
      </div>
    </div>
  </template>
  
  <script>
  import AppSidebar from "@/components/app/Sidebar.vue"
  import AppNavbar from "@/components/app/Navbar.vue"
  
  export default {
    name: "DefaultLayout",
    components: {
      AppSidebar,
      AppNavbar,
    },
    data() {
      return {
        isSidebarOpen: true,
      }
    },
    methods: {
      toggleSidebar() {
        this.isSidebarOpen = !this.isSidebarOpen
      },
    },
  }
  </script>
  