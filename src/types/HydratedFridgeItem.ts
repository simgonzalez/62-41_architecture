import { FridgeItem } from "./FridgeItem";

export interface HydratedFridgeItem extends FridgeItem {
  fridgeName: string;
}