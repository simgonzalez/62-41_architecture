import { useState } from "react";
import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";
import { Food } from "@src/types/Food";

const useIngredientSelection = (initialFood?: Food) => {
  const [newItemFood, setNewItemFood] = useState<Food | null>(
    initialFood || null
  );

  const handleSelectIngredient = (ingredient: IngredientOpenMealDb) => {
    setNewItemFood({
      id: ingredient.idIngredient,
      name: ingredient.strIngredient,
      ingredientOpenMealDbName: ingredient.strIngredient,
    });
  };

  return { newItemFood, setNewItemFood, handleSelectIngredient };
};

export default useIngredientSelection;
