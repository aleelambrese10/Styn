<template>
    <div class="relative">
        <input 
            type="text" 
            :value="formattedTime" 
            readonly
            @click="toggleDropdown"
            class="w-full px-4 py-2 border rounded-lg cursor-pointer focus:outline-none focus:ring-2 focus:ring-teal-500"
            :placeholder="placeholder"
        >
        
        <div v-if="isOpen" 
             class="absolute mt-1 w-64 bg-white border rounded-lg shadow-lg z-50">
            <div class="p-4 flex justify-between items-center">
                <!-- Horas -->
                <div class="flex flex-col items-center">
                    <button type="button" @click="adjustHour(1)" 
                            class="p-2 hover:bg-gray-100 rounded">
                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 15l7-7 7 7" />
                        </svg>
                    </button>
                    <span class="text-xl font-semibold my-2">{{ hours.toString().padStart(2, '0') }}</span>
                    <button type="button" @click="adjustHour(-1)"
                            class="p-2 hover:bg-gray-100 rounded">
                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                        </svg>
                    </button>
                </div>

                <span class="text-xl font-bold">:</span>

                <!-- Minutos -->
                <div class="flex flex-col items-center">
                    <button type="button" @click="adjustMinute(1)"
                            class="p-2 hover:bg-gray-100 rounded">
                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 15l7-7 7 7" />
                        </svg>
                    </button>
                    <span class="text-xl font-semibold my-2">{{ minutes.toString().padStart(2, '0') }}</span>
                    <button type="button" @click="adjustMinute(-1)"
                            class="p-2 hover:bg-gray-100 rounded">
                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                        </svg>
                    </button>
                </div>

                <!-- AM/PM -->
                <div class="flex flex-col items-center">
                    <button type="button" @click="togglePeriod"
                            class="p-2 hover:bg-gray-100 rounded">
                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 15l7-7 7 7" />
                        </svg>
                    </button>
                    <span class="text-xl font-semibold my-2">{{ period }}</span>
                    <button type="button" @click="togglePeriod"
                            class="p-2 hover:bg-gray-100 rounded">
                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                        </svg>
                    </button>
                </div>
            </div>

            <div class="border-t p-2 flex justify-end">
                <button type="button" 
                        @click="confirmTime" 
                        class="px-4 py-2 bg-teal-600 text-white rounded hover:bg-teal-700">
                    Aceptar
                </button>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, computed } from 'vue';

const props = defineProps({
    modelValue: {
        type: String,
        default: ''
    },
    placeholder: {
        type: String,
        default: 'Seleccionar hora'
    }
});

const emit = defineEmits(['update:modelValue']);

const isOpen = ref(false);
const hours = ref(12);
const minutes = ref(0);
const period = ref('AM');

// Formatear la hora para mostrar
const formattedTime = computed(() => {
    if (!hours.value) return '';
    return `${hours.value.toString().padStart(2, '0')}:${minutes.value.toString().padStart(2, '0')} ${period.value}`;
});

// Ajustar horas
const adjustHour = (delta) => {
    hours.value = ((hours.value + delta - 1 + 12) % 12) + 1;
};

// Ajustar minutos
const adjustMinute = (delta) => {
    minutes.value = (minutes.value + delta + 60) % 60;
};

// Cambiar entre AM/PM
const togglePeriod = () => {
    period.value = period.value === 'AM' ? 'PM' : 'AM';
};

// Mostrar/ocultar el selector
const toggleDropdown = () => {
    isOpen.value = !isOpen.value;
};

// Confirmar la selección
const confirmTime = () => {
    emit('update:modelValue', formattedTime.value);
    isOpen.value = false;
};

// Cerrar al hacer clic fuera
const handleClickOutside = (event) => {
    if (!event.target.closest('.time-picker')) {
        isOpen.value = false;
    }
};

// Inicializar con valor existente si existe
if (props.modelValue) {
    const [time, period] = props.modelValue.split(' ');
    const [hour, minute] = time.split(':');
    hours.value = parseInt(hour);
    minutes.value = parseInt(minute);
    period.value = period;
}
</script> 