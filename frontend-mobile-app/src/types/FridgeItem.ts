import { Food } from "./Food";
import { Fridge } from "./Fridge";
import { Unit } from "./Unit";

export interface FridgeItem {
  id: number;
  food: Food;
  quantity: number; 
  unit: Unit;      
  expirationDate: string;
  fridge: Fridge;
}
