import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";
import axios from "axios";

const API_URL = "https://www.themealdb.com/api/json/v1/1/list.php?i=list";

export const fetchIngredients = async (): Promise<IngredientOpenMealDb[]> => {
  try {
    const response = await axios.get(API_URL);
    return response.data.meals;
  } catch (error) {
    console.error("Error fetching ingredients:", error);
    throw error;
  }
};
