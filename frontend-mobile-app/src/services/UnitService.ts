import ApiService from "./ApiService";

export const UnitService = {
  getUnits: async (): Promise<string[]> => {
    try {
      const units = await ApiService.get("units");
      return units.map((unit: { name: string }) => unit.name);
    } catch (error) {
      console.error("Error fetching units:", error);
      throw error;
    }
  },
};