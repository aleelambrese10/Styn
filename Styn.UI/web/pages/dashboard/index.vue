<template>
  <div>
    <!-- Dashboard header -->
    <div class="mb-6">
      <h1 class="text-3xl font-bold text-gray-900 dark:text-white mb-2">Dashboard</h1>
      <p class="text-gray-500 dark:text-gray-400">Bienvenido al panel de administración</p>
    </div>
    
    <!-- Stats cards -->
    <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4 mb-6">
      <DashboardCard 
        title="Usuarios" 
        value="1,257" 
        icon="lucide:users" 
        color="bg-blue-100 text-blue-500"
        change="12"
        subtitle="Último mes"
      />
      <DashboardCard 
        title="Ventas" 
        value="$45,850" 
        icon="lucide:dollar-sign" 
        color="bg-green-100 text-green-500"
        change="8"
        subtitle="Último mes"
      />
      <DashboardCard 
        title="Productos" 
        value="384" 
        icon="lucide:package" 
        color="bg-purple-100 text-purple-500"
        change="-3"
        subtitle="Último mes"
      />
      <DashboardCard 
        title="Tasa de Conversión" 
        value="3.2%" 
        icon="lucide:percent" 
        color="bg-yellow-100 text-yellow-500"
        change="2"
        subtitle="Último mes"
      />
    </div>
    
    <!-- Recent activity -->
    <div class="bg-white dark:bg-gray-800 shadow rounded-lg p-4 sm:p-6 xl:p-8 mb-6">
      <div class="mb-4 flex items-center justify-between">
        <div>
          <h3 class="text-xl font-bold text-gray-900 dark:text-white">Actividad Reciente</h3>
          <span class="text-base font-normal text-gray-500 dark:text-gray-400">Esto es un resumen de las últimas transacciones</span>
        </div>
        <div class="flex-shrink-0">
          <a href="#" class="text-sm font-medium text-primary-600 hover:bg-gray-100 dark:text-primary-500 dark:hover:bg-gray-700 rounded-lg p-2">Ver todo</a>
        </div>
      </div>
      <div class="flex flex-col mt-8">
        <div class="overflow-x-auto rounded-lg">
          <div class="align-middle inline-block min-w-full">
            <div class="shadow overflow-hidden sm:rounded-lg">
              <table class="min-w-full divide-y divide-gray-200 dark:divide-gray-600">
                <thead class="bg-gray-50 dark:bg-gray-700">
                  <tr>
                    <th scope="col" class="p-4 text-left text-xs font-medium text-gray-500 uppercase dark:text-gray-400">
                      Cliente
                    </th>
                    <th scope="col" class="p-4 text-left text-xs font-medium text-gray-500 uppercase dark:text-gray-400">
                      Monto
                    </th>
                    <th scope="col" class="p-4 text-left text-xs font-medium text-gray-500 uppercase dark:text-gray-400">
                      Estado
                    </th>
                    <th scope="col" class="p-4 text-left text-xs font-medium text-gray-500 uppercase dark:text-gray-400">
                      Fecha
                    </th>
                  </tr>
                </thead>
                <tbody class="bg-white dark:bg-gray-800">
                  <tr v-for="(item, index) in recentActivity" :key="index" class="border-b dark:border-gray-700">
                    <td class="p-4 whitespace-nowrap text-sm font-normal text-gray-900 dark:text-white">
                      <div class="flex items-center">
                        <div class="flex-shrink-0 h-10 w-10">
                          <img class="h-10 w-10 rounded-full" :src="item.avatar" alt="">
                        </div>
                        <div class="ml-4">
                          <div class="text-sm font-medium text-gray-900 dark:text-white">
                            {{ item.client }}
                          </div>
                          <div class="text-sm text-gray-500 dark:text-gray-400">
                            {{ item.email }}
                          </div>
                        </div>
                      </div>
                    </td>
                    <td class="p-4 whitespace-nowrap text-sm font-semibold text-gray-900 dark:text-white">
                      {{ item.amount }}
                    </td>
                    <td class="p-4 whitespace-nowrap text-sm">
                      <span :class="getStatusClass(item.status)" class="px-2 py-1 rounded text-xs font-medium">
                        {{ item.status }}
                      </span>
                    </td>
                    <td class="p-4 whitespace-nowrap text-sm text-gray-500 dark:text-gray-400">
                      {{ item.date }}
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import DashboardCard from "~/components/dashboard/Card.vue"
const recentActivity = [
  {
    client: "Juan Pérez",
    email: "juan@example.com",
    amount: "$1,000.00",
    status: "Aprobado",
    date: "2023-06-10",
    avatar:
      "https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=200&q=80",
  },
  {
    client: "María García",
    email: "maria@example.com",
    amount: "$2,500.00",
    status: "Pendiente",
    date: "2023-06-09",
    avatar:
      "https://images.unsplash.com/photo-1551069613-1904dbdcda11?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=200&q=80",
  },
  {
    client: "Carlos López",
    email: "carlos@example.com",
    amount: "$500.00",
    status: "Rechazado",
    date: "2023-06-08",
    avatar:
      "https://images.unsplash.com/photo-1546456073-6712f79251bb?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=200&q=80",
  },
  {
    client: "Ana Martínez",
    email: "ana@example.com",
    amount: "$3,200.00",
    status: "Aprobado",
    date: "2023-06-07",
    avatar:
      "https://images.unsplash.com/photo-1502378735452-bc7d86632805?ixlib=rb-0.3.5&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=200&fit=max&s=aa3a807e1bbdfd4364d1f449eaa96d82",
  },
]

const getStatusClass = (status) => {
  switch (status) {
    case "Aprobado":
      return "bg-green-100 text-green-700"
    case "Pendiente":
      return "bg-yellow-100 text-yellow-700"
    case "Rechazado":
      return "bg-red-100 text-red-700"
    default:
      return "bg-gray-100 text-gray-700"
  }
}
</script>
