<template>
  <div class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
    <div class="bg-white rounded-lg shadow-lg w-full max-w-md mx-auto">
      <div class="flex justify-between items-center p-4 border-b">
        <h2 class="text-lg font-semibold">
          {{ fichaAnimal ? 'Editar Ficha Animal' : 'Nueva Ficha Animal' }}
        </h2>
        <button @click="$emit('close')" class="text-gray-500 hover:text-gray-700">
          <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"></path>
          </svg>
        </button>
      </div>
      
      <form @submit.prevent="handleSubmit" class="p-4">
        <div class="space-y-4">
          <!-- RP -->
          <div>
            <label for="rp" class="block text-sm font-medium text-gray-700">RP</label>
            <input
              id="rp"
              v-model="formData.rp"
              type="text"
              required
              class="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
            />
          </div>
          
          <!-- Origen -->
          <div>
            <label for="origen" class="block text-sm font-medium text-gray-700">Origen</label>
            <select
              id="origen"
              v-model="formData.origen"
              class="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
            >
              <option value="Nacional">Nacional</option>
              <option value="Importado">Importado</option>
            </select>
          </div>
          
          <!-- Fecha de Nacimiento -->
          <div>
            <label for="fechaNacimiento" class="block text-sm font-medium text-gray-700">Fecha de Nacimiento</label>
            <input
              id="fechaNacimiento"
              v-model="formData.fechaNacimiento"
              type="date"
              required
              class="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
            />
          </div>
          
          <!-- Raza -->
          <div>
            <label for="raza" class="block text-sm font-medium text-gray-700">Raza</label>
            <select
              id="raza"
              v-model="formData.raza"
              class="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
            >
              <option value="Holstein">Holstein</option>
              <option value="Jersey">Jersey</option>
              <option value="Angus">Angus</option>
              <option value="Hereford">Hereford</option>
            </select>
          </div>
          
          <!-- Madre -->
          <div>
            <label for="madre" class="block text-sm font-medium text-gray-700">Madre</label>
            <input
              id="madre"
              v-model="formData.madre"
              type="text"
              class="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
            />
          </div>
          
          <!-- Padre -->
          <div>
            <label for="padre" class="block text-sm font-medium text-gray-700">Padre</label>
            <input
              id="padre"
              v-model="formData.padre"
              type="text"
              class="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
            />
          </div>
        </div>
        
        <div class="mt-6 flex justify-end space-x-3">
          <button
            type="button"
            @click="$emit('close')"
            class="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Cancelar
          </button>
          <button
            type="submit"
            :disabled="loading"
            class="px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 disabled:opacity-50"
          >
            {{ loading ? 'Guardando...' : 'Guardar' }}
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "FichaAnimalModal",
  props: {
    fichaAnimal: {
      type: Object,
      default: null,
    },
    loading: {
      type: Boolean,
      default: false,
    },
  },
  emits: ["close", "save"],
  data() {
    return {
      formData: {
        id: 0,
        rp: "",
        origen: "Nacional",
        fechaNacimiento: "",
        raza: "Holstein",
        madre: "",
        padre: "",
      },
    }
  },
  mounted() {
    if (this.fichaAnimal) {
      // Clonar el objeto para evitar modificar el original
      Object.keys(this.formData).forEach((key) => {
        if (key in this.fichaAnimal) {
          if (key === "fechaNacimiento") {
            // Formatear la fecha para el input date (YYYY-MM-DD)
            const date = new Date(this.fichaAnimal[key])
            this.formData[key] = date.toISOString().split("T")[0]
          } else {
            this.formData[key] = this.fichaAnimal[key]
          }
        }
      })
    }
  },
  methods: {
    handleSubmit() {
      // Convertir la fecha de string a objeto Date
      const formattedData = { ...this.formData }

      // Emitir el evento save con los datos del formulario
      this.$emit("save", formattedData)
    },
  },
}
</script>
