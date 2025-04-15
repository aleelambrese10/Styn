<template>

  <Navbar></Navbar>

  <div class="relative h-screen bg-[url('/public/landing-page.jpg')] bg-cover bg-center bg-no-repeat">
    <!-- Filtro de color para mejorar la legibilidad -->
    <div class="absolute inset-0 bg-gradient-to-r from-green-700/60 to-blue-900/60"></div>

    <div class="relative h-full flex items-center pl-4 sm:pl-8 md:pl-12 lg:pl-16">
        <div class="text-white max-w-2xl text-left">
          <h1 class="text-5xl sm:text-6xl md:text-7xl lg:text-8xl xl:text-[7.5rem] font-extrabold leading-tight">
    TRANSFORMÁ <br> 
    <span class="text-white">TU TAMBO</span>
</h1>

            <p class="mt-4 sm:mt-6 text-lg sm:text-xl md:text-2xl">
                <span class="text-[#b0ff90] font-semibold">STYNA</span>gro, el primer software ERP pensado para el productor lechero.
            </p>
        </div>
    </div>
</div>


      <!-- <div class="bg-white p-10 rounded-lg shadow-lg text-left max-w-2xl ml-[-50px]">
        <h1 class="text-sm font-bold text-[#71ba3e] mb-2 text-left">STYNAgro</h1>
        <p class="text-5xl font-bold text-gray-800 mb-4">
          El primer software ERP pensado para el productor lechero.
        </p>
        <p class="text-lg text-gray-600 mb-6">
          Con STYNAgro, ofrecemos un software integral especializado en tambos, diseñado para optimizar cada aspecto,
          desde la gestión reproductiva, hasta la gestión administrativa de tu empresa agropecuaria.
        </p>
        <div class="flex flex-col sm:flex-row gap-4">
          <a href="#funcionamiento"
            class="bg-blue-900 text-white px-6 py-3 rounded-lg font-medium text-center hover:bg-blue-700 w-full sm:w-auto">
            Conocer más
          </a>
        </div>
      </div> -->
   
      <section class="py-16 bg-gray-100 text-white">
    <div class="max-w-6xl mx-auto px-6 text-center">
        <h2 class="text-4xl font-extrabold text-blue-400 mb-10">Gestión Integrada</h2>

        <div class="grid md:grid-cols-3 gap-8">
            <!-- Actividades Productivas -->
            <div class="bg-gray-800 p-6 rounded-2xl shadow-lg">
                <h3 class="text-2xl font-bold text-green-300 mb-4">Actividades Productivas</h3>
                <ul class="space-y-2 text-lg">
                    <li>✅ Registro de ordeñes</li>
                    <li>✅ Ficha electrónica de ganado</li>
                    <li>✅ Ficha electrónica de lotes agrícolas</li>
                </ul>
            </div>

            <!-- Actividades Operativas -->
            <div class="bg-gray-800 p-6 rounded-2xl shadow-lg">
                <h3 class="text-2xl font-bold text-blue-300 mb-4">Actividades Operativas</h3>
                <ul class="space-y-2 text-lg">
                    <li>✅ Empleados</li>
                    <li>✅ Alertas</li>
                </ul>
            </div>

            <!-- Actividades Administrativas -->
            <div class="bg-gray-800 p-6 rounded-2xl shadow-lg">
                <h3 class="text-2xl font-bold text-yellow-300 mb-4">Actividades Administrativas</h3>
                <ul class="space-y-2 text-lg">
                    <li>✅ Compra/venta</li>
                    <li>✅ Balance</li>
                </ul>
            </div>
        </div>
        <NuxtLink to="/landing/comoFunciona"
        class="mt-8 inline-block bg-blue-900 text-white px-6 py-3 rounded-lg font-medium hover:bg-blue-700">
        Cómo funciona
      </NuxtLink>
    </div>
</section>


  <!-- <div id="funcionamiento" class="bg-gray-100 flex justify-center items-center py-16">
    <div class="max-w-6xl mx-auto px-6 text-center">
      <h2 class="text-4xl font-bold text-gray-800 mb-8">Gestión Integrada</h2>

      <div class="grid grid-cols-1 sm:grid-cols-3 gap-6">
        <div class="bg-white p-6 rounded-lg shadow-lg border border-gray-200">
          <h3 class="text-lg font-bold text-gray-800">Actividades Productivas</h3>
          <ul class="mt-3 text-gray-600 text-sm space-y-1">
            <li>✅ Registro de ordeñes</li>
            <li>✅ Ficha electrónica de ganado</li>
            <li>✅ Ficha electrónica de lotes agrícolas</li>
          </ul>
        </div>

        <div class="bg-white p-6 rounded-lg shadow-lg border border-gray-200">
          <h3 class="text-lg font-bold text-gray-800">Actividades Operativas</h3>
          <ul class="mt-3 text-gray-600 text-sm space-y-1">
            <li>✅ Empleados</li>
            <li>✅ Alertas</li>
          </ul>
        </div>

        <div class="bg-white p-6 rounded-lg shadow-lg border border-gray-200">
          <h3 class="text-lg font-bold text-gray-800">Actividades Administrativas</h3>
          <ul class="mt-3 text-gray-600 text-sm space-y-1">
            <li>✅ Compra/venta</li>
            <li>✅ Balance</li>
          </ul>
        </div>
      </div>

      <NuxtLink to="/landing/comoFunciona"
        class="mt-8 inline-block bg-blue-900 text-white px-6 py-3 rounded-lg font-medium hover:bg-blue-700">
        Cómo funciona
      </NuxtLink>
    </div>
  </div> -->
  
  <div
    class="bg-blue-900 text-white py-20 flex flex-col md:flex-row items-center text-center md:text-left px-4 md:px-16">
    <!-- Contenedor de texto -->
    <div class="flex-1 flex flex-col items-center md:items-start ml-auto md:pl-16">
      <h3 class="text-sm font-bold uppercase">STYNAgro</h3>
      <h1 class="text-3xl md:text-5xl font-bold mt-2">
        CONOCEMOS LAS PROBLEMATICAS DE LOS PRODUCTORES
      </h1>
      <p class="mt-4 max-w-2xl">
        Nacimos en Argentina, reconocida por su pujante industria agropecuaria y su competitividad a nivel global, es un
        actor fundamental en la producción de
        alimentos para el mundo. En particular, nos enorgullece estar ubicados en el corazón de una de las cuencas
        lecheras más grandes de Latinoamérica, una región que juega un papel crucial en el abastecimiento de lácteos de
        alta calidad. Esta posición privilegiada nos permite conocer de primera mano los desafíos y oportunidades que
        enfrenta el sector lechero, y trabajar para ofrecer soluciones innovadoras y sostenibles.
      </p>
      <NuxtLink to="/landing/nosotros"
        class="mt-10 px-6 py-3 border border-white rounded-full hover:bg-white hover:text-blue-900 transition">
        Más de nosotros
      </NuxtLink>
    </div>


    <!-- Contenedor del mapa -->
    <div class="flex-1 flex justify-start md:self-start mt-10 md:mt-0 mr-auto">
      <iframe
        src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d29374176.178089038!2d-68.46450955884178!3d-26.010156210903848!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x95caae460db27c0f%3A0x8be1b926d473c17b!2sRafaela%2C%20Santa%20Fe!5e0!3m2!1ses-419!2sar!4v1741922951321!5m2!1ses-419!2sar"
        width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy"
        referrerpolicy="no-referrer-when-downgrade">
      </iframe>
    </div>
  </div>

  <div id="contacto" class="bg-gray-100 py-12 px-4 sm:px-6 lg:px-8 ">
    <div class="max-w-7xl mx-auto flex flex-col lg:flex-row">
      <!-- Columna izquierda: Texto + Imagen + Ficha de Contacto -->
      <div class="w-full lg:w-1/2 pr-0 lg:pr-[6rem] mt-8">
        <h1 class="text-3xl font-bold text-gray-800 mb-6">
          ¿Necesitas aumentar la rentabilidad y tener control de todo el proceso?
        </h1>
        <p class="text-md text-gray-600">
          ¡Evoluciona la gestión de tu negocio con STYN! Completa el formulario y comienza a optimizar los
          procesos de tu empresa.
        </p>
        <img src="/control2.jpg" alt="Imagen descriptiva" class="w-full h-auto rounded-lg shadow-lg mt-8">

        <!-- Ficha de contacto dentro de la misma columna -->
        <div class="bg-blue-900 text-white p-6 rounded-lg shadow-lg max-w-sm mt-8">
          <h3 class="text-lg font-bold text-center">Ficha de contacto STYNAgro</h3>
          <div class="mt-4">
            <p class="flex items-center">
              <svg xmlns="http://www.w3.org/2000/svg" class="w-6 h-6 text-white mr-2" fill="currentColor"
                viewBox="0 0 24 24">
                <path
                  d="M19.5 15.5a1.72 1.72 0 00-1.27-.73c-.36-.03-.79-.02-1.15-.03-.49 0-.81-.36-1.09-.68-.57-.61-1.19-1.16-1.69-1.8a.93.93 0 01-.16-.96c.1-.23.23-.45.35-.67.18-.34.37-.67.5-1.03a1.72 1.72 0 00-.13-1.39A10.16 10.16 0 0010.88 4 4.47 4.47 0 008.64 4.3c-1.47.6-2.92 1.38-4.17 2.41A2.42 2.42 0 003.4 9.9a14.28 14.28 0 004.51 8.27 14.28 14.28 0 008.27 4.51 2.42 2.42 0 003.19-1.07c1.03-1.25 1.81-2.7 2.41-4.17a4.47 4.47 0 00.3-2.24 10.16 10.16 0 00-2.69-4.12z">
                </path>
              </svg>
              +54 9 3562 55-8323
            </p>
            <p class="text-sm ml-8">(Whatsapp y llamadas)</p>
            <p class="flex items-center mt-4">
              <svg xmlns="http://www.w3.org/2000/svg" class="w-6 h-6 text-white mr-2" fill="currentColor"
                viewBox="0 0 24 24">
                <path
                  d="M19.07 4H4.93A2.93 2.93 0 002 6.93v10.14A2.93 2.93 0 004.93 20h14.14A2.93 2.93 0 0022 17.07V6.93A2.93 2.93 0 0019.07 4zM20 7.74L12 12.41 4 7.74V6l8 4.67L20 6v1.74z">
                </path>
              </svg>
              <a href="mailto:soporte@synagro.com.ar" class="hover:underline">styncontacto@gmail.com</a>
            </p>
          </div>
        </div>
      </div>

      <!-- Columna derecha: Formulario -->
      <div class="w-full lg:w-1/2 pl-0 lg:pl-8">
        <div class="bg-white p-8 rounded-lg shadow-lg text-left">
          <h2 class="text-2xl font-bold text-gray-800 mb-6">Quiero que me asesoren</h2>

          <!-- Formulario -->
          <form @submit.prevent="enviarFormulario">
            <div class="mb-6">
              <input v-model="form.nombre" type="text" placeholder="Nombre"
                class="w-full px-2 py-1 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" />
            </div>

            <div class="mb-6">
              <input v-model="form.apellido" type="text" placeholder="Apellido"
                class="w-full px-2 py-1 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" />
            </div>

            <div class="mb-6">
              <label for="telefono" class="block text-sm font-medium text-gray-700 mb-2">Teléfono:</label>
              <input v-model="form.telefono" type="tel" id="telefono" placeholder="+54 91 1234-5678"
                class="w-full px-2 py-1 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" />
            </div>

            <div class="mb-6">
              <input v-model="form.email" type="email" placeholder="Email Corporativo"
                class="w-full px-2 py-1 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" />
            </div>

            <div class="mb-6">
              <input v-model="form.empresa" type="text" placeholder="Empresa"
                class="w-full px-2 py-1 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" />
            </div>

            <div class="mb-6">
              <label for="pais" class="block text-sm font-medium text-gray-700 mb-2">País:</label>
              <select v-model="form.pais" id="pais"
                class="w-full px-2 py-1 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500">
                <option value="" disabled selected>Elegir país...</option>
                <option value="argentina">Argentina</option>
                <option value="bolivia">Bolivia</option>
                <option value="brasil">Brasil</option>
                <option value="chile">Chile</option>
                <option value="colombia">Colombia</option>
                <option value="costa-rica">Costa Rica</option>
                <option value="cuba">Cuba</option>
                <option value="ecuador">Ecuador</option>
                <option value="mexico">México</option>
                <option value="peru">Perú</option>
                <option value="uruguay">Uruguay</option>
                <option value="venezuela">Venezuela</option>
                <option value="otro">Otro</option>
              </select>
            </div>

            <div class="mb-6">
              <label for="empleados" class="block text-sm font-medium text-gray-700 mb-2">¿Nivel de producción lechera
                mensual aproximado?</label>
              <select v-model="form.empleados" id="empleados"
                class="w-full px-2 py-1 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500">
                <option value="" disabled selected>Elegir opción...</option>
                <option value="0 a 150">30.000L</option>
                <option value="151 a 250">31.000L a 60.000L</option>
                <option value="151 a 250">61.000L a 120.000L</option>
                <option value="251 a 500">121.000L a 240.000L</option>
                <option value="251 a 500">241.000L a 400.000L</option>
                <option value="501 a 1000">> 400.000L</option>
              </select>
            </div>

            <div class="mb-6">
              <input v-model="form.usuariosSistema" type="number" placeholder="¿Cuántos usuarios operan el sistema?"
                class="w-full px-2 py-1 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500" />
            </div>

            <div class="mb-6">
              <textarea v-model="form.mensaje" rows="4" placeholder="¿Cómo podemos ayudarte?"
                class="w-full px-2 py-1 border border-gray-300 rounded-lg focus:ring-blue-500 focus:border-blue-500"></textarea>
            </div>

            <div class="text-center">
              <button type="submit" class="bg-blue-900 text-white px-4 py-2 rounded-lg font-medium hover:bg-blue-700">
                Solicitar
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>

  <Footer></Footer>

</template>

<style>
.bg-tambo {
  background-image: url('/assets/img/tambo4.jpg');
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
}

.bg-cultivo {
  background-image: url('/assets/img/image.png');
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
}

.bg-farmer {
  background-image: url('/assets/img/farmer.jpg');
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
}

.whatsapp-button {
  position: fixed;
  bottom: 20px;
  right: 20px;
  background-color: #25D366;
  border-radius: 50%;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
  z-index: 1000;
  padding: 10px;
  transition: background-color 0.3s;
}

.whatsapp-button:hover {
  background-color: #128C7E;
}

.whatsapp-icon {
  width: 50px;
  height: 50px;
}
</style>

<script setup>

import Footer from '@@/components/Footer.vue';
import Navbar from '@@/components/Navbar.vue';

const form = ref({
  nombre: '',
  apellido: '',
  telefono: '',
  email: '',
  empresa: '',
  pais: '',
  mensaje: ''
});

const enviarFormulario = () => {
  console.log("Formulario enviado:", form.value);
  alert("Formulario enviado correctamente");
};


</script>
