<template>
  <div class="flex flex-col md:flex-row justify-between items-center space-y-3 md:space-y-0 p-4">
    <span class="text-sm font-normal text-gray-500 dark:text-gray-400">
      Mostrando <span class="font-semibold text-gray-900 dark:text-white">{{ startItem }}-{{ endItem }}</span> de <span class="font-semibold text-gray-900 dark:text-white">{{ total }}</span>
    </span>
    <div class="inline-flex mt-2 xs:mt-0">
      <button 
        @click="changePage(currentPage - 1)" 
        :disabled="currentPage === 1"
        class="flex items-center justify-center px-3 h-8 text-sm font-medium text-white bg-primary-600 rounded-l hover:bg-primary-700 dark:bg-primary-600 dark:hover:bg-primary-700 disabled:opacity-50 disabled:cursor-not-allowed"
      >
        <Icon name="lucide:chevron-left" class="w-4 h-4 mr-1" />
        Anterior
      </button>
      <button 
        @click="changePage(currentPage + 1)" 
        :disabled="currentPage === totalPages"
        class="flex items-center justify-center px-3 h-8 text-sm font-medium text-white bg-primary-600 border-0 border-l border-gray-700 rounded-r hover:bg-primary-700 dark:bg-primary-600 dark:hover:bg-primary-700 disabled:opacity-50 disabled:cursor-not-allowed"
      >
        Siguiente
        <Icon name="lucide:chevron-right" class="w-4 h-4 ml-1" />
      </button>
    </div>
  </div>
</template>

<script setup>
import { computed } from 'vue'

const props = defineProps({
  total: {
    type: Number,
    required: true,
  },
  currentPage: {
    type: Number,
    default: 1,
  },
  perPage: {
    type: Number,
    default: 10,
  },
})

const emit = defineEmits(['page-change'])

const totalPages = computed(() => Math.ceil(props.total / props.perPage))

const startItem = computed(() => {
  if (props.total === 0) return 0
  return (props.currentPage - 1) * props.perPage + 1
})

const endItem = computed(() => {
  const end = props.currentPage * props.perPage
  return end > props.total ? props.total : end
})

const changePage = (page) => {
  if (page < 1 || page > totalPages.value) return
  emit('page-change', page)
}
</script>
