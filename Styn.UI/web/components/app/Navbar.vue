<template>
  <nav class="bg-[#003C53] border-[#003C53] border-b px-4 py-2.5 dark:bg-[#003C53] dark:border-gray-700 sticky top-0 z-30">
    <div class="flex flex-wrap justify-between items-center">
      <div class="flex items-center justify-start">
        <button 
          @click="$emit('toggle-sidebar')" 
          class="p-2 mr-2 text-gray-600 rounded-lg hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-700 lg:hidden"
        >
          <Icon name="lucide:menu" class="w-6 h-6" />
        </button>
        <div class="flex items-center justify-between">
          <span class="self-center text-xl font-semibold sm:text-2xl whitespace-nowrap dark:text-white hidden lg:block">
            {{ pageTitle }}
          </span>
        </div>
      </div>
      
      <div class="flex items-center lg:order-2">
        <button 
          @click="toggleColorMode"
          class="p-2 text-gray-500 rounded-lg hover:bg-gray-100 dark:text-gray-400 dark:hover:bg-gray-700 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:focus:ring-gray-700"
        >
          <Icon v-if="colorMode.value === 'dark'" name="lucide:sun" class="w-5 h-5" />
          <Icon v-else name="lucide:moon" class="w-5 h-5" />
        </button>
        
        <button 
          @click="toggleProfileMenu" 
          class="flex mx-3 text-sm bg-gray-800 rounded-full md:mr-0 focus:ring-4 focus:ring-gray-300 dark:focus:ring-gray-600"
        >
          <img class="w-8 h-8 rounded-full" src="https://flowbite.com/docs/images/people/profile-picture-5.jpg" alt="user photo">
        </button>
        
        <div 
          v-if="isProfileMenuOpen" 
          class="absolute top-10 right-4 z-50 my-4 text-base list-none bg-white divide-y divide-gray-100 rounded shadow dark:bg-gray-700 dark:divide-gray-600 profile-menu"
        >
          <div class="px-4 py-3">
            <span class="block text-sm text-gray-900 dark:text-white">Admin User</span>
            <span class="block text-sm font-medium text-gray-500 truncate dark:text-gray-400">admin@example.com</span>
          </div>
          <ul class="py-1">
            <li>
              <NuxtLink to="/profile" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 dark:hover:bg-gray-600 dark:text-gray-200 dark:hover:text-white">
                Mi Perfil
              </NuxtLink>
            </li>
            <li>
              <NuxtLink to="/settings" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 dark:hover:bg-gray-600 dark:text-gray-200 dark:hover:text-white">
                Configuración
              </NuxtLink>
            </li>
            <li>
              <a href="#" @click.prevent="logout" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 dark:hover:bg-gray-600 dark:text-gray-200 dark:hover:text-white">
                Cerrar Sesión
              </a>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </nav>
</template>

<script setup>
import { ref, computed } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useColorMode } from '@vueuse/core'
import { onMounted, onUnmounted } from 'vue';

const route = useRoute()
const router = useRouter()
const colorMode = useColorMode()

const isProfileMenuOpen = ref(false)

const pageTitle = computed(() => {
  // Map routes to titles
  const titles = {
    '/': 'Dashboard',
    '/modules/users': 'Gestión de Usuarios',
    '/modules/products': 'Gestión de Productos',
    '/modules/categories': 'Gestión de Categorías',
    '/settings': 'Configuración',
  }
  
  return titles[route.path] || 'Admin Panel'
})

const toggleProfileMenu = () => {
  isProfileMenuOpen.value = !isProfileMenuOpen.value
}

const toggleColorMode = () => {
  colorMode.preference = colorMode.value === 'dark' ? 'light' : 'dark'
}

const logout = () => {
  // Implementar lógica de cierre de sesión
  localStorage.removeItem('auth_token')
  router.push('/login')
}

// Close profile menu when clicking outside
const handleClickOutside = (event) => {
    if (isProfileMenuOpen.value) {
        const profileMenu = document.querySelector('.profile-menu');
        if (profileMenu && !profileMenu?.contains(event.target)) {
            isProfileMenuOpen.value = false;
        }
    }
};

onMounted(() => {
    document.addEventListener('mousedown', handleClickOutside);
});

onUnmounted(() => {
    document.removeEventListener('mousedown', handleClickOutside);
});

defineEmits(['toggle-sidebar'])
</script>
