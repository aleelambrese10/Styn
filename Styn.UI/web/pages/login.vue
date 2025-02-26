<template>
    <div
      id="toast-simple"
      class="hidden fixed flex items-center w-full max-w-xs p-4 space-x-4 text-gray-500 bg-white divide-x divide-gray-200 rounded-lg shadow top-5 right-5 dark:text-gray-400 dark:divide-gray-700 space-x dark:bg-gray-800"
    >
      <svg
        aria-hidden="true"
        class="flex-shrink-0 w-5 h-5"
        fill="currentColor"
        viewBox="0 0 20 20"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          fill-rule="evenodd"
          d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7-4a1 1 0 11-2 0 1 1 0 012 0zM9 9a1 1 0 000 2v3a1 1 0 001 1h1a1 1 0 100-2v-3a1 1 0 00-1-1H9z"
          clip-rule="evenodd"
        ></path>
      </svg>
      <span class="sr-only">Info</span>
      <div class="pl-4 text-sm font-normal">
        Error al ingresar, Verifique los datos.
      </div>
    </div>
  
    <div class="text-center" v-if="loading">
      <div role="status">
        <svg
          aria-hidden="true"
          class="inline w-8 h-8 mr-2 text-gray-200 animate-spin dark:text-gray-600 fill-blue-600"
          viewBox="0 0 100 101"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z"
            fill="currentColor"
          />
          <path
            d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676   39.0409Z"
            fill="currentFill"
          />
        </svg>
      </div>
    </div>
  
    <div v-else class="bg-white h-screen">
      <div class="mx-auto">
        <div class="grid gap-8 sm:grid-cols-2">
          <!-- image - start -->
          <div
            class="h-80 overflow-hidden bg-gray-100 shadow-lg md:h-screen
             sm:block hidden"
          >
            <img
              src="https://images.pexels.com/photos/29547865/pexels-photo-29547865.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
              loading="lazy"
              alt="Photo"
              class="h-full w-full object-cover object-center"
            />
          </div>
          <!-- image - end -->
  
          <!-- content - start -->
          <div class="bg-white h-screen px-2 flex items-center justify-center">
            <div class="mx-auto">
              <h2
                class="mb-4 text-center text-2xl font-bold text-gray-800 md:mb-8 lg:text-3xl"
              >
                Iniciar Sesión
              </h2>
  
              <form
                @submit.prevent="doLogin"
                class="mx-auto max-w-lg rounded-lg border"
              >
                <div class="flex flex-col gap-4 p-4 md:p-8">
                  <div>
                    <label
                      for="email"
                      class="mb-2 inline-block text-sm text-gray-800 sm:text-base"
                      >Email</label
                    >
                    <input
                      type="text"
                      name="email"
                      id="email"
                      v-model="form.email"
                      placeholder="Email"
                      class="w-full rounded border bg-gray-50 px-3 py-2 text-gray-800 outline-none ring-indigo-300 transition duration-100 focus:ring"
                    />
                  </div>
  
                  <div>
                    <label
                      for="password"
                      class="mb-2 inline-block text-sm text-gray-800 sm:text-base"
                      >Contraseña</label
                    >
                    <input
                      type="password"
                      name="password"
                      id="password"
                      placeholder="••••••••"
                      v-model="form.password"
                      class="w-full rounded border bg-gray-50 px-3 py-2 text-gray-800 outline-none ring-indigo-300 transition duration-100 focus:ring"
                    />
                  </div>
  
                  <button
                    type="submit"
                    class="block rounded-lg bg-gray-800 px-8 py-3 text-center text-sm font-semibold text-white outline-none ring-gray-300 transition duration-100 hover:bg-gray-700 focus-visible:ring active:bg-gray-600 md:text-base"
                  >
                    Iniciar Sesión
                  </button>
                </div>
              </form>
            </div>
          </div>
          <!-- content - end -->
        </div>
      </div>
    </div>
  </template>
  
  <script setup>
  definePageMeta({
    layout: "empty",
  });
  
  import { ref, onMounted } from "vue";
  import { useRouter } from "vue-router";
  import authService from "../services/authService.js";
  import { useFlowbite } from '~/composables/useFlowbite';
  
  const form = ref({});
  const router = useRouter();
  const loading = ref(false);
  
  const doLogin = async () => {
    try {
      loading.value = true;
      await authService.login(form.value);
      const user = userData();
      if(user.value.role === 'Admin'){
          navigateTo('/admin');
       }else{
          navigateTo('/usuario');
      }
    } catch (error) {
      setAlert();
      loading.value = false;
      console.error(error.message);
    }
  };
  
  const setAlert = () => {
    const toastElement = document.getElementById("toast-simple");
    toastElement.classList.remove("hidden");
    setTimeout(() => {
      toastElement.classList.add("hidden");
    }, 3000);
  };
  
  onMounted(() => {
    //initFlowbite();
  });
  </script>
  