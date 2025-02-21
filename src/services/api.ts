// Mock service for REST Countries API
export const getCountries = async () => {
  return [
    { name: "France", code: "FR" },
    { name: "United States", code: "US" },
    // Add more mock countries as needed
  ];
};

// Mock service for TheMealDB API
export const getMealsByIngredient = async (ingredient: string) => {
  return [
    { id: "52772", name: "Chicken Handi", category: "Chicken", area: "Indian" },
    { id: "52773", name: "Beef Wellington", category: "Beef", area: "British" },
    // Add more mock meals as needed
  ];
};
