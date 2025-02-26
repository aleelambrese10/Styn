import { API_URL } from "./api";

export default class Service {
  constructor(baseUrl) {
    this.baseUrl = baseUrl;
  }

  getHeaders() {
    const token = localStorage.getItem('token');
    return {
      'Content-Type': 'application/json',
      'Authorization': token ? `Bearer ${token}` : ''
    };
  }

  async get(endpoint = '') {
    try {
      const url = endpoint ? `${API_URL}${this.baseUrl}${endpoint}` : `${API_URL}${this.baseUrl}`;
      const response = await fetch(url, {
        method: 'GET',
        headers: this.getHeaders()
      });
      return await response.json();
    } catch (error) {
      throw new Error(`Error en GET: ${error.message}`);
    }
  }

  async post(endpoint = '', data) {
    try {
      const url = endpoint ? `${API_URL}${this.baseUrl}${endpoint}` : `${API_URL}${this.baseUrl}`;
      const response = await fetch(url, {
        method: 'POST',
        headers: this.getHeaders(),
        body: JSON.stringify(data)
      });
      return await response.json();
    } catch (error) {
      throw new Error(`Error en POST: ${error.message}`);
    }
  }

  async put(id, data, endpoint = '') {
    try {
      const url = endpoint ? `${API_URL}${this.baseUrl}${endpoint}/${id}` : `${API_URL}${this.baseUrl}/${id}`;
      const response = await fetch(url, {
        method: 'PUT',
        headers: this.getHeaders(),
        body: JSON.stringify(data)
      });
      return await response.json();
    } catch (error) {
      throw new Error(`Error en PUT: ${error.message}`);
    }
  }

  async delete(id, endpoint = '') {
    try {
      const url = endpoint ? `${API_URL}${this.baseUrl}${endpoint}/${id}` : `${API_URL}${this.baseUrl}/${id}`;
      const response = await fetch(url, {
        method: 'DELETE',
        headers: this.getHeaders()
      });
      return await response.json();
    } catch (error) {
      throw new Error(`Error en DELETE: ${error.message}`);
    }
  }
}
