import { useEffect, useState } from "react";
import { HydratedMeal } from "@src/types/Meal";
import {
  getMealsByIngredient,
  getMealById,
} from "@src/services/TheMealDbService";

const useMealsByIngredient = (ingredientName: string) => {
  const [hydratedMeals, setHydratedMeals] = useState<HydratedMeal[]>([]);

  useEffect(() => {
    const fetchMeals = async () => {
      const dehydratedMeals = await getMealsByIngredient(ingredientName);
      const hydratedMealsPromises = dehydratedMeals.map((meal) =>
        getMealById(meal.idMeal)
      );
      const hydratedMealsResults = await Promise.all(hydratedMealsPromises);
      setHydratedMeals(hydratedMealsResults.filter((meal) => meal !== null));
    };
    fetchMeals();
  }, [ingredientName]);

  return { hydratedMeals };
};

export default useMealsByIngredient;
