import { useState, useCallback } from "react";
import { FridgeItemService } from "@services/FridgeItemService";
import { Food } from "@src/types/Food";
import { Fridge } from "@src/types/Fridge";
import { FridgeItem } from "@src/types/FridgeItem";
import { addDays } from "date-fns";
import { Quantity } from "@src/types/Quantity";

const useSaveItem = (
  fridge: Fridge | null,
  onItemSaved: () => void,
  existingItem?: FridgeItem
) => {
  const [newItemQuantity, setNewItemQuantity] = useState<Quantity>(
    existingItem?.quantity || { value: 500, unit: "gr" }
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

      const fridgeId = fridge?.id || existingItem?.fridgeId;

      if (!fridgeId) {
        console.error("No fridge ID available");
        return;
      }

      const item: FridgeItem = {
        id: itemId || 0, // Use 0 for new items, existing ID for updates
        food: newItemFood,
        quantity: newItemQuantity,
        expirationDate: newItemExpirationDate.toISOString(),
        fridgeId: fridgeId,
      };

      if (itemId) {
        // Update existing item
        await FridgeItemService.updateItem(item);
      } else {
        // Create new item
        await FridgeItemService.addItem(item);
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
