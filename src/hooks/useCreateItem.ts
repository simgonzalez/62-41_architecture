import { useState, useCallback } from "react";
import { FridgeItemService } from "@services/FridgeItemService";
import { Food } from "@src/types/Food";
import { Fridge } from "@src/types/Fridge";
import { addDays } from "date-fns";

const useCreateItem = (
  fridge: Fridge,
  onDismiss: () => void,
  onItemAdded: () => void
) => {
  const [newItemQuantity, setNewItemQuantity] = useState("500");
  const [newItemUnit, setNewItemUnit] = useState("gr");
  const [newItemExpirationDate, setNewItemExpirationDate] = useState(
    addDays(new Date(), 7)
  );

  const handleSaveItem = useCallback(
    async (newItemFood: Food) => {
      const quantityValue = parseInt(newItemQuantity);
      if (isNaN(quantityValue)) {
        alert("Please enter a valid quantity.");
        return;
      }

      const newItem = {
        id: 0,
        food: newItemFood,
        quantity: { value: quantityValue, unit: newItemUnit },
        expirationDate: newItemExpirationDate.toISOString(),
        fridgeId: fridge.id,
      };
      FridgeItemService.addItem(newItem);
      onDismiss();
      onItemAdded();
    },
    [
      newItemQuantity,
      newItemUnit,
      newItemExpirationDate,
      fridge.id,
      onDismiss,
      onItemAdded,
    ]
  );

  return {
    newItemQuantity,
    setNewItemQuantity,
    newItemUnit,
    setNewItemUnit,
    newItemExpirationDate,
    setNewItemExpirationDate,
    handleSaveItem,
  };
};

export default useCreateItem;
