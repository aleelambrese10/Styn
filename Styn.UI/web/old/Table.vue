<template>
  <div class="table-container mt-4 overflow-x-auto">
    <table class="w-full bg-white border border-gray-300">
      <thead class="bg-gray-50">
        <tr>
          <th scope="col" v-for="header in headers" :key="header"
            class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
            <slot :name="`header-${header}`">{{ header }}</slot>
          </th>
          <th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
            ACCIONES
          </th>
        </tr>
      </thead>
      <tbody class="divide-y divide-gray-200">
        <tr v-for="item in items" :key="item.id">


          <td class="px-6 py-4 whitespace-nowrap" v-for="(value, name) in item" :key="`item-${item.id}-${name}`">
          
            <!-- Personalización para el estado con indicador visual -->
            <template v-if="name === 'activo'">
              <span
                :class="`inline-flex items-center text-xs font-medium px-2.5 py-0.5 rounded-full ${value  ? 'bg-green-100 text-green-800 dark:bg-green-900 dark:text-green-300' : 'bg-red-100 text-red-800 dark:bg-red-900 dark:text-red-300'}`">
                <span
                  :class="`${value  ? 'bg-green-500' : 'bg-red-500'}` + ' w-2 h-2 me-1 rounded-full'"></span>
                {{ value ? "Activo" : "Desactivado" }}
              </span>
            </template>
            <!-- Renderizado estándar para otras propiedades que no son 'imageUrl' -->
            <template v-else-if="name !== 'estado'">
              <!-- Asegúrate de no repetir información, como nombre y correo, si ya se mostraron con imageUrl -->
              {{ value }}
            </template>
          </td>



          <!-- <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
            <slot name="actions" :item="item"></slot>
          </td> -->
          <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">



            <div class="flex space-x-2">
              <template v-for="(action, index) in Object.values(actions)" :key="index">




                <button :class="['btn', action.colorClass]" @click="onActionClick(action, item)">
                  <i :class="action.icon"></i>
                  <span v-if="action.showName">{{ action.name }}</span>
                </button>




              </template>
            </div>
          </td>

        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { defineComponent, toRefs } from 'vue';

export default defineComponent({
  name: 'Table',
  props: {
    headers: {
      type: Array,
      required: true,
    },
    items: {
      type: Array,
      required: true,
    },
    actions: {
      type: Object,
      default: () => ({}),
    },
  },
  setup(props, { emit }) {
    const { headers, items, actions } = toRefs(props);

    // Emite un evento personalizado con el id de la acción y el item
    const onActionClick = (actionName, item) => {
      emit('action', { actionId: actionName, item });
    };

    const getFullImagePath = (relativePath) => {

   
      const url = `https://localhost:44301${relativePath}`;
      console.log(url)

      return url;
};


    return {
      getFullImagePath,
      headers,
      items,
      actions,
      onActionClick,
    };
  },
});
</script>

<style scoped>
/* Tus estilos aquí */
</style>
