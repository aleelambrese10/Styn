<template>
    <div v-if="visible" id="marketing-banner" tabindex="-1"
        class="fixed z-50 flex flex-col md:flex-row justify-between w-[calc(100%-2rem)] p-4 -translate-x-1/2 bg-white border border-gray-100 rounded-lg shadow-sm lg:max-w-2xl left-1/2 top-6 dark:bg-gray-700 dark:border-gray-600"
        aria-live="assertive">
      <div class="flex flex-col items-start mb-3 me-4 md:items-center md:flex-row md:mb-0">
  
        <svg class="flex-shrink-0 inline w-4 h-4 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
            fill="currentColor" viewBox="0 0 20 20">
          <!-- SVG path here -->
        </svg>
        <span class="sr-only">Info</span>
        <svg class="flex-shrink-0 inline w-4 h-4 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                fill="currentColor" viewBox="0 0 20 20">
                <path
                    d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z" />
            </svg>
        <div :class="textColorClass">            
          <span class="font-medium"></span> {{ message }}
        </div>
      </div>
     

    <div class="flex items-center flex-shrink-0">

<button @click="closeBanner" type="button"
    class="flex-shrink-0 inline-flex justify-center w-7 h-7 items-center text-gray-400 hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm p-1.5 dark:hover:bg-gray-600 dark:hover:text-white">
    <svg class="w-3 h-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none"
        viewBox="0 0 14 14">
        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
            d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6" />
    </svg>
    <span class="sr-only">Close banner</span>
</button>
</div>
    </div>
  </template>
  
  <script setup>
  import { ref, computed, defineProps,toRefs } from 'vue';
  
  const props = defineProps({
    title: {
      type: String,
      default: 'Alert Title'
    },
    message: {
      type: String,
      default: 'Your message goes here.'
    },
    color: {
      type: String,
      default: 'dark' // you can change this to any color you want to define
    },
    visible: {
      type: Boolean,
      default: true
    }
  });
  
  const {visible,message} = toRefs(props);
  
  const closeBanner = () => {
    visible.value = false;
  };
  
  const textColorClass = computed(() => {
    switch (props.color) {
      case 'dark':
        return 'text-gray-700 dark:text-white';
      case 'red':
        return 'text-red-700 dark:text-red-300';
      case 'green':
        return 'text-green-700 dark:text-green-300';
      // Add more colors as needed
      default:
        return 'text-gray-700 dark:text-white';
    }
  });
  </script>