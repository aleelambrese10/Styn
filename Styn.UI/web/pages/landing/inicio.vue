<template>
  <Navbar></Navbar>
  <div class="mt-8">
    <section class="bg-blue-900 text-white text-center py-20">
      <div class="max-w-3xl mx-auto">
        <h2 class="text-4xl font-bold">STYNAgro</h2>
        <p class="mt-4 font-bold text-xl">El primer software ERP pensado para el productor lechero.</p>
      </div>
    </section>
  </div>

  <section class="py-16 bg-gray-200">
    <div class="container mx-auto text-center px-4">
      <h2 class="text-4xl font-bold text-gray-800 mb-6">STYNAgro, no solo le mejora la vida al productor... </h2>
      <p class="text-lg text-gray-600 max-w-2xl mx-auto mb-8">
        Las diferentes modalidades de STYNagro simplifican las tareas del personal administrativo, contadores, ingenieros y veterinarios.
        Ya que presenta de forma integral los datos de la empresa.
      </p>

      <!-- Video Institucional -->
      <div class="mb-8">
        <iframe class="w-full max-w-2xl h-64 mx-auto"
          src="https://www.youtube.com/embed/sbFQB4Qw6U0?si=q6WwyAowo0enSDGE" title="YouTube video player"
          frameborder="0"
          allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
          referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>
      </div>

      <!-- Carrusel de funcionalidades -->
      <div class="bg-gray-200 relative overflow-hidden">
        <h3 class="text-2xl font-semibold text-gray-800 mb-4 mt-8">Funcionalidades clave</h3>
        <div class="flex space-x-4 overflow-hidden p-4" ref="carousel">
          <div v-for="(feature, index) in visibleFeatures" :key="index"
            class="flex-none bg-gray-100 p-4 rounded-lg shadow-md min-w-[250px]">
            <h4 class="font-semibold text-gray-800">{{ feature.title }}</h4>
            <p class="text-gray-600 text-sm break-words max-w-[220px]">
              {{ feature.description }}
            </p>
          </div>
        </div>
      </div>

      <!-- Razones para elegirnos -->
      <div class="mt-12 text-center">
        <h3 class="text-2xl font-semibold text-gray-800 mb-4">¿Por qué elegirnos?</h3>
        <ul class="text-gray-600 space-y-3 flex flex-col items-center">
          <li v-for="(reason, index) in reasons" :key="index" class="flex items-center bg-white p-3 rounded-lg shadow-md w-full max-w-md">
            <span class="text-blue-600 text-xl mr-3">✔</span>
            <span class="text-sm sm:text-base">{{ reason }}</span>
          </li>
        </ul>
      </div>
    </div>
  </section>

  <section class="bg-blue-900 text-white text-center py-16 mt-8">
    <div class="max-w-3xl mx-auto">
      <p class="mt-4 text-xl">
        Que los datos de tu empresa no queden solo en tu mente, sumate a la revolución digital con STYNAgro.
      </p>
      <NuxtLink to="/landing/contacto"
        class="mt-12 inline-block text-white px-6 py-2 border border-white rounded-full hover:bg-white hover:text-blue-900 transition">
        Contactanos
      </NuxtLink>
    </div>
  </section>

  <Footer></Footer>
</template>

<script>
import Footer from '@@/components/Footer.vue';
import Navbar from '@@/components/Navbar.vue';

export default {
  data() {
    return {
      features: [
        { title: "Compra/Ventas", description: "Detalles de compras y ventas, emisión de facturas y cálculo de IVA." },
        { title: "Balance", description: "Balance mensual de los ingresos efectuados y los egresos devengados por la empresa" },
        { title: "Registro de ordeñes", description: "Recuento de litros totales netos para venta, litros por lote, promedios, variaciones dia a dia, mes a mes , etc." },
        { title: "Ficha electrónica de lotes agrícolas", description: "Cálculo de costos de servicios, insumos y alquileres, registro de actividades, rinde y calculo de rentabilidad." },
        { title: "Ficha electrónica del ganado", description: "Historial reproductivo, nutricional, genético, sanitario y productivo por animal." },
        { title: "Alertas", description: "Alertas automáticas que llegan al whatsapp para notificar inseminaciones, vacas con atibióticos, vacas a secar, animales para venta, vacunaciones, etc." },
        { title: "Empleados", description: "Historial, comunicación de tareas a través de alertas y emision de recibos de sueldo." }
      ],
      reasons: [
        "Especialización en el sector lechero",
        "Gestión integral de la empresa",
        "Información determinante para la toma de decisiones",
        "Mejora la eficiencia y la rentabilidad",
        "Interfaz intuitiva y fácil de usar"
      ],
      visibleFeatures: [], // Características visibles
      currentIndex: 0, // Indice actual para desplazamiento
    };
  },
  mounted() {
    this.updateVisibleFeatures();
    setInterval(this.nextFeature, 3000); // Avanza cada 3 segundos
  },
  methods: {
    updateVisibleFeatures() {
      const maxVisible = 5;
      // Creamos un arreglo que siempre tendrá 5 elementos visibles
      let updatedFeatures = [];
      for (let i = 0; i < maxVisible; i++) {
        updatedFeatures.push(this.features[(this.currentIndex + i) % this.features.length]);
      }
      this.visibleFeatures = updatedFeatures;
    },
    nextFeature() {
      // Desplazamos el primer elemento y agregamos el siguiente
      this.currentIndex = (this.currentIndex + 1) % this.features.length;
      this.updateVisibleFeatures();
    }
  }
};
</script>

<style scoped>
section {
  margin: 0;
}

.bg-gray-200 {
  transition: transform 1s ease-in-out; 
}


</style>
