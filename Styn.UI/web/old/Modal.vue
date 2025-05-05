<template>
    <div v-if="visible"
        class=" bg-gray-300 bg-opacity-50 md:mt-0 -mt-10 pb-5  fixed left-0 right-0 z-50 items-center justify-center overflow-x-hidden overflow-y-auto top-4 md:inset-0 h-modal sm:h-full flex">
        <div class="p-10 relative w-full h-full max-w-2xl   px-4 ">
            <!-- Modal content -->
            <div class="relative bg-white rounded-lg border ">
                <!-- Modal header -->
                <div class="flex items-start justify-between p-5 border-b rounded-t dark:border-gray-700">
                    <h3 class="text-xl font-semibold dark:text-white">
                        <span>{{ title }}</span>
                    </h3>
                    <button @click="closeModal()"
                        class="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm p-1.5 ml-auto inline-flex items-center dark:hover:bg-gray-700 dark:hover:text-white"
                        data-modal-toggle="add-user-modal">
                        <svg class="w-5 h-5" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd"
                                d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                                clip-rule="evenodd"></path>
                        </svg>
                    </button>
                </div>
                <!-- Modal body -->
                <div class="p-6 space-y-6">
                    <form action="#">
                        <div class="grid grid-cols-12 gap-6">
                            <slot :isNumeric="isNumeric"></slot> <!-- El contenido específico del modal se insertará aquí -->
                        </div>
                    </form>
                </div>
                <!-- Modal footer  -->
                <div class="flex justify-between items-center p-6 border-t border-gray-200 dark:border-gray-700">
                    <slot name="footer">
                    </slot>

                </div>
            </div>
        </div>
    </div>
</template>
  
<script>
import { ref, watch, defineComponent, toRefs } from 'vue';

export default defineComponent({
    props: {
        visible: Boolean,
        title: String,
        isNumeric: { 
            type: Boolean,
            default: false,
        },
    },
    emits: ['update:visible'],
    setup(props, { emit }) {
        // toRefs convierte cada propiedad reactiva en una referencia reactiva independiente
        const { visible } = toRefs(props);

        // watch es utilizado para observar cambios en las propiedades reactivas
        watch(visible, (newValue) => {
            if (!newValue) {
                closeModal();
            }
        });

        // Función para cerrar el modal y emitir un evento al padre
        const closeModal = () => {
            emit('update:visible', false);
        };

        // Devuelve lo que se utilizará en el template
        return {
            closeModal,
        };
    },
});
</script>
  
  
<style scoped>

</style>
  