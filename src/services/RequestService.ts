import { FoodRequestItem, FoodRequest } from "@src/types/FoodRequest";

let requests: FoodRequest[] = [
  {
    id: 1,
    title: "Food Drive for Local Shelter",
    organization: "Community Aid",
    description: "We need supplies for our weekly meal program.",
    items: [
      {
        id: 1,
        food: { id: 1, name: "Potatoes", ingredientOpenMealDbName: "Potatoes" },
        quantity: { value: 500, unit: "gr" },
      },
      {
        id: 2,
        food: { id: 2, name: "Carrots", ingredientOpenMealDbName: "Carrots" },
        quantity: { value: 1000, unit: "gr" },
      },
    ],
    deadlineDateISO: new Date(
      Date.now() + 7 * 24 * 60 * 60 * 1000
    ).toISOString(),
  },
  {
    id: 2,
    title: "Emergency Food Bank Supplies",
    organization: "Food for All",
    description: "Our food bank is running low on essential items.",
    items: [
      {
        id: 3,
        food: { id: 3, name: "Rice", ingredientOpenMealDbName: "Rice" },
        quantity: { value: 2, unit: "kg" },
      },
      {
        id: 4,
        food: { id: 4, name: "Beans", ingredientOpenMealDbName: "Beans" },
        quantity: { value: 1, unit: "kg" },
      },
    ],
    deadlineDateISO: new Date(
      Date.now() + 3 * 24 * 60 * 60 * 1000
    ).toISOString(),
  },
];

export const RequestService = {
  getAllRequests: (): FoodRequest[] => {
    return requests;
  },

  getRequestById: (id: number): FoodRequest | undefined => {
    return requests.find((request) => request.id === id);
  },

  createRequest: (request: FoodRequest): FoodRequest => {
    const newRequest = { ...request, id: requests.length + 1 };
    requests.push(newRequest);
    return newRequest;
  },

  updateRequest: (
    id: number,
    updatedRequest: Partial<FoodRequest>
  ): FoodRequest | undefined => {
    const index = requests.findIndex((request) => request.id === id);
    if (index !== -1) {
      requests[index] = { ...requests[index], ...updatedRequest };
      return requests[index];
    }
    return undefined;
  },

  deleteRequest: (id: number): boolean => {
    const index = requests.findIndex((request) => request.id === id);
    if (index !== -1) {
      requests.splice(index, 1);
      return true;
    }
    return false;
  },
};
