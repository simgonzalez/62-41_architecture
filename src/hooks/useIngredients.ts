import { useEffect, useState } from "react";
import { fetchIngredients } from "@src/services/IngredientService";
import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";

const useIngredients = () => {
  const [ingredients, setIngredients] = useState<IngredientOpenMealDb[]>([]);
  const [filteredIngredients, setFilteredIngredients] = useState<
    IngredientOpenMealDb[]
  >([]);

  useEffect(() => {
    const loadIngredients = async () => {
      try {
        const fetchedIngredients = await fetchIngredients();
        setIngredients(fetchedIngredients);
        setFilteredIngredients(fetchedIngredients.slice(0, 30));
      } catch (error) {
        console.error("Error loading ingredients:", error);
      }
    };
    loadIngredients();
  }, []);

  return { ingredients, filteredIngredients, setFilteredIngredients };
};

export default useIngredients;