import ApiService from "./ApiService";

export interface UnitApi {
  id: number;
  name: string;
  code: string;
}

export const UnitService = {
  getUnits: async (): Promise<UnitApi[]> => {
    try {
      const units = await ApiService.get("units");
      return units.map((unit: any) => ({
        id: unit.id,
        name: unit.name,
        code: unit.code,
      }));
    } catch (error) {
      console.error("Error fetching units:", error);
      throw error;
    }
  },
};