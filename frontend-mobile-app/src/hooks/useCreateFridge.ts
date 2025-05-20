import { useState } from "react";
import { Fridge } from "@src/types/Fridge";
import { useSnackbar } from "@contexts/SnackbarProvider";
import { FridgeLocation } from "@src/types/FridgeLocation";
import { FridgeService } from "@services/FridgeService";

const useCreateFridge = (
  onFridgeCreated: () => void,
  onDismiss: () => void
) => {
  const [name, setName] = useState("");
  const { showSnackbar } = useSnackbar();

  const handleCreateFridge = async (location: FridgeLocation | null) => {
    if (!location) {
      showSnackbar("Please select a location.");
      return;
    }

    const newFridge: Fridge = {
      id: Math.random(),
      name,
      location,
    };

    const success = await FridgeService.create(newFridge);
    if (success) {
      showSnackbar("The fridge has been successfully created.");
      onFridgeCreated();
      onDismiss();
    } else {
      showSnackbar("Error creating fridge");
    }
  };

  return { name, setName, handleCreateFridge };
};

export default useCreateFridge;
