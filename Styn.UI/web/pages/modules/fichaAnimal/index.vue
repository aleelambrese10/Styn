<template>
  <div class="container px-4 py-6 mx-auto">
    <div class="flex items-center justify-between mb-6">
      <h1 class="text-2xl font-bold">Fichas de Animales</h1>
      <button
        @click="openModal()"
        class="px-4 py-2 text-white bg-blue-600 rounded-md hover:bg-[#34B705] focus:outline-none focus:ring-2 focus:ring-blue-500"
      >
        Nueva ficha
      </button>
    </div>

    <!-- Filtros -->
    <ModuleFilters
      :filters="filters"
      @filter-change="handleFilterChange"
      @search="handleSearch"
    />

    <!-- Tabla -->
    <ModuleTable
      :columns="columns"
      :data="fichasAnimales"
      :loading="loading"
      @edit="openModal"
      @delete="confirmDelete"

      class="mb-6"
    >
      <template #cell(fechaNacimiento)="{ item }">
        {{ formatDate(item.fechaNacimiento) }}
      </template>
  
    </ModuleTable>

    <!-- Paginación -->
    <ModulePagination
      :total="totalItems"
      :current-page="currentPage"
      :per-page="perPage"
      @page-change="handlePageChange"
    />

    <!-- Modal de Ficha Animal -->
    <FichaAnimalModal
      v-if="isModalOpen"
      :ficha-animal="selectedFichaAnimal"
      :loading="loading"
      @close="closeModal"
      @save="saveFichaAnimal"
    />

    <!-- Modal de Confirmación -->
    <ConfirmModal
      v-if="isConfirmModalOpen"
      title="Eliminar Ficha Animal"
      message="¿Está seguro que desea eliminar esta ficha animal? Esta acción no se puede deshacer."
      @confirm="deleteFichaAnimal"
      @cancel="isConfirmModalOpen = false"
    />
  </div>
</template>

<script>
import { ref, computed, onMounted } from "vue"
import { useFichaAnimalStore } from "@/stores/fichaAnimal"
import { formatDate } from "@/utils/formatters"
import ModuleFilters from "@/components/module/Filters.vue"
import ModuleTable from "@/components/module/Table.vue"
import ModulePagination from "@/components/module/Pagination.vue"
import FichaAnimalModal from "@/components/fichaAnimal/Modal.vue"
import ConfirmModal from "@/components/common/ConfirmModal.vue"
definePageMeta({
  layout:"adminl"
})
export default {
  name: "FichaAnimalPage",
  components: {
    ModuleFilters,
    ModuleTable,
    ModulePagination,
    FichaAnimalModal,
    ConfirmModal,
  },
  setup() {
    // Store
    const fichaAnimalStore = useFichaAnimalStore()

    // Estado
    const fichasAnimales = ref([])
    const loading = ref(true)
    const isModalOpen = ref(false)
    const isConfirmModalOpen = ref(false)
    const selectedFichaAnimal = ref(null)
    const currentPage = ref(1)
    const perPage = ref(10)
    const totalItems = ref(0)
    const searchQuery = ref("")
    const activeFilters = ref({})

    // Definición de columnas para la tabla
    const columns = [
      { key: "rp", label: "RP" },
      { key: "origen", label: "Origen" },
      { key: "fechaNacimiento", label: "Fecha de Nacimiento" },
      { key: "raza", label: "Raza" },
      { key: "madre", label: "Madre" },
      { key: "padre", label: "Padre" },
      { key: "actions", label: "Acciones" },
    ]

    // Definición de filtros
    const filters = [
      // {
      //   key: "raza",
      //   label: "Raza",
      //   type: "select",
      //   options: [
      //     { value: "", label: "Todas" },
      //     { value: "Holstein", label: "Holstein" },
      //     { value: "Jersey", label: "Jersey" },
      //     { value: "Angus", label: "Angus" },
      //     { value: "Hereford", label: "Hereford" },
      //   ],
      // },
      {
        key: "origen",
        label: "Origen",
        type: "select",
        options: [
          { value: "", label: "Todos" },
          { value: "Nacional", label: "Nacional" },
          { value: "Importado", label: "Importado" },
        ],
      },
    ]

    
    const fetchFichasAnimales = async () => {
      loading.value = true
      try {
        const response = await fichaAnimalStore.fetchFichasAnimales({
          page: currentPage.value,
          perPage: perPage.value,
          search: searchQuery.value,
          filters: activeFilters.value,
        })
        console.log(response)
        fichasAnimales.value = response
        totalItems.value = response.length
      } catch (error) {
        console.error("Error fetching fichas animales:", error)
      } finally {
        loading.value = false
      }
    }

    const openModal = (fichaAnimal = null) => {
      selectedFichaAnimal.value = fichaAnimal
      isModalOpen.value = true
    }

    const closeModal = () => {
      selectedFichaAnimal.value = null
      isModalOpen.value = false
    }

    const saveFichaAnimal = async (fichaData) => {
      loading.value = true
      try {
        if (fichaData.id) {
          await fichaAnimalStore.updateFichaAnimal(fichaData)
        } else {
          await fichaAnimalStore.createFichaAnimal(fichaData)
        }
        await fetchFichasAnimales()
        closeModal()
      } catch (error) {
        console.error("Error saving ficha animal:", error)
      } finally {
        loading.value = false
      }
    }

    const confirmDelete = (fichaAnimal) => {
      selectedFichaAnimal.value = fichaAnimal
      isConfirmModalOpen.value = true
    }

    const deleteFichaAnimal = async () => {
      if (!selectedFichaAnimal.value) return

      loading.value = true
      try {
        await fichaAnimalStore.deleteFichaAnimal(selectedFichaAnimal.value.id)
        await fetchFichasAnimales()
        isConfirmModalOpen.value = false
        selectedFichaAnimal.value = null
      } catch (error) {
        console.error("Error deleting ficha animal:", error)
      } finally {
        loading.value = false
      }
    }

    const handleFilterChange = (filters) => {
      activeFilters.value = filters
      currentPage.value = 1 // Reset to first page when filters change
      fetchFichasAnimales()
    }

    const handleSearch = (query) => {
      searchQuery.value = query
      currentPage.value = 1 // Reset to first page when search changes
      fetchFichasAnimales()
    }

    const handlePageChange = (page) => {
      currentPage.value = page
      fetchFichasAnimales()
    }

    // Cargar datos iniciales
    onMounted(() => {
      fetchFichasAnimales()
    })

    return {
      fichasAnimales,
      loading,
      isModalOpen,
      isConfirmModalOpen,
      selectedFichaAnimal,
      currentPage,
      perPage,
      totalItems,
      columns,
      filters,
      formatDate,
      openModal,
      closeModal,
      saveFichaAnimal,
      confirmDelete,
      deleteFichaAnimal,
      handleFilterChange,
      handleSearch,
      handlePageChange,
    }
  },
}
</script>
