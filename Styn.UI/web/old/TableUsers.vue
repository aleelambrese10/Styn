<template>
  <div class="table-container mt-4 overflow-x-auto">
    <table class="w-full bg-white border border-orange-200">
      <thead class="bg-orange-200">
        <tr>
          <th
            scope="col"
            v-for="header in headers"
            :key="header"
            class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
          >
             <slot :name="`header-${header}`">{{ header }}</slot>
          </th>
          <th
            scope="col"
            class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
          >
            ACCIONES
          </th>
        </tr>
      </thead>
      <tbody class="divide-y divide-gray-200">
        <tr v-for="item in items" :key="item.id">
          <template
            v-for="(value, name) in item"
            :key="`item-${item.id}-${name}`"
          >
            <!-- Omitir la columna si el nombre de la propiedad es profileImagePath -->
            <template
              v-if="
                name !== 'profileImagePath' &&
                name !== 'id' &&
                name !== 'tiendaId'
              "
            >
              <td class="px-6 py-4 whitespace-nowrap">
                <!-- Personalización para la imagen y el nombre -->
                <template v-if="name === 'nombre'">
                  <div class="flex items-center">
                    <img
                      class="w-10 h-10 rounded-full"
                      src="../assets/images/icon.png"
                      alt="User image"
                    />
                    <div class="ps-3">
                      <div class="text-base font-semibold">
                        {{ item.nombre }}
                      </div>
                      <div class="font-normal text-gray-500">
                        {{ item.email }}
                      </div>
                    </div>
                  </div>
                </template>
                <!-- Renderizado estándar para otras propiedades -->
                <template v-else>
                  {{ value }}
                </template>
              </td>
            </template>
          </template>

          <!-- <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
            <slot name="actions" :item="item"></slot>
          </td> -->
          <td
            class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium"
          >
            <div class="flex space-x-2">
              <template
                v-for="(action, index) in Object.values(actions)"
                :key="index"
              >
                <button
                  :class="['btn', action.colorClass]"
                  @click="onActionClick(action, item)"
                >
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
import { defineComponent, toRefs } from "vue";
import userService from "~/services/userService";

export default defineComponent({
  name: "TableUsers",
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
    const user = userData();

    const fetchData = async () => {
      try {
        const data = await userService.getAll();
        items.value = data
        
        //("Datos recuperados: ",items.value)
        emitTablaData();
      } catch (error) {
        console.error(error);
      }
    };

    const emitTablaData = () =>{
      emit("get-table-data", items.value);
    }

    // Emite un evento personalizado con el id de la acción y el item
    const onActionClick = (actionName, item) => {
      emit("action", { actionId: actionName, item });
    };

    const getFullImagePath = (relativePath) => {
      const url = `http://tapmedicina.vylaris.online:81/api/${relativePath}`;

      return url;
    };

    onMounted(() => {
    fetchData();
    emitTablaData();
  });

    return {
      getFullImagePath,
      headers,
      items,
      actions,
      user,
      fetchData,
      emitTablaData,
      onActionClick
    };
  },
});
</script>

<style scoped>
/* Tus estilos aquí */
</style>
