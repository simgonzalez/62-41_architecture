import camelcaseKeys from 'camelcase-keys';
import { snakeCase } from 'snake-case';

let baseUrl = 'http://localhost:8000/api/';

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
    // Adjust this if your API returns the token in a different property
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
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    const json = await response.json();
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
};

export default ApiService;