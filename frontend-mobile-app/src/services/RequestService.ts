import { FoodRequest } from "@src/types/FoodRequest";
import ApiService from "./ApiService";

export const RequestService = {
  getAllRequests: async (): Promise<FoodRequest[]> => {
    try {
      const requests = await ApiService.get("food-requests");
      return requests;
    } catch (error) {
      console.error("Error fetching food requests:", error);
      throw error;
    }
  },

  getRequestById: async (id: number): Promise<FoodRequest | undefined> => {
    try {
      const request = await ApiService.get(`food-requests/${id}`);
      return request;
    } catch (error) {
      console.error(`Error fetching food request with id ${id}:`, error);
      throw error;
    }
  },

  createRequest: async (request: Partial<FoodRequest>): Promise<FoodRequest> => {
    try {
      const newRequest = await ApiService.post("food-requests", request);
      return newRequest;
    } catch (error) {
      console.error("Error creating food request:", error);
      throw error;
    }
  },

  updateRequest: async (
    id: number,
    updatedRequest: Partial<FoodRequest>
  ): Promise<FoodRequest | undefined> => {
    try {
      const updated = await ApiService.put(`food-requests/${id}`, updatedRequest);
      return updated;
    } catch (error) {
      console.error(`Error updating food request with id ${id}:`, error);
      throw error;
    }
  },

  deleteRequest: async (id: number): Promise<boolean> => {
    try {
      await ApiService.delete(`food-requests/${id}`);
      return true;
    } catch (error) {
      console.error(`Error deleting food request with id ${id}:`, error);
      return false;
    }
  },
};