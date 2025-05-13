<template>
  <Navbar></Navbar>
  <div>
    <!-- Encabezado -->
    <section class="bg-blue-900 text-white text-center py-20 mt-8">
      <div class="max-w-3xl mx-auto">
        <h1 class="text-3xl font-bold">Un aliado estratégico para tu producción</h1>
        <p class="mt-4">STYNAgro te ayuda a gestionar cada etapa del proceso productivo con información precisa y actualizada.</p>
      </div>
    </section>

   <!-- Carrusel de funcionalidades -->
   <div class="bg-gray-200 relative overflow-hidden px-8 py-12 w-full">
      <h3 class="text-3xl font-semibold text-gray-800 mb-8 text-center">Funcionalidades clave</h3>
      <div class="flex space-x-4 overflow-hidden justify-center">
        <div
          v-for="(feature, index) in visibleFeatures"
          :key="index"
          class="flex-none bg-white p-6 rounded-xl shadow-lg w-[18%] max-w-[300px]"
        >
          <h4 class="font-semibold text-gray-800 text-lg mb-2">{{ feature.title }}</h4>
          <p class="text-gray-600 text-sm break-words">
            {{ feature.description }}
          </p>
        </div>
      </div>
    </div>


    <!-- Implementación -->
    <section class="bg-gray-100 py-12">
      <div class="max-w-4xl mx-auto px-4">
        <h2 class="text-2xl font-semibold text-center mb-6">Implementación en 5 pasos</h2>
        <ol class="space-y-4">
          <li
            v-for="(paso, index) in implementacion"
            :key="index"
            class="p-4 border-l-4 border-blue-900 bg-white shadow"
          >
            <h3 class="font-semibold">{{ paso.titulo }}</h3>
            <p class="text-gray-600">{{ paso.descripcion }}</p>
          </li>
        </ol>
      </div>
    </section>

    <!-- Preguntas frecuentes -->
    <section class="max-w-4xl mx-auto py-12 px-4">
      <h2 class="text-2xl font-semibold text-center mb-6">Preguntas Frecuentes</h2>
      <div
        v-for="(pregunta, index) in preguntas"
        :key="index"
        class="border-b py-4 cursor-pointer"
        @click="toggleFAQ(index)"
      >
        <div class="flex items-center justify-between">
          <h3 class="text-lg font-semibold">{{ pregunta.pregunta }}</h3>
          <svg
            v-if="pregunta.activa"
            xmlns="http://www.w3.org/2000/svg"
            class="h-5 w-5 text-blue-900 transform rotate-180"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
          </svg>
          <svg
            v-else
            xmlns="http://www.w3.org/2000/svg"
            class="h-5 w-5 text-blue-900"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 15l-7-7-7 7" />
          </svg>
        </div>
        <p v-show="pregunta.activa" class="text-gray-600 mt-2">{{ pregunta.respuesta }}</p>
      </div>
    </section>

    <!-- CTA -->
    <section class="bg-blue-900 text-black text-center py-20 mt-8">
      <div class="max-w-3xl mx-auto">
        <h2 class="text-2xl font-bold text-white">Empieza a usar STYNAgro hoy mismo</h2>
        <div class="mt-8">
          <a
            href="https://wa.me/5493562558323?text=Hola,%20me%20gustaría%20solicitar%20una%20demo"
            target="_blank"
            class="text-white px-6 py-3 rounded-lg font-medium text-center border border-white rounded-full hover:bg-white hover:text-blue-900 transition"
          >
            Solicitar Demo
          </a>
        </div>
      </div>
    </section>
  </div>
  <Footer></Footer>
</template>

<script>
export default {
  data() {
    return {
      implementacion: [
        { titulo: "Paso 1: Solicita la demo", descripcion: "Contáctanos para acceder a una prueba gratuita de 3 meses." },
        { titulo: "Paso 2: Recibe capacitación", descripcion: "Aprende a usar STYNAgro con una sesión personalizada." },
        { titulo: "Paso 3: Prueba el sistema", descripcion: "Usa todas las funcionalidades y ajusta el software a tus necesidades." },
        { titulo: "Paso 4: Confirma tu licencia", descripcion: "Si estás satisfecho, realiza el pago para continuar con el software." },
        { titulo: "Paso 5: Accede al software", descripcion: "Comienza a usar STYNAgro con soporte técnico siempre disponible." },
      ],
      preguntas: [
        { pregunta: "¿Para qué tipo de actividad está destinado?", respuesta: "Es un software especializado para producción agropecuaria especializada en tambos.", activa: false },
        { pregunta: "¿Solo sirve para grandes productores?", respuesta: "No, es adaptable tanto para pequeñas como grandes empresas.", activa: false },
        { pregunta: "¿Cómo aprendo a usar el software?", respuesta: "Te capacitamos desde el inicio y tendrás un tutor disponible.", activa: false },
      ],
      features: [
        { title: "Compra/Ventas", description: "Detalles de compras y ventas, emisión de facturas y cálculo de IVA." },
        { title: "Balance", description: "Balance mensual de los ingresos efectuados y los egresos devengados por la empresa" },
        { title: "Registro de ordeñes", description: "Recuento de litros totales netos para venta, litros por lote, promedios, variaciones día a día, mes a mes, etc." },
        { title: "Ficha electrónica de lotes agrícolas", description: "Cálculo de costos de servicios, insumos y alquileres, registro de actividades, rinde y cálculo de rentabilidad." },
        { title: "Ficha electrónica del ganado", description: "Historial reproductivo, nutricional, genético, sanitario y productivo por animal." },
        { title: "Alertas", description: "Alertas automáticas que llegan al WhatsApp para notificar inseminaciones, vacas con antibióticos, vacas a secar, animales para venta, vacunaciones, etc." },
        { title: "Empleados", description: "Historial, comunicación de tareas a través de alertas y emisión de recibos de sueldo." }
      ],
      currentIndex: 0,
      itemsPerPage: 5,
      interval: null,
    };
  },
  computed: {
    visibleFeatures() {
      return this.features.slice(this.currentIndex, this.currentIndex + this.itemsPerPage);
    },
  },
  methods: {
    toggleFAQ(index) {
      this.preguntas[index].activa = !this.preguntas[index].activa;
    },
    next() {
      this.currentIndex = (this.currentIndex + 1) % this.features.length;
      if (this.currentIndex + this.itemsPerPage > this.features.length) {
        this.currentIndex = 0;
      }
    },
    prev() {
      if (this.currentIndex === 0) {
        this.currentIndex = Math.max(0, this.features.length - this.itemsPerPage);
      } else {
        this.currentIndex--;
      }
    },
    startAutoSlide() {
      this.interval = setInterval(() => {
        this.next();
      }, 4000); // Cambia cada 4 segundos
    },
    stopAutoSlide() {
      clearInterval(this.interval);
    },
  },
  mounted() {
    this.startAutoSlide();
  },
  beforeDestroy() {
    this.stopAutoSlide();
  },
};
</script>


<style scoped>
</style>
