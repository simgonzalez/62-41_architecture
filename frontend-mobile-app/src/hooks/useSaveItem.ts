import { useState, useCallback } from "react";
import { FridgeItemService } from "@services/FridgeItemService";
import { Food } from "@src/types/Food";
import { Fridge } from "@src/types/Fridge";
import { FridgeItem } from "@src/types/FridgeItem";
import { addDays } from "date-fns";
import { DEFAULT_QUANTITY } from "@src/utils/constants";
import { Unit } from "@src/types/Unit";

const useSaveItem = (
  fridge: Fridge | null,
  onItemSaved: () => void,
  existingItem?: FridgeItem
) => {
  const [newItemQuantity, setNewItemQuantity] = useState<number>(
    existingItem?.quantity ?? DEFAULT_QUANTITY.value
  );
  const [newItemUnit, setNewItemUnit] = useState<Unit | null>(
    existingItem?.unit ?? null
  );
  const [newItemExpirationDate, setNewItemExpirationDate] = useState<Date>(
    existingItem
      ? new Date(existingItem.expirationDate)
      : addDays(new Date(), 7)
  );

  const handleSaveItem = useCallback(
    async (
      newItemFood: Food,
      newItemQuantity: number,
      newItemUnit: Unit | null,
      newItemExpirationDate: string, // now expects a string in YYYY-MM-DD format
      itemId?: number
    ) => {
      if (!fridge && !existingItem) {
        console.error("No fridge selected and no existing item provided");
        return;
      }

      const fridgeForItem = fridge ?? existingItem?.fridge;

      if (!fridgeForItem) {
        console.error("No fridge ID available");
        return;
      }

      if (!newItemUnit) {
        console.error("No unit selected");
        return;
      }

      if (itemId) {
        await FridgeItemService.update(
          fridgeForItem.id,
          itemId,
          {
            food_id: newItemFood.id,
            quantity: newItemQuantity,
            unit_id: newItemUnit.id, // use id
            expiration_date: newItemExpirationDate,
          }
        );
      } else {
        await FridgeItemService.create(fridgeForItem.id, {
          food_id: newItemFood.id,
          quantity: newItemQuantity,
          unit_id: newItemUnit.id, // use id
          expiration_date: newItemExpirationDate,
        });
      }

      onItemSaved();
    },
    [fridge, existingItem, onItemSaved]
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

export default useSaveItem;
