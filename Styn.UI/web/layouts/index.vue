<template>
    <div class="min-h-screen">
        <Navbar @toggle-sidebar="toggleSidebar" />
        <Sidebar v-model:isOpen="isSidebarOpen" />
        <main class="pt-16 px-4" :class="{ 'ml-64': isSidebarOpen }">
            <slot />
        </main>
    </div>
</template>

<script setup>
import { ref } from 'vue';
import Navbar from './Navbar.vue';
import Sidebar from './Sidebar.vue';

const isSidebarOpen = ref(false);

const toggleSidebar = () => {
    isSidebarOpen.value = !isSidebarOpen.value;
};
</script>   