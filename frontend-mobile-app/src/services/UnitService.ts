export const UnitService = {
  getUnits: async (): Promise<string[]> => {
    return ["gr", "kg", "ml", "cl", "oz", "lb"];
  },
};
