import { FridgeLocation } from "@src/types/FridgeLocation";

let mockedLocations: FridgeLocation[] = [
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
  { id: 11, name: "Home Gym" },
  { id: 12, name: "Workshop" },
  { id: 13, name: "Attic" },
  { id: 14, name: "Sunroom" },
  { id: 15, name: "Mudroom" },
  { id: 16, name: "Game Room" },
];

export const getLocations = async (): Promise<FridgeLocation[]> => {
  try {
    return mockedLocations;
  } catch (error) {
    console.error("Error fetching fridges:", error);
    throw error;
  }
};

export const deleteLocation = async (id: number): Promise<boolean> => {
  try {
    mockedLocations = mockedLocations.filter((fridge) => fridge.id !== id);
    return true;
  } catch (error) {
    console.error("Error deleting fridge:", error);
    return false;
  }
};

export const addLocation = async (
  location: FridgeLocation
): Promise<boolean> => {
  try {
    mockedLocations.push(location);
    return true;
  } catch (error) {
    console.error("Error adding fridge:", error);
    return false;
  }
};
