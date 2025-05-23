import { useEffect, useState } from "react";
import { Fridge } from "@src/types/Fridge";
import { FridgeService } from "@src/services/FridgeService";

const useFridges = () => {
  const [fridges, setFridges] = useState<Fridge[]>([]);
  const [error, setError] = useState<string | null>(null);

  const loadFridges = async () => {
    try {
      const fetchedFridges = await FridgeService.getAll();
      setFridges(fetchedFridges);
      setError(null);
    } catch (err) {
      setError("Error loading fridges");
    }
  };

  useEffect(() => {
    loadFridges();
  }, []);

  return { fridges, error, loadFridges };
};

export default useFridges;
