import React, { createContext, useState, useContext, ReactNode } from "react";

interface FridgeItemsContextType {
  isDirty: boolean;
  markAsDirty: () => void;
  resetDirtyFlag: () => void;
}

const FridgeItemsContext = createContext<FridgeItemsContextType | undefined>(
  undefined
);

interface FridgeItemsProviderProps {
  children: ReactNode;
}

export const FridgeItemsProvider: React.FC<FridgeItemsProviderProps> = ({
  children,
}) => {
  const [isDirty, setIsDirty] = useState(false);

  const markAsDirty = () => {
    setIsDirty(true);
  };

  const resetDirtyFlag = () => {
    setIsDirty(false);
  };

  return (
    <FridgeItemsContext.Provider
      value={{ isDirty, markAsDirty, resetDirtyFlag }}
    >
      {children}
    </FridgeItemsContext.Provider>
  );
};

export const useFridgeItemsContext = (): FridgeItemsContextType => {
  const context = useContext(FridgeItemsContext);
  if (context === undefined) {
    throw new Error("useFridgeItems must be used within a FridgeItemsProvider");
  }
  return context;
};
