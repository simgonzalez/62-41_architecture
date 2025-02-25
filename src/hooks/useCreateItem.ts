import { useState, useCallback } from "react";
import { FridgeItemService } from "@services/FridgeItemService";
import { Food } from "@src/types/Food";
import { Fridge } from "@src/types/Fridge";
import { addDays } from "date-fns";
import { Quantity } from "@src/types/Quantity";

const useCreateItem = (
  fridge: Fridge,
  onDismiss: () => void,
  onItemAdded: () => void
) => {
  const [newItemQuantity, setNewItemQuantity] = useState({
    value: 500,
    unit: "gr",
  } as Quantity);
  const [newItemExpirationDate, setNewItemExpirationDate] = useState(
    addDays(new Date(), 7)
  );

  const handleSaveItem = useCallback(
    async (newItemFood: Food) => {
      const newItem = {
        id: 0,
        food: newItemFood,
        quantity: newItemQuantity,
        expirationDate: newItemExpirationDate.toISOString(),
        fridgeId: fridge.id,
      };
      FridgeItemService.addItem(newItem);
      onDismiss();
      onItemAdded();
    },
    [newItemQuantity, newItemExpirationDate, fridge.id, onDismiss, onItemAdded]
  );

  return {
    newItemQuantity,
    setNewItemQuantity,
    newItemExpirationDate,
    setNewItemExpirationDate,
    handleSaveItem,
  };
};

export default useCreateItem;
