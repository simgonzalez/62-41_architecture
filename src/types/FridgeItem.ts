import { Food } from "./Food";

export interface FridgeItem {
  id: number;
  food: Food;
  quantity: number;
  expirationDate: string;
  fridgeId: number;
}
