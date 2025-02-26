<template>
    <!-- Overlay para detectar clicks fuera -->
    <div v-if="isOpen" 
         class="fixed inset-0 bg-black bg-opacity-50 z-20"
         @click="closeSidebar">
    </div>

    <!-- Sidebar -->
    <div class="fixed inset-y-0 left-0 w-64 bg-teal-600 text-white transform transition-transform duration-300 z-30"
        :class="{ '-translate-x-full': !isOpen }">
        <div class="p-4">
            <nav class="space-y-2">
                <router-link to="/" 
                            class="block py-2.5 px-4 rounded transition duration-200 hover:bg-teal-700"
                            @click="closeSidebar">
                    Inicio
                </router-link>
                
                <div class="relative">
                    <button @click="toggleProcesos" 
                            class="w-full flex items-center justify-between py-2.5 px-4 rounded transition duration-200 hover:bg-teal-700">
                        <span>Procesos</span>
                        <svg :class="{ 'rotate-180': showProcesos }" class="w-4 h-4 transition-transform" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                        </svg>
                    </button>
                    <div v-show="showProcesos" class="pl-4">
                        <router-link to="/tarjeta" 
                                    class="block py-2 px-4 hover:bg-teal-700"
                                    @click="closeSidebar">
                            Tarjeta de crédito/débito
                        </router-link>
                        <router-link to="/mercado-pago" 
                                    class="block py-2 px-4 hover:bg-teal-700"
                                    @click="closeSidebar">
                            Mercado Pago
                        </router-link>
                        <router-link to="/transferencias" 
                                    class="block py-2 px-4 hover:bg-teal-700"
                                    @click="closeSidebar">
                            Informar Transferencias
                        </router-link>
                    </div>
                </div>

                <div class="relative">
                    <button @click="toggleInformes" 
                            class="w-full flex items-center justify-between py-2.5 px-4 rounded transition duration-200 hover:bg-teal-700">
                        <span>Informes</span>
                        <svg :class="{ 'rotate-180': showInformes }" class="w-4 h-4 transition-transform" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                        </svg>
                    </button>
                </div>

                <div class="relative">
                    <button @click="toggleInformacion" 
                            class="w-full flex items-center justify-between py-2.5 px-4 rounded transition duration-200 hover:bg-teal-700">
                        <span>Información</span>
                        <svg :class="{ 'rotate-180': showInformacion }" class="w-4 h-4 transition-transform" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                        </svg>
                    </button>
                </div>
            </nav>
        </div>
    </div>
</template>

<script setup>
import { ref } from 'vue';

const props = defineProps({
    isOpen: {
        type: Boolean,
        default: false
    }
});

const emit = defineEmits(['update:isOpen']);

const showProcesos = ref(false);
const showInformes = ref(false);
const showInformacion = ref(false);

const toggleProcesos = () => showProcesos.value = !showProcesos.value;
const toggleInformes = () => showInformes.value = !showInformes.value;
const toggleInformacion = () => showInformacion.value = !showInformacion.value;

const closeSidebar = () => {
    emit('update:isOpen', false);
};
</script>