import { Fridge } from "@src/types/Fridge";
import { FridgeLocation } from "@src/types/FridgeLocation";

const locations: FridgeLocation[] = [
  { id: 1, name: "Kitchen" },
  { id: 2, name: "Garage" },
  { id: 3, name: "Office" },
  { id: 4, name: "Basement" },
  { id: 5, name: "Living Room" },
  { id: 6, name: "Dining Room" },
  { id: 7, name: "Bedroom" },
  { id: 8, name: "Pantry" },
  { id: 9, name: "Laundry Room" },
  { id: 10, name: "Guest Room" },
];

let mockedFridges: Fridge[] = [
  { id: 1, name: "Kitchen Fridge", location: locations[0] },
  { id: 2, name: "Garage Fridge", location: locations[1] },
  { id: 3, name: "Office Fridge", location: locations[2] },
  { id: 4, name: "Basement Fridge", location: locations[3] },
  { id: 5, name: "Living Room Fridge", location: locations[4] },
  { id: 6, name: "Dining Room Fridge", location: locations[5] },
  { id: 7, name: "Bedroom Fridge", location: locations[6] },
  { id: 8, name: "Pantry Fridge", location: locations[7] },
  { id: 9, name: "Laundry Room Fridge", location: locations[8] },
  { id: 10, name: "Guest Room Fridge", location: locations[9] },
];

export const fetchFridges = async (): Promise<Fridge[]> => {
  try {
    return mockedFridges;
  } catch (error) {
    console.error("Error fetching fridges:", error);
    throw error;
  }
};

export const deleteFridge = async (id: number): Promise<boolean> => {
  try {
    mockedFridges = mockedFridges.filter((fridge) => fridge.id !== id);
    return true;
  } catch (error) {
    console.error("Error deleting fridge:", error);
    return false;
  }
};

export const addFridge = async (fridge: Fridge): Promise<boolean> => {
  try {
    mockedFridges.push(fridge);
    return true;
  } catch (error) {
    console.error("Error adding fridge:", error);
    return false;
  }
};

export const FridgeService = {
  getById: async (id: number): Promise<Fridge> => {
    const fridge = mockedFridges.find((fridge) => fridge.id === id);
    if (!fridge) {
      throw new Error(`Fridge with id ${id} not found`);
    }
    return fridge;
  },
};
