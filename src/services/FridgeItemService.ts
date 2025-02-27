import { FridgeItem } from "@src/types/FridgeItem";

let fridgeItems: FridgeItem[] = [];

export const FridgeItemService = {
  getAll(): FridgeItem[] {
    return fridgeItems;
  },

  getByFridgeId: (fridgeId: number): FridgeItem[] | undefined => {
    return fridgeItems.filter((item) => item.fridge.id === fridgeId);
  },

  getByClosestExpirationDate: (): FridgeItem | undefined => {
    if (fridgeItems.length === 0) {
      return undefined;
    }

    const today = new Date();
    return fridgeItems.reduce((closestItem, currentItem) => {
      const closestDate = new Date(closestItem.expirationDate);
      const currentDate = new Date(currentItem.expirationDate);

      return currentDate < closestDate && currentDate >= today
        ? currentItem
        : closestItem;
    }, fridgeItems[0]);
  },

  addItem: (fridgeItem: FridgeItem): FridgeItem => {
    const newItem = { ...fridgeItem, id: fridgeItems.length + 1 };
    fridgeItems.push(newItem);
    return newItem;
  },

  update: (
    id: number,
    updatedFridgeItem: Partial<FridgeItem>
  ): FridgeItem | undefined => {
    const index = fridgeItems.findIndex((item) => item.id === id);
    if (index !== -1) {
      fridgeItems[index] = { ...fridgeItems[index], ...updatedFridgeItem };
      return fridgeItems[index];
    }
    return undefined;
  },

  delete: (id: number): boolean => {
    const index = fridgeItems.findIndex((item) => item.id === id);
    if (index !== -1) {
      fridgeItems.splice(index, 1);
      return true;
    }
    return false;
  },
};
