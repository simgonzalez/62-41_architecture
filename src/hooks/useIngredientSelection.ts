import { useState, useCallback } from "react";
import { Food } from "@src/types/Food";
import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";

const useIngredientSelection = () => {
  const [newItemFood, setNewItemFood] = useState<Food>({
    id: 0,
    name: "",
    ingredientOpenMealDbName: "",
  });

  const handleSelectIngredient = useCallback(
    (ingredient: IngredientOpenMealDb) => {
      setNewItemFood({
        id: ingredient.idIngredient,
        name: ingredient.strIngredient,
        ingredientOpenMealDbName: ingredient.strIngredient,
      });
    },
    []
  );

  return { newItemFood, handleSelectIngredient };
};

export default useIngredientSelection;
