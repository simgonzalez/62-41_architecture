import axios from "axios";

const API_URL = "https://www.themealdb.com/api/json/v1/1/filter.php";

export const getIngredientImageUrl = (ingredientName: string) => {
  return `https://www.themealdb.com/images/ingredients/${ingredientName}.png`;
};

export const getMealsByIngredient = async (ingredient: string) => {
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
