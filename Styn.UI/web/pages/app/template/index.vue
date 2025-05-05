<template>
  <div class="container mx-auto px-4">
    <h1 class="text-2xl font-bold mb-4">{{ title }}</h1>

    <!-- Búsqueda -->
    <div class="mt-8">
      <!-- <h2 class="text-lg font-bold mb-2">Buscar por DNI:</h2> -->
      <div class="items-center justify-between block sm:flex md:divide-x md:divide-gray-100 dark:divide-gray-700">
        <div class="flex items-center mb-4 sm:mb-0">
          <form class="sm:pr-3">
            <div class="relative w-48 mt-1 sm:w-64 xl:w-96">
              <Search :modelValue="searchQuery" @update:modelValue="searchQuery = $event" placeholder="Buscar..." />
            </div>
          </form>

        </div>
        <button @click="editVisible = true"
          class="text-white bg-blue-500 focus:ring-1 focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 dark:bg-primary-600 dark:hover:bg-primary-700 focus:outline-none dark:focus:ring-primary-800"
          type="button" data-drawer-target="drawer-create-product-default"
          data-drawer-show="drawer-create-product-default" aria-controls="drawer-create-product-default"
          data-drawer-placement="right">
          Añadir nuevo
        </button>
      </div>

      <Table :headers="table.headers" :items="insumosFiltrados" :actions="table.actions" @action="handleAction" />
      <!-- Asegúrate de importar el componente Edit adecuado para los insumos -->
      <Edit :visible="editVisible" :data="dataEditable" @update="handleUpdate" @close="handleClose" />

    </div>
  </div>
</template>

<script >
import Edit from './edit.vue'; // Asegúrate de que la ruta sea correcta
import { reactive, toRefs, ref, computed } from 'vue'
// import { toUrl } from '@/helpers/routing.js'
import Table from '../../components/Table.vue'; // Asegúrate de que la ruta sea correcta
import Search from '../../components/filters/Search.vue'; // Asegúrate de que la ruta sea correcta
// import insumoService from '../../services/insumoService';
import _dataService from '../../services/mock/mockUsuarioService';

export default {
  name: "Insumo",
  components: {
    Table,
    Edit,
    Search

  },
  setup() {

    const dataEditable = ref({});
    const searchQuery = ref('');

    // State reactiva para el componente
    const state = reactive({
      visible: false,
      data: [],
      editVisible: false,
      ocultarGuardar: false,
      title: 'Usuarios'
    });

    const table = reactive({
      headers: ['Id', 'Nombre', 'Apellido', 'Fecha de Validez','Estado'],
      actions: {
        edit: {
          id: 'edit',
          name: 'Edit',
          icon: "fa fa-edit",
          showName: false,
          // to: toUrl('/admin/insumos/{id}/edit'),
          danger: false
        },
        delete: {
          id: 'delete',
          name: 'Eliminar',
          icon: "fa fa-trash",
          showName: false,
          danger: true,
        }
      },
    })




    const fetchInsumos = async () => {
      try {
        const data = await _dataService.getAll();
        state.data = data
        state.data.forEach(d => {
          delete d.imagenPrincipal
        })
      } catch (error) {
        console.error(error);
      }
    };

    const handleUpdate = async (data) => {
      state.editVisible = false;

      if (data.isNew) {
        await _dataService.add(data)
        fetchInsumos()
      }
      else {
        await _dataService.edit(data.id, data)

      }
    };

    const handleClose = () => {
      dataEditable.value = {}
      state.editVisible = false;
      fetchInsumos()

    };

    const eliminarData = async (data) => {
      await _dataService.remove(data)
      fetchInsumos()
    };

    const updateData = async (data) => {
      dataEditable.value = data;
      fetchInsumos()

    };

    const createData = async (data) => {
      await _dataService.add(data)
      fetchInsumos()

    };

    const insumosFiltrados = computed(() => {
      return searchQuery.value
        ? state.data.filter((insumo) =>
          insumo.nombre.toLowerCase().includes(searchQuery.value.toLowerCase())
        )
        : state.data;
    });


    const filteredItems = computed(() => {
      if (!searchTerm.value) {
        return props.items;
      }
      return props.items.filter((item) =>
        item.nombre.toLowerCase().includes(searchTerm.value.toLowerCase())
      );
    });

    const filterItems = (query) => {
      searchQuery.value = query;
    };

   

    const handleAction = ({ actionId, item }) => {
      if (actionId.id === 'edit') {
        dataEditable.value = item;
        state.editVisible = true;
      } else if (actionId.id === 'delete' && confirm('¿Estás seguro de que deseas eliminar estos datos?')) {
        eliminarData(item.id);
      }
    };


    fetchInsumos();


    // Exponer las propiedades y funciones reactivas
    return {
      dataEditable,
      ...toRefs(state),
      eliminarData,
      handleClose,
      updateData,
      createData,
      table,
      handleAction,
      handleUpdate,
      filteredItems,
      filterItems,
      insumosFiltrados,
      searchQuery,
      fetchInsumos
    };
  }
};

definePageMeta({
  layout: 'adminl'
})


</script>

<style></style>
