import camelcaseKeys from 'camelcase-keys';
import { snakeCase } from 'snake-case';

let baseUrl = 'http://192.168.178.22:8000/api/';

let authToken: string | null = null;

const ApiService = {
  setToken(token: string) {
    authToken = token;
  },

  async login(email: string, password: string): Promise<string> {
    const response = await fetch(`${baseUrl}login`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ email, password }),
    });
    if (!response.ok) {
      throw new Error('Invalid credentials');
    }
    const json = await response.json();
    return json.token || json.access_token;
  },

  async register(
    email: string,
    password: string,
    passwordConfirmation: string,
    firstName: string,
    name: string
  ): Promise<any> {
    const response = await fetch(`${baseUrl}register`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        first_name: firstName,
        name,
        email,
        password,
        password_confirmation: passwordConfirmation,
      }),
    });
    if (!response.ok) {
      throw new Error('Registration failed');
    }
    const json = await response.json();
    return camelcaseKeys(json, { deep: true });
  },

  async get(endpoint: string): Promise<any> {
    const response = await fetch(`${baseUrl}${endpoint}`, {
      headers: authToken ? { Authorization: `Bearer ${authToken}` } : {},
    });
    return this.handleResponse(response);
  },

  async post(endpoint: string, data: any): Promise<any> {
    const response = await fetch(`${baseUrl}${endpoint}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        ...(authToken ? { Authorization: `Bearer ${authToken}` } : {}),
      },
      body: JSON.stringify(this.toSnakeCase(data)),
    });
    return this.handleResponse(response);
  },

  async put(endpoint: string, data: any): Promise<any> {
    const response = await fetch(`${baseUrl}${endpoint}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
        ...(authToken ? { Authorization: `Bearer ${authToken}` } : {}),
      },
      body: JSON.stringify(this.toSnakeCase(data)),
    });
    return this.handleResponse(response);
  },

  async delete(endpoint: string): Promise<any> {
    const response = await fetch(`${baseUrl}${endpoint}`, {
      method: 'DELETE',
      headers: authToken ? { Authorization: `Bearer ${authToken}` } : {},
    });
    return this.handleResponse(response);
  },

  async handleResponse(response: Response): Promise<any> {
    let json: any = null;
    let text: string | null = null;
    try {
      text = await response.text();
      json = text ? JSON.parse(text) : null;
    } catch (e) {
      // If response is not JSON, keep json as null
    }
    if (!response.ok) {
      const error: any = new Error(`HTTP error! status: ${response.status}`);
      if (json && typeof json === 'object') {
        error.details = json;
      } else if (text) {
        error.details = { raw: text };
      }
      throw error;
    }
    return camelcaseKeys(json, { deep: true });
  },

  toSnakeCase(data: any): any {
    if (Array.isArray(data)) {
      return data.map((item) => this.toSnakeCase(item));
    } else if (data !== null && typeof data === 'object') {
      return Object.keys(data).reduce((acc: any, key: string) => {
        acc[snakeCase(key)] = this.toSnakeCase(data[key]);
        return acc;
      }, {});
    }
    return data;
  },

  async getUserFridgeItems(): Promise<any> {
    const response = await this.get(`fridge-items/user`);
    return response;
  },
};

export default ApiService;