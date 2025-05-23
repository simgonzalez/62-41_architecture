import ApiService from "./ApiService";
import { DehydratedMeal, HydratedMeal } from "@src/types/Meal";

const BACKEND_API_URL = "http://192.168.178.22:8000/api";

export const getIngredientImageUrl = (ingredientName: string) => {
  return `https://www.themealdb.com/images/ingredients/${ingredientName}.png`;
};

export const getMealsByIngredient = async (
  ingredient: string
): Promise<DehydratedMeal[]> => {
  try {
    const response = await ApiService.get(
      `meals?ingredient=${encodeURIComponent(ingredient)}`
    );
    return response.meals;
  } catch (error) {
    console.error("Error fetching meals by ingredient:", error);
    return [];
  }
};

export const getMealById = async (
  idMeal: string
): Promise<HydratedMeal | null> => {
  try {
    const response = await ApiService.get(`meals/${idMeal}`);
    return response.meals ? response.meals[0] : null;
  } catch (error) {
    console.error("Error fetching meal by ID:", error);
    return null;
  }
};

export const getRecommendedMeals = async (): Promise<any[]> => {
  try {
    const response = await ApiService.get("meals/recommend");
    // Defensive: handle both {meals: {meals: [...]}} and {meals: [...]} and fallback to []
    if (Array.isArray(response.meals)) {
      return response.meals;
    } else if (response.meals && Array.isArray(response.meals.meals)) {
      return response.meals.meals;
    }
    return [];
  } catch (error) {
    console.error("Error fetching recommended meals:", error);
    return [];
  }
};