import axios from "axios";
import { DehydratedMeal, HydratedMeal } from "@src/types/Meal";

const API_URL = "https://www.themealdb.com/api/json/v1/1/filter.php";
const LOOKUP_URL = "https://www.themealdb.com/api/json/v1/1/lookup.php";

export const getIngredientImageUrl = (ingredientName: string) => {
  return `https://www.themealdb.com/images/ingredients/${ingredientName}.png`;
};

export const getMealsByIngredient = async (
  ingredient: string
): Promise<DehydratedMeal[]> => {
  try {
    const response = await axios.get(API_URL, {
      params: { i: ingredient },
    });
    return response.data.meals;
  } catch (error) {
    console.error("Error fetching meals by ingredient:", error);
    return [];
  }
};

export const getMealById = async (
  idMeal: string
): Promise<HydratedMeal | null> => {
  try {
    const response = await axios.get(LOOKUP_URL, {
      params: { i: idMeal },
    });
    return response.data.meals[0];
  } catch (error) {
    console.error("Error fetching meal by ID:", error);
    return null;
  }
};
