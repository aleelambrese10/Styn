<template>
  <form class="max-w-md mx-auto">
    <label
      for="dni-search"
      class="mb-2 text-sm font-medium text-gray-900 sr-only dark:text-white"
    >
      Search by DNI...
    </label>
    <div class="relative">
      <div class="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
        <svg
          class="w-4 h-4 text-gray-500 dark:text-gray-400"
          aria-hidden="true"
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 20 20"
        >
          <path
            stroke="currentColor"
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
          />
        </svg>
      </div>
      <input
        type="search"
        id="dni-search"
        class="block w-full p-4 ps-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
        placeholder="Search by DNI..."
        required
        v-model="searchTerm"
        @input="onSearch"
      />
    </div>

    <ul
      v-if="filteredItems.length"
      class="mt-2 max-h-40 overflow-y-auto border border-gray-300 rounded-lg bg-white dark:bg-gray-800"
    >
      <li
        v-for="(item, index) in filteredItems"
        :key="index"
        class="px-4 py-2 cursor-pointer hover:bg-gray-100 dark:hover:bg-gray-700"
        @click="selectItem(item)"
      >
        <div>{{ item.dni }}</div>
        <div class="text-sm text-gray-600">
          {{ item.direccion }} - {{ item.email }}
        </div>
      </li>
    </ul>
  </form>
</template>

<script setup>
import { ref, computed } from "vue";
const emit = defineEmits(["item-selected"]);

// Asumiendo que el error estaba en cómo accedes a "items" después de definirlo
const { items } = defineProps({
  items: Array,
});

const searchTerm = ref("");

// Computamos los elementos filtrados en función del término de búsqueda y los elementos pasados como prop.
const filteredItems = computed(() => {
  if (searchTerm.value) {
    return items.filter((item) =>
      item.dni.toLowerCase().includes(searchTerm.value.toLowerCase())
    );
  }
  return items; // Mostrar todos los elementos si no hay término de búsqueda
});

function selectItem(item) {
  // Emitimos el evento con el elemento seleccionado
  emit("item-selected", item);
}

function onSearch() {
  // Puedes manejar otras lógicas si es necesario
}
</script>