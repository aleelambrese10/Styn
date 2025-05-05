<template>
  <Modal :visible="visible" @update:visible="closeForm" :title="modal.title">
    <Input id="nombre" label="Nombre" placeholder="" v-model="data.nombre" />
    <Input id="apellido" label="Apellido" placeholder="" v-model="data.apellido" />
    <!-- <Input id="costo" type="number" label="Costo" placeholder="" v-model="data.costo" /> -->
    <Input id="estado" label="Costo" placeholder="" v-model="data.estado" />
    <!-- <Input id="precio" type="number" label="Precio" placeholder="" v-model="data.precioVenta" /> -->
    <!-- <Input type="file" id="imagen" label="Imagen" @change="handleImageUpload" /> -->

    <template #footer>
      <button @click="handleSubmit"
        class="text-white bg-primary-500 focus:ring-2 focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
        type="submit">{{ buttonText }}</button>
      <div v-if="validateInput" class="bg-red-500 text-white p-2 px-4 rounded-lg">
        <p>Por favor rellene todos los campos</p>
      </div>
    </template>
  </Modal>
</template>

<script>
import { ref, toRefs, watch, computed } from 'vue';
import Input from '../../components/Input.vue';
import Modal from '../../components/Modal.vue';
// import { subirImagen } from '../../../../services/cloudinaryService';
export default {
  components: {
    Input,
    Modal
  },
  props: {
    visible: Boolean,
    data: Object,
  },
  emits: ['update', 'close'],
  setup(props, { emit }) {
    const { data, visible } = toRefs(props);
    const isEditing = ref(false);
    const validateInput = ref(false); // O el valor que corresponda
    const imageFile = ref()
    // Utilizamos computed para determinar el texto del botón de forma reactiva
    const buttonText = computed(() => {
      return data.value.id ? 'Actualizar data' : 'Agregar data';
    });

    const modal = ref({
      title: "Gestionar data",
      visible: false // Suponiendo que también quieras manejar la visibilidad dentro del mismo objeto
    });

    // Use a watcher to determine if we're in editing mode
    watch(visible, (newValue) => {
      isEditing.value = newValue.value;
    });

    const handleSubmit = () => {
      if (data.value && data.value.id) {
        handleUpdate();
      } else {
        handleCreate();
      }
    };

    const handleCreate = async () => {
      await subirImagen(imageFile.value).then(res => {
        data.value.imagenPrincipal = res
      })
      emit('update', { ...data.value, isNew: true });
      closeForm();
    };

    const handleUpdate = async () => {
      await subirImagen(imageFile.value).then(res => {
        data.value.imagenPrincipal = res
      })
      emit('update', { ...data.value, isNew: false });
      closeForm();
    };

    const closeForm = () => {
      emit('close');
    };
    const handleImageUpload = async (event) => {

      imageFile.value = event.target.files[0];


    };


    return {
      modal,
      isEditing,
      handleSubmit,
      handleCreate,
      handleUpdate,
      closeForm,
      validateInput,
      data,
      buttonText,
      handleImageUpload,
      imageFile
    };
  },
};
</script>

<style>
/* Estilos para el modal, form-group y botones */
</style>