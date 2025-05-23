import { Food } from "@src/types/Food";
import { Fridge } from "@src/types/Fridge";
import { FridgeItem } from "@src/types/FridgeItem";
import { addDays } from "date-fns/addDays";

export const DEFAULT_QUANTITY = 1;

export const defaultFridgeItem = (fridge?: Fridge): FridgeItem => {
  return {
    id: -1,
    food: {} as Food,
    quantity: DEFAULT_QUANTITY,
    unit: { id: -1, name: "", code: "" },
    expirationDate: addDays(Date.now(), 5).toISOString(),
    fridge: fridge ?? ({} as Fridge),
  };
};
