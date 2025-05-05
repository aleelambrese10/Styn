<template>
  <div class="col-span-12 sm:col-span-6">
    <label :for="id" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">{{ label }}</label>
    <select :id="id" v-model="selectedValue" @change="onChange" 
    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">

      <option disabled value="">{{ placeholder }}</option>
      <option v-for="option in options" :value="option[valueField]" :key="option[valueField]">{{ option[labelField]  +  (option[secondLabelField] ?  '  ' + option[secondLabelField] : '') }}</option>
    </select>
  </div>
</template>

<script setup>
import { ref, watchEffect, defineProps, defineEmits } from 'vue';

const props = defineProps({
  id: String,
  label: String,
  options: Array,
  modelValue: [String, Number, Object],
  placeholder: String,
  valueField: String,
  labelField: String,
  secondLabelField: String,
});

const emit = defineEmits(['update:modelValue']);
const selectedValue = ref(null);

// Asegurarse de que el valor seleccionado esté actualizado con el modelValue externo
watchEffect(() => {
  selectedValue.value = props.modelValue;
});

function onChange(event) {
  const selectedOption = props.options.find(option => option[props.valueField] === event.target.value);
  emit('update:modelValue',  event.target.value);
}
</script>

<style scoped>
.select-label {
  /* Estilos para la etiqueta */
}
.select-input {
  /* Estilos para el input */
}
</style>
