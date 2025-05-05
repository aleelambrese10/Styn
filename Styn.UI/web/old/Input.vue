<template>
  <div class="col-span-12 sm:col-span-6">
    <label
      :for="id"
      class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300"
      >{{ label }}</label
    >
    <input
      :disabled="disabled"
      :id="id"
      :placeholder="placeholder"
      :type="isNumeric ? 'number' : type"
      :value="inputValue"
      @input="updateValue"
      class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white"
    />
    <!-- Optional error message -->
    <p v-if="error" class="mt-2 text-sm text-red-600 dark:text-red-500">
      {{ error }}
    </p>
  </div>
</template>

<script>
import { ref, watch, defineComponent, toRefs } from "vue";

export default defineComponent({
  name: "ReusableInput",
  props: {
    id: {
      type: String,
      required: true,
    },
    label: {
      type: String,
      default: "",
    },
    placeholder: {
      type: String,
      default: "",
    },
    type: {
      type: String,
      default: "text",
    },
    disabled: {
      type: Boolean,
      default: false,
    },
    modelValue: {
      default: "",
    },
    error: {
      type: String,
      default: "",
    },
    isNumeric: { 
      type: Boolean,
      default: false,
    },
  },
  emits: ["update:modelValue"],
  setup(props, { emit }) {
    // Usando toRefs para hacer que cada prop sea reactiva individualmente
    const { modelValue } = toRefs(props);

    // Ref local para el valor de entrada
    const inputValue = ref(modelValue.value);

    // Observar el modelValue para actualizar el inputValue cuando cambie externamente
    watch(modelValue, (newVal) => {
      inputValue.value = newVal;
    });

    // Método para actualizar el valor
    const updateValue = (event) => {
      emit("update:modelValue", event.target.value);
    };

    // Devuelve lo que se utilizará en el template
    return {
      inputValue,
      updateValue,
    };
  },
});
</script>
