<template>
  <div class="bg-white dark:bg-gray-800 rounded-lg shadow p-4 md:p-6">
    <div class="flex items-center">
      <div :class="`${color} p-3 rounded-full mr-4`">
        <Icon :name="icon" class="w-6 h-6" />
      </div>
      <div>
        <h5 class="text-gray-500 dark:text-gray-400 text-sm font-medium">{{ title }}</h5>
        <div class="flex items-center">
          <h3 class="text-2xl font-bold text-gray-900 dark:text-white">{{ value }}</h3>
          <span v-if="change !== undefined" :class="[
            'text-xs font-medium ml-2',
            change >= 0 ? 'text-green-500' : 'text-red-500'
          ]">
            <Icon :name="change >= 0 ? 'lucide:trending-up' : 'lucide:trending-down'" class="w-3 h-3 inline" />
            {{ Math.abs(change) }}%
          </span>
        </div>
        <p v-if="subtitle" class="text-xs text-gray-500 dark:text-gray-400 mt-1">{{ subtitle }}</p>
      </div>
    </div>
  </div>
</template>

<script setup>
defineProps({
  title: {
    type: String,
    required: true,
  },
  value: {
    type: String,
    required: true,
  },
  icon: {
    type: String,
    required: true,
  },
  color: {
    type: String,
    default: "bg-blue-100 text-blue-500",
  },
  change: {
    type: Number,
    default: undefined,
  },
  subtitle: {
    type: String,
    default: "",
  },
})
</script>
