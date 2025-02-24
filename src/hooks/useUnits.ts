import { useEffect, useState } from "react";
import { UnitService } from "@services/UnitService";

const useUnits = () => {
  const [units, setUnits] = useState<string[]>([]);

  useEffect(() => {
    const fetchUnits = async () => {
      const availableUnits = await UnitService.getUnits();
      setUnits(availableUnits);
    };

    fetchUnits();
  }, []);

  return { units };
};

export default useUnits;
