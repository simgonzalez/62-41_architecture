import { Food } from "./Food";
import { Fridge } from "./Fridge";
import { Quantity } from "./Quantity";

export interface FridgeItem {
  id: number;
  food: Food;
  quantity: Quantity;
  expirationDate: string;
  fridge: Fridge;
}
