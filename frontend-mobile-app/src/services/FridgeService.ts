import { Fridge } from "@src/types/Fridge";
import ApiService from "./ApiService";

export const FridgeService = {
  getAll: async (): Promise<Fridge[]> => {
    try {
      const fridges = await ApiService.get("fridges");
      return fridges;
    } catch (error) {
      console.error("Error fetching fridges:", error);
      throw error;
    }
  },

  getById: async (id: number): Promise<Fridge> => {
    try {
      const fridge = await ApiService.get(`fridges/${id}`);
      return fridge;
    } catch (error) {
      console.error(`Error fetching fridge with id ${id}:`, error);
      throw error;
    }
  },

  create: async (fridge: Partial<Fridge>): Promise<Fridge> => {
    try {
      const newFridge = await ApiService.post("fridges", fridge);
      return newFridge;
    } catch (error) {
      console.error("Error creating fridge:", error);
      throw error;
    }
  },

  update: async (id: number, fridge: Partial<Fridge>): Promise<Fridge> => {
    try {
      const updatedFridge = await ApiService.put(`fridges/${id}`, fridge);
      return updatedFridge;
    } catch (error) {
      console.error(`Error updating fridge with id ${id}:`, error);
      throw error;
    }
  },

  delete: async (id: number): Promise<boolean> => {
    try {
      await ApiService.delete(`fridges/${id}`);
      return true;
    } catch (error) {
      console.error(`Error deleting fridge with id ${id}:`, error);
      return false;
    }
  },
};