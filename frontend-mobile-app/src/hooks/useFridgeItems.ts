import { useEffect, useState } from "react";
import { FridgeItem } from "@src/types/FridgeItem";
import { FridgeItemService } from "@services/FridgeItemService";

const useFridgeItems = (fridgeId: number) => {
  const [fridgeItems, setFridgeItems] = useState<FridgeItem[]>([]);

  const fetchFridgeItems = async () => {
    const items = await FridgeItemService.getAllByFridgeId(fridgeId);
    if (items) {
      setFridgeItems(items);
    }
  };

  useEffect(() => {
    fetchFridgeItems();
  }, [fridgeId]);

  return { fridgeItems, fetchFridgeItems };
};

export default useFridgeItems;
