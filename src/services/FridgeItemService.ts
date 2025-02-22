import { FridgeItem } from "@src/types/FridgeItem";

let fridgeItems: FridgeItem[] = [];

export const FridgeItemService = {
  getAll: (): FridgeItem[] => {
    return fridgeItems;
  },

  getByFridgeId: (fridgeId: number): FridgeItem | undefined => {
    return fridgeItems.find((item) => item.fridgeId === fridgeId);
  },

  create: (fridgeItem: FridgeItem): FridgeItem => {
    fridgeItems.push(fridgeItem);
    return fridgeItem;
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
