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
  
      <!-- Beneficios -->
      <section class="max-w-4xl mx-auto py-12 px-4">
        <h2 class="text-2xl font-semibold text-center mb-6">¿Qué hace un ERP para una empresa agropecuaria?</h2>
        <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
                <div class="bg-blue-900 text-white p-6 rounded-lg shadow-lg">
                    <span class="text-2xl">📊</span>
                    <h3 class="font-bold mt-2">Gestionar el rodeo</h3>
                    <p class="text-sm mt-1">Registro detallado de cada vaca, su historial y producción.
                    </p>
                </div>
                <div class="bg-blue-900 text-white p-6 rounded-lg shadow-lg">
                    <span class="text-2xl">💰</span>
                    <h3 class="font-bold mt-2">Controlar la producción de leche</h3>
                    <p class="text-sm mt-1">Registro preciso de cantidad y calidad de leche.
                        .</p>
                </div>
                <div class="bg-blue-900 text-white p-6 rounded-lg shadow-lg">
                    <span class="text-2xl">🌱</span>
                    <h3 class="font-bold mt-2">Gestionar la alimentación</h3>
                    <p class="text-sm mt-1">Optimización de dietas y raciones según necesidades.</p>
                </div>
                <div class="bg-blue-900 text-white p-6 rounded-lg shadow-lg">
                    <span class="text-2xl">🐄</span>
                    <h3 class="font-bold mt-2">Gestión reproductiva</h3>
                    <p class="text-sm mt-1">Control de ciclos, inseminaciones y partos.</p>
                </div>

            </div>
      </section>
  
      <!-- Implementación -->
      <section class="bg-gray-100 py-12">
        <div class="max-w-4xl mx-auto px-4">
          <h2 class="text-2xl font-semibold text-center mb-6">Implementación en 5 pasos</h2>
          <ol class="space-y-4">
            <li v-for="(paso, index) in implementacion" :key="index" class="p-4 border-l-4 border-blue-900 bg-white shadow">
              <h3 class="font-semibold">{{ paso.titulo }}</h3>
              <p class="text-gray-600">{{ paso.descripcion }}</p>
            </li>
          </ol>
        </div>
      </section>
  
      <!-- Preguntas frecuentes -->
      <section class="max-w-4xl mx-auto py-12 px-4">
  <h2 class="text-2xl font-semibold text-center mb-6">Preguntas Frecuentes</h2>
  <div v-for="(pregunta, index) in preguntas" :key="index" class="border-b py-4 cursor-pointer" @click="toggleFAQ(index)">
    <div class="flex items-center justify-between">
      <h3 class="text-lg font-semibold">{{ pregunta.pregunta }}</h3>
      <!-- Ícono de la flecha -->
      <svg v-if="pregunta.activa" xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 text-blue-900 transform rotate-180" fill="none" viewBox="0 0 24 24" stroke="currentColor">
        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
      </svg>
      <svg v-else xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 text-blue-900" fill="none" viewBox="0 0 24 24" stroke="currentColor">
        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 15l-7-7-7 7" />
      </svg>
    </div>
    <p v-show="pregunta.activa" class="text-gray-600 mt-2">{{ pregunta.respuesta }}</p>
  </div>
</section>

  
      <section class="bg-blue-900 text-black text-center py-20 mt-8">
  <div class="max-w-3xl mx-auto">
    <h2 class="text-2xl font-bold text-white">Empieza a usar STYNAgro hoy mismo</h2>
    <!-- Aumento de mt-4 a mt-12 para más espacio solo en el botón -->
     <div class="mt-8">
      <a href="https://wa.me/5491112345678?text=Hola,%20me%20gustaría%20solicitar%20una%20demo"
       target="_blank" class=" text-white px-6 py-3 rounded-lg font-medium text-center border border-white rounded-full hover:bg-white hover:text-blue-900 transition">
      Solicitar Demo
    </a>
  </div>    
  </div>
</section>     
    </div>
    <Footer></Footer>
  </template>
  
  <script>

  import Footer from '@@/components/Footer.vue';
  import Navbar from '@@/components/Navbar.vue';


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
      };
    },
    methods: {
      toggleFAQ(index) {
        this.preguntas[index].activa = !this.preguntas[index].activa;
      },
    },
  };
  </script>
  
  <style scoped>
  </style>
  