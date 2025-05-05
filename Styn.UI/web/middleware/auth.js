// middleware/auth.js
export default defineNuxtRouteMiddleware((to, from) => {
  // Si estamos en el lado del cliente
  if (process.client) {
    const token = localStorage.getItem("auth_token")

    // Si no hay token y no estamos en la página de login, redirigir a login
    if (!token && to.path !== "/login") {
      return navigateTo("/login")
    }

    // Si hay token y estamos en la página de login, redirigir al dashboard
    if (token && to.path === "/login") {
      return navigateTo("/")
    }
  }
})