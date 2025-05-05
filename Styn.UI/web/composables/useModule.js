import { ref } from "vue"

export function useModule(options = {}) {
  const { fetchItems, createItem, updateItem, deleteItem, defaultFilters = {}, defaultPerPage = 10 } = options

  // Estado
  const items = ref([])
  const selectedItem = ref(null)
  const loading = ref(false)
  const error = ref(null)
  const isModalOpen = ref(false)
  const isConfirmModalOpen = ref(false)
  const currentPage = ref(1)
  const perPage = ref(defaultPerPage)
  const totalItems = ref(0)
  const searchQuery = ref("")
  const activeFilters = ref({ ...defaultFilters })

  // Métodos
  const fetchData = async () => {
    loading.value = true
    error.value = null

    try {
      const response = await fetchItems({
        page: currentPage.value,
        perPage: perPage.value,
        search: searchQuery.value,
        filters: activeFilters.value,
      })

      items.value = response.data
      totalItems.value = response.total
    } catch (err) {
      error.value = err.message || "Error al cargar los datos"
      console.error("Error fetching data:", err)
    } finally {
      loading.value = false
    }
  }

  const openModal = (item = null) => {
    selectedItem.value = item
    isModalOpen.value = true
  }

  const closeModal = () => {
    selectedItem.value = null
    isModalOpen.value = false
  }

  const saveItem = async (itemData) => {
    loading.value = true
    error.value = null

    try {
      if (itemData.id) {
        await updateItem(itemData)
      } else {
        await createItem(itemData)
      }
      await fetchData()
      closeModal()
    } catch (err) {
      error.value = err.message || "Error al guardar los datos"
      console.error("Error saving item:", err)
    } finally {
      loading.value = false
    }
  }

  const confirmDelete = (item) => {
    selectedItem.value = item
    isConfirmModalOpen.value = true
  }

  const deleteItemConfirmed = async () => {
    if (!selectedItem.value) return

    loading.value = true
    error.value = null

    try {
      await deleteItem(selectedItem.value.id)
      await fetchData()
      isConfirmModalOpen.value = false
      selectedItem.value = null
    } catch (err) {
      error.value = err.message || "Error al eliminar los datos"
      console.error("Error deleting item:", err)
    } finally {
      loading.value = false
    }
  }

  const handleFilterChange = (filters) => {
    activeFilters.value = filters
    currentPage.value = 1 // Reset to first page when filters change
    fetchData()
  }

  const handleSearch = (query) => {
    searchQuery.value = query
    currentPage.value = 1 // Reset to first page when search changes
    fetchData()
  }

  const handlePageChange = (page) => {
    currentPage.value = page
    fetchData()
  }

  return {
    // Estado
    items,
    selectedItem,
    loading,
    error,
    isModalOpen,
    isConfirmModalOpen,
    currentPage,
    perPage,
    totalItems,
    searchQuery,
    activeFilters,

    // Métodos
    fetchData,
    openModal,
    closeModal,
    saveItem,
    confirmDelete,
    deleteItemConfirmed,
    handleFilterChange,
    handleSearch,
    handlePageChange,
  }
}
