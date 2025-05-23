import { Food } from "./Food";
import { Unit } from "./Unit";

export interface FoodRequestItem {
  id: number;
  foodId: number;
  quantity: number;
  unitId: number;
  food: Food;
  unit: Unit;
}

export interface FoodRequest {
  id: number;
  name: string;
  organizationId: number;
  organizationName: string;
  description: string;
  deadlineDate: string;
  responsibleUserId: number;
  responsibleUserName: string;
  createdByUserId: number;
  createdByUserName: string;
  status: string;
  items: FoodRequestItem[];
}
