import { useEffect, useState } from "react";
import { UnitService, UnitApi } from "@services/UnitService";

const useUnits = () => {
  const [units, setUnits] = useState<UnitApi[]>([]);

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
