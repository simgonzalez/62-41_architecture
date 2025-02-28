import { useEffect } from "react";
import { useFridgeItemsContext } from "@contexts/FridgeItemsContext";

const useRefreshOnDirty = (refreshFunctions: (() => void)[]) => {
  const { isDirty, resetDirtyFlag } = useFridgeItemsContext();

  useEffect(() => {
    if (isDirty) {
      refreshFunctions.forEach((fn) => fn());
      resetDirtyFlag();
    }
  }, [isDirty, resetDirtyFlag, ...refreshFunctions]);
};

export default useRefreshOnDirty;
