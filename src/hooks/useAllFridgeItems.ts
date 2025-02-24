import { useEffect, useState, useCallback } from "react";
import { FridgeItem } from "@src/types/FridgeItem";
import { FridgeItemService } from "@services/FridgeItemService";

const useAllFridgeItems = () => {
  const [fridgeItems, setFridgeItems] = useState<FridgeItem[]>([]);

  const fetchFridgeItems = useCallback(async () => {
    const items = FridgeItemService.getAll();
    setFridgeItems(items);
  }, []);

  useEffect(() => {
    fetchFridgeItems();
  }, [fetchFridgeItems]);

  return { fridgeItems, fetchFridgeItems };
};

export default useAllFridgeItems;
