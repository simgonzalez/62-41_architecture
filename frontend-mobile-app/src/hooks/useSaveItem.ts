import { useState, useCallback } from "react";
import { FridgeItemService } from "@services/FridgeItemService";
import { Food } from "@src/types/Food";
import { Fridge } from "@src/types/Fridge";
import { FridgeItem } from "@src/types/FridgeItem";
import { addDays } from "date-fns";
import { Quantity } from "@src/types/Quantity";
import { DEFAULT_QUANTITY } from "@src/utils/constants";

const useSaveItem = (
  fridge: Fridge | null,
  onItemSaved: () => void,
  existingItem?: FridgeItem
) => {
  const [newItemQuantity, setNewItemQuantity] = useState<Quantity>(
    existingItem?.quantity || DEFAULT_QUANTITY
  );

  const [newItemExpirationDate, setNewItemExpirationDate] = useState<Date>(
    existingItem
      ? new Date(existingItem.expirationDate)
      : addDays(new Date(), 7)
  );

  const handleSaveItem = useCallback(
    async (newItemFood: Food, itemId?: number) => {
      if (!fridge && !existingItem) {
        console.error("No fridge selected and no existing item provided");
        return;
      }

      const fridgeForItem = fridge ?? existingItem?.fridge;

      if (!fridgeForItem) {
        console.error("No fridge ID available");
        return;
      }

      const item: FridgeItem = {
        id: itemId ?? -1,
        food: newItemFood,
        quantity: newItemQuantity,
        expirationDate: newItemExpirationDate.toISOString(),
        fridge: fridgeForItem,
      };

      if (itemId) {
        await FridgeItemService.update(item.id, item);
      } else {
        FridgeItemService.addItem(item);
      }

      onItemSaved();
    },
    [newItemQuantity, newItemExpirationDate, fridge, existingItem, onItemSaved]
  );

  return {
    newItemQuantity,
    setNewItemQuantity,
    newItemExpirationDate,
    setNewItemExpirationDate,
    handleSaveItem,
  };
};

export default useSaveItem;
