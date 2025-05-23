import { useState } from "react";
import { useSnackbar } from "@contexts/SnackbarProvider";
import { FridgeService } from "@services/FridgeService";

const useCreateFridge = (
  onFridgeCreated: () => void,
  onDismiss: () => void
) => {
  const [name, setName] = useState("");
  const { showSnackbar } = useSnackbar();

  const handleCreateFridge = async (locationName: string) => {
    if (!locationName || locationName.trim() === "") {
      showSnackbar("Please enter a location.");
      return;
    }

    const fridgePayload = {
      name,
      location: { name: locationName },
    } as any;

    try {
      await FridgeService.create(fridgePayload);
      showSnackbar("The fridge has been successfully created.");
      onFridgeCreated();
      onDismiss();
    } catch (e: any) {
      showSnackbar("Error creating fridge: " + (e?.message ?? ""));
    }
  };

  return { name, setName, handleCreateFridge };
};

export default useCreateFridge;
