// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
    devtools: {
      enabled: true,

      timeline: {
        enabled: true,
      },
    },
    modules: ["@nuxtjs/tailwindcss"],
    // css: ["~/assets/css/main.css"],
    app: {
      head: {
        title: "Admin Panel",
        meta: [
          { charset: "utf-8" },
          { name: "viewport", content: "width=device-width, initial-scale=1" },
          { hid: "description", name: "description", content: "Admin Panel Template" },
        ],
        link: [{ rel: "icon", type: "image/x-icon", href: "/favicon.ico" }],
      },
    },
    runtimeConfig: {
      public: {
        apiBaseUrl: process.env.NUXT_API_BASE_URL || "http://localhost:3000/api",
      },
    },
})