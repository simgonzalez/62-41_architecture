import { Food } from "./Food";

export interface FridgeItem {
  id: number;
  name: string;
  food: Food;
  quantity: number;
  expirationDate: Date;
  fridgeId: number;
}
