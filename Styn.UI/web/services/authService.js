import Service from "./service.js";

class AuthService extends Service {
  constructor() {
    super();
    this.baseUrl = 'Auth'; // Asumiendo que el controlador tiene un prefijo 'auth'
  }

  async login(data) {
    try {
      const response = await this.post('/login', data);
      if (response.token) {
        localStorage.setItem('token', response.token);
        await this.getLoggedUser();
      }
      return response;
    } catch (error) {
      throw new Error('Error en login: ' + error.message);
    }
  }

  async getLoggedUser() {
    try {
      const user = await this.get('/GetLoggedUser');
      const userState = userData();
      userState.value = user;
      return user;
    } catch (error) {
      throw new Error('Error al obtener usuario actual: ' + error.message);
    }
  }

  async activateUser(email) {
    try {
      return await this.post('/ActivateUser', { email });
    } catch (error) {
      throw new Error('Error al activar usuario: ' + error.message);
    }
  }

  async deactivateUser(email) {
    try {
      return await this.post('/DesactivateUser', { email });
    } catch (error) {
      throw new Error('Error al desactivar usuario: ' + error.message);
    }
  }

  async deleteUser(id) {
    try {
      return await this.delete(`/DeleteUser/${id}`);
    } catch (error) {
      throw new Error('Error al eliminar usuario: ' + error.message);
    }
  }

  async editUser(id, userData) {
    try {
      return await this.put('/EditUser', { id, ...userData });
    } catch (error) {
      throw new Error('Error al editar usuario: ' + error.message);
    }
  }

  async register(registerData) {
    try {
      return await this.post('/register', registerData);
    } catch (error) {
      throw new Error('Error en registro: ' + error.message);
    }
  }

  async logout() {
    try {
      const response = await this.post('/logout');
      localStorage.removeItem('token');
      return response;
    } catch (error) {
      throw new Error('Error en logout: ' + error.message);
    }
  }

  async forgotPassword(email) {
    try {
      return await this.post('/ForgotPassword', { email });
    } catch (error) {
      throw new Error('Error en recuperación de contraseña: ' + error.message);
    }
  }

  async changePassword(changePasswordData) {
    try {
      return await this.post('/ChangePassword', changePasswordData);
    } catch (error) {
      throw new Error('Error al cambiar contraseña: ' + error.message);
    }
  }

  async getUsers() {
    try {
      return await this.get('/users');
    } catch (error) {
      throw new Error('Error al obtener usuarios: ' + error.message);
    }
  }
}

// Ejemplo de uso:
const authService = new AuthService();

// Ejemplo de cómo usar los métodos:
/*
// Login
const loginResponse = await authService.login('email@example.com', 'password');

// Obtener usuario actual
const currentUser = await authService.getLoggedUser();

// Registrar nuevo usuario
const registerData = {
  email: 'nuevo@ejemplo.com',
  password: 'contraseña123',
  // otros campos necesarios
};
const registerResponse = await authService.register(registerData);
*/

export default authService;
