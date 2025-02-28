import { Food } from "./Food";
import { Quantity } from "./Quantity";

export interface FoodRequestItem {
  id: number;
  food: Food;
  quantity: Quantity;
}

export interface FoodRequest {
  id: number;
  title: string;
  organization: string;
  description: string;
  items: FoodRequestItem[];
  deadlineDateISO: string;
}
