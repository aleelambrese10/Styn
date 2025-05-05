<template>
    <div v-if="show" 
         class="fixed top-4 right-4 flex items-center p-4 mb-4 rounded-lg shadow-lg"
         :class="typeClasses"
         role="alert">
        <div class="flex items-center">
            <!-- Icono de éxito -->
            <svg v-if="type === 'success'" class="w-5 h-5 mr-2" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5Zm3.707 8.207-4 4a1 1 0 0 1-1.414 0l-2-2a1 1 0 0 1 1.414-1.414L9 10.586l3.293-3.293a1 1 0 0 1 1.414 1.414Z"/>
            </svg>
            <!-- Icono de error -->
            <svg v-if="type === 'error'" class="w-5 h-5 mr-2" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5Zm3.5 13.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0Zm-3-5a1 1 0 0 1-2 0V5a1 1 0 0 1 2 0v4Z"/>
            </svg>
            <span class="text-sm font-semibold">{{ message }}</span>
        </div>
        <button @click="close" 
                class="ml-4 -mx-1.5 -my-1.5 rounded-lg p-1.5 inline-flex h-8 w-8 hover:bg-opacity-25 hover:bg-gray-100" 
                :class="buttonClasses">
            <svg class="w-3 h-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 14">
                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6"/>
            </svg>
        </button>
    </div>
</template>

<script setup>
import { computed } from 'vue';

const props = defineProps({
    show: {
        type: Boolean,
        default: false
    },
    message: {
        type: String,
        required: true
    },
    type: {
        type: String,
        default: 'success',
        validator: (value) => ['success', 'error'].includes(value)
    }
});

const emit = defineEmits(['close']);

const typeClasses = computed(() => ({
    'text-green-800 bg-green-50': props.type === 'success',
    'text-red-800 bg-red-50': props.type === 'error'
}));

const buttonClasses = computed(() => ({
    'text-green-800': props.type === 'success',
    'text-red-800': props.type === 'error'
}));

const close = () => {
    emit('close');
};
</script> 