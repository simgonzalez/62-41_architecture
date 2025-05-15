import camelcaseKeys from 'camelcase-keys';
import { snakeCase } from 'snake-case';
import { NetworkInfo } from 'react-native-network-info';

let baseUrl = '';

const initializeBaseUrl = async () => {
  const ipAddress = await NetworkInfo.getIPAddress();
  baseUrl = `http://${ipAddress}:8000/api/`;
};

const ApiService = {
  async initialize(): Promise<void> {
    await initializeBaseUrl();
  },

  async get(endpoint: string): Promise<any> {
    const response = await fetch(`${baseUrl}${endpoint}`);
    return this.handleResponse(response);
  },

  async post(endpoint: string, data: any): Promise<any> {
    const response = await fetch(`${baseUrl}${endpoint}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
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
      },
      body: JSON.stringify(this.toSnakeCase(data)),
    });
    return this.handleResponse(response);
  },

  async delete(endpoint: string): Promise<any> {
    const response = await fetch(`${baseUrl}${endpoint}`, {
      method: 'DELETE',
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