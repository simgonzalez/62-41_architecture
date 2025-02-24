import { useEffect, useState, useCallback } from "react";
import { FridgeItem } from "@src/types/FridgeItem";
import { FridgeItemService } from "@services/FridgeItemService";

const useClosestExpiringItem = () => {
  const [closestExpiringItem, setClosestExpiringItem] = useState<
    FridgeItem | undefined
  >(undefined);

  const fetchClosestExpiringItem = useCallback(async () => {
    const item = await FridgeItemService.getByClosestExpirationDate();
    setClosestExpiringItem(item);
  }, []);

  useEffect(() => {
    fetchClosestExpiringItem();
  }, [fetchClosestExpiringItem]);

  return { closestExpiringItem, fetchClosestExpiringItem };
};

export default useClosestExpiringItem;