import axios from "axios";
import { DehydratedMeal, HydratedMeal } from "@src/types/Meal";

const BACKEND_API_URL = "http://your-backend-url/api";

export const getIngredientImageUrl = (ingredientName: string) => {
  return `https://www.themealdb.com/images/ingredients/${ingredientName}.png`;
};

export const getMealsByIngredient = async (
  ingredient: string
): Promise<DehydratedMeal[]> => {
  try {
    const response = await axios.get(`${BACKEND_API_URL}/meals`, {
      params: { ingredient },
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
    const response = await axios.get(`${BACKEND_API_URL}/meals/${idMeal}`);
    return response.data.meals[0];
  } catch (error) {
    console.error("Error fetching meal by ID:", error);
    return null;
  }
};