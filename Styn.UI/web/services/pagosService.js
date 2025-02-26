const Service = require('./service');

class PagosService extends Service {
  constructor() {
    super();
    this.url = 'pagos';
  }

  // Obtener todos los pagos
  async obtenerPagos() {
    try {
      const pagos = await this.get();
      return pagos;
    } catch (error) {
      throw new Error('Error al obtener los pagos: ' + error.message);
    }
  }

  // Obtener un pago por ID
  async obtenerPagoPorId(id) {
    try {
      const pago = await this.get(`/${id}`);
      return pago;
    } catch (error) {
      throw new Error('Error al obtener el pago: ' + error.message);
    }
  }

  // Crear un nuevo pago
  async crearPago(datos) {
    try {
      const nuevoPago = await this.post('', datos);
      return nuevoPago;
    } catch (error) {
      throw new Error('Error al crear el pago: ' + error.message);
    }
  }

  // Actualizar un pago
  async actualizarPago(id, datos) {
    try {
      const pagoActualizado = await this.put(`/${id}`, datos);
      return pagoActualizado;
    } catch (error) {
      throw new Error('Error al actualizar el pago: ' + error.message);
    }
  }

  // Eliminar un pago
  async eliminarPago(id) {
    try {
      const pagoEliminado = await this.delete(`/${id}`);
      return pagoEliminado;
    } catch (error) {
      throw new Error('Error al eliminar el pago: ' + error.message);
    }
  }
}

module.exports = PagosService;
