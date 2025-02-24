import { Food } from "./Food";
import { Quantity } from "./Quantity";

export interface FridgeItem {
  id: number;
  food: Food;
  quantity: Quantity;
  expirationDate: string;
  fridgeId: number;
}
