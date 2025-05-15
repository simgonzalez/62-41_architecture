import { FridgeItem } from "@src/types/FridgeItem";
import ApiService from "./ApiService";

export const FridgeItemService = {
  getAllByFridgeId: async (fridgeId: number): Promise<FridgeItem[]> => {
    try {
      const items = await ApiService.get(`fridges/${fridgeId}/items`);
      return items;
    } catch (error) {
      console.error(`Error fetching items for fridge with id ${fridgeId}:`, error);
      throw error;
    }
  },

  create: async (
    fridgeId: number,
    itemData: { food_id: number; quantity: number; unit_id: number; expiration_date: string }
  ): Promise<FridgeItem> => {
    try {
      const newItem = await ApiService.post(`fridges/${fridgeId}/items`, itemData);
      return newItem;
    } catch (error) {
      console.error(`Error creating item for fridge with id ${fridgeId}:`, error);
      throw error;
    }
  },

  update: async (
    fridgeId: number,
    itemId: number,
    itemData: { food_id: number; quantity: number; unit_id: number; expiration_date: string; added_by_user_id?: number }
  ): Promise<FridgeItem> => {
    try {
      const updatedItem = await ApiService.put(`fridges/${fridgeId}/items/${itemId}`, itemData);
      return updatedItem;
    } catch (error) {
      console.error(`Error updating item with id ${itemId} in fridge with id ${fridgeId}:`, error);
      throw error;
    }
  },

  delete: async (fridgeId: number, itemId: number): Promise<boolean> => {
    try {
      await ApiService.delete(`fridges/${fridgeId}/items/${itemId}`);
      return true;
    } catch (error) {
      console.error(`Error deleting item with id ${itemId} in fridge with id ${fridgeId}:`, error);
      return false;
    }
  },
};