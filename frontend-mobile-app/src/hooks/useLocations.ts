import { useEffect, useState } from "react";
import { getLocations } from "@src/services/FridgeLocationService";
import { FridgeLocation } from "@src/types/FridgeLocation";

const useLocations = () => {
  const [locations, setLocations] = useState<FridgeLocation[]>([]);
  const [location, setLocation] = useState<FridgeLocation | null>(null);

  useEffect(() => {
    const fetchLocations = async () => {
      const userLocations = await getLocations();
      setLocations(userLocations);
      setLocation(userLocations[0]);
    };

    fetchLocations();
  }, []);

  return { locations, location, setLocation };
};

export default useLocations;
