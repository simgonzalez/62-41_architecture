import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";
import ApiService from "./ApiService";

export const fetchIngredients = async (): Promise<IngredientOpenMealDb[]> => {
  try {
    const response = await ApiService.get("ingredients");
    return response.meals.map((meal: any) => ({
      idIngredient: meal.idIngredient,
      strIngredient: meal.strIngredient,
      strDescription: meal.strDescription,
      strType: meal.strType,
    }));
  } catch (error) {
    console.error("Error fetching ingredients:", error);
    throw error;
  }
};