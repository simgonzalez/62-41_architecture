import { useState } from "react";
import { HydratedMeal } from "@src/types/Meal";

const useSelectedMeal = () => {
  const [selectedMeal, setSelectedMeal] = useState<HydratedMeal | null>(null);
  const [visible, setVisible] = useState(false);

  const handleMealPress = (meal: HydratedMeal) => {
    setSelectedMeal(meal);
    setVisible(true);
  };

  const handleClose = () => {
    setVisible(false);
    setSelectedMeal(null);
  };

  return { selectedMeal, visible, handleMealPress, handleClose };
};

export default useSelectedMeal;
