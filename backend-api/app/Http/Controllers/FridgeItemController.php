<?php

namespace App\Http\Controllers;

use App\Models\FridgeItem;
use App\Services\FridgeItemService;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class FridgeItemController extends Controller
{
    protected FridgeItemService $fridgeItemService;

    public function __construct(FridgeItemService $fridgeItemService)
    {
        $this->fridgeItemService = $fridgeItemService;
    }

    public function index(): JsonResponse
    {
        $fridgeItems = FridgeItem::with(['food', 'unit', 'fridge', 'user'])->get();
        return response()->json($fridgeItems);
    }

    public function show(int $id): JsonResponse
    {
        try {
            $fridgeItem = FridgeItem::with(['food', 'unit', 'fridge', 'user'])->findOrFail($id);
            return response()->json($fridgeItem);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Fridge item not found'], 404);
        }
    }
    
    public function store(Request $request): JsonResponse
    {
        $data = $request->validate([
            'food_id' => 'required|exists:foods,id',
            'quantity' => 'required|numeric|min:0',
            'unit_id' => 'required|exists:units,id',
            'expiration_date' => 'nullable|date|after:today',
            'fridge_id' => 'required|exists:fridges,id',
            'added_by_user_id' => 'required|exists:users,id',
        ]);

        $fridgeItem = $this->fridgeItemService->create($data);

        return response()->json($fridgeItem, 201);
    }

    public function update(Request $request, int $id): JsonResponse
    {
        $data = $request->validate([
            'food_id' => 'sometimes|required|exists:foods,id',
            'quantity' => 'sometimes|required|numeric|min:0',
            'unit_id' => 'sometimes|required|exists:units,id',
            'expiration_date' => 'nullable|date|after:today',
            'fridge_id' => 'sometimes|required|exists:fridges,id',
            'added_by_user_id' => 'sometimes|required|exists:users,id',
        ]);

        try {
            $fridgeItem = FridgeItem::findOrFail($id);
            $updatedFridgeItem = $this->fridgeItemService->update($fridgeItem, $data);

            return response()->json($updatedFridgeItem);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Fridge item not found'], 404);
        }
    }

    public function destroy(int $id): JsonResponse
    {
        try {
            $fridgeItem = FridgeItem::findOrFail($id);
            $this->fridgeItemService->delete($fridgeItem);

            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Fridge item not found'], 404);
        }
    }
}