import { useState } from "react";
import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";

const useIngredientSearch = (
  ingredients: IngredientOpenMealDb[],
  setFilteredIngredients: React.Dispatch<
    React.SetStateAction<IngredientOpenMealDb[]>
  >
) => {
  const [searchQuery, setSearchQuery] = useState("");

  const handleSearch = (query: string) => {
    setSearchQuery(query);
    if (query) {
      const filtered = ingredients.filter((ingredient) =>
        ingredient.strIngredient.toLowerCase().includes(query.toLowerCase())
      );
      setFilteredIngredients(filtered.slice(0, 30));
    } else {
      setFilteredIngredients(ingredients.slice(0, 30));
    }
  };

  return { searchQuery, handleSearch };
};

export default useIngredientSearch;
