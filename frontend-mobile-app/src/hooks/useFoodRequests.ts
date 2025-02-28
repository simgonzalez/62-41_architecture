import { useState } from "react";
import { FoodRequest } from "@src/types/FoodRequest";
import { RequestService } from "@services/RequestService";
import { FridgeItemService } from "@services/FridgeItemService";
import { useFridgeItemsContext } from "@contexts/FridgeItemsContext";
import useRefreshOnDirty from "./useRefreshOnDirty";

export interface RequestWithFulfillmentStatus extends FoodRequest {
  canFulfill: boolean;
  fulfillableItems: number[];
}

const useFoodRequests = () => {
  const [requests, setRequests] = useState<RequestWithFulfillmentStatus[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const fetchRequests = async () => {
    try {
      setLoading(true);
      const allRequests = RequestService.getAllRequests();
      const fridgeItems = FridgeItemService.getAll();

      const requestsWithStatus = allRequests.map((request) => {
        const fulfillableItems = checkFulfillableItems(request, fridgeItems);
        return {
          ...request,
          canFulfill: fulfillableItems.length > 0,
          fulfillableItems,
        };
      });

      setRequests(requestsWithStatus);
      setError(null);
    } catch (err) {
      console.error("Error fetching requests:", err);
      setError("Failed to load requests");
    } finally {
      setLoading(false);
    }
  };

  const checkFulfillableItems = (
    request: FoodRequest,
    fridgeItems: any[]
  ): number[] => {
    return request.items
      .filter((item) => {
        const matchingItems = fridgeItems.filter(
          (fridgeItem) =>
            fridgeItem.food.ingredientOpenMealDbName.toLowerCase() ===
            item.food.ingredientOpenMealDbName.toLowerCase()
        );

        return matchingItems.some((fridgeItem) => {
          return (
            fridgeItem.quantity.unit === item.quantity.unit &&
            fridgeItem.quantity.value >= item.quantity.value
          );
        });
      })
      .map((item) => item.id);
  };

  useRefreshOnDirty([fetchRequests]);

  return { requests, loading, error, fetchRequests };
};

export default useFoodRequests;
