import { useEffect, useState } from "react";
import { FridgeItem } from "@src/types/FridgeItem";
import { HydratedFridgeItem } from "@src/types/HydratedFridgeItem";
import { FridgeService } from "@services/FridgeService";

const useHydratedFridgeItems = (items: FridgeItem[]) => {
  const [hydratedItems, setHydratedItems] = useState<HydratedFridgeItem[]>([]);

  useEffect(() => {
    const hydrateItems = async () => {
      const itemsWithFridgeNames = await Promise.all(
        items.map(async (item) => {
          const fridge = await FridgeService.getById(item.fridgeId);
          return { ...item, fridgeName: fridge.name };
        })
      );
      setHydratedItems(itemsWithFridgeNames);
    };

    hydrateItems();
  }, [items]);

  return hydratedItems;
};

export default useHydratedFridgeItems;
