import { Food } from "@src/types/Food";

let foods: Food[] = [];

export const FoodService = {
  getAll: (): Food[] => {
    return foods;
  },

  getById: (id: number): Food | undefined => {
    return foods.find((food) => food.id === id);
  },

  create: (food: Food): Food => {
    foods.push(food);
    return food;
  },

  update: (id: number, updatedFood: Partial<Food>): Food | undefined => {
    const index = foods.findIndex((food) => food.id === id);
    if (index !== -1) {
      foods[index] = { ...foods[index], ...updatedFood };
      return foods[index];
    }
    return undefined;
  },

  delete: (id: number): boolean => {
    const index = foods.findIndex((food) => food.id === id);
    if (index !== -1) {
      foods.splice(index, 1);
      return true;
    }
    return false;
  },
};
