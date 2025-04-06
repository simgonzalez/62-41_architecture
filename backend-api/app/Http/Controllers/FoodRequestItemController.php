<?php

namespace App\Http\Controllers;

use App\Models\FoodRequestItem;
use App\Services\FoodRequestItemService;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class FoodRequestItemController extends Controller
{
    protected FoodRequestItemService $foodRequestItemService;

    public function __construct(FoodRequestItemService $foodRequestItemService)
    {
        $this->foodRequestItemService = $foodRequestItemService;
    }

    public function index(): JsonResponse
    {
        $foodRequestItems = FoodRequestItem::with(['food', 'unit', 'foodRequest'])->get();
        return response()->json($foodRequestItems);
    }

    public function show(int $id): JsonResponse
    {
        try {
            $foodRequestItem = FoodRequestItem::with(['food', 'unit', 'foodRequest'])->findOrFail($id);
            return response()->json($foodRequestItem);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Food request item not found'], 404);
        }
    }
    
    public function store(Request $request): JsonResponse
    {
        $data = $request->validate([
            'request_id' => 'required|exists:food_requests,id',
            'food_id' => 'required|exists:foods,id',
            'quantity' => 'required|numeric|min:0',
            'unit_id' => 'required|exists:units,id',
        ]);

        $foodRequestItem = $this->foodRequestItemService->create($data);

        return response()->json($foodRequestItem, 201);
    }

    public function update(Request $request, int $id): JsonResponse
    {
        $data = $request->validate([
            'request_id' => 'sometimes|required|exists:food_requests,id',
            'food_id' => 'sometimes|required|exists:foods,id',
            'quantity' => 'sometimes|required|numeric|min:0',
            'unit_id' => 'sometimes|required|exists:units,id',
        ]);

        try {
            $foodRequestItem = FoodRequestItem::findOrFail($id);
            $updatedFoodRequestItem = $this->foodRequestItemService->update($foodRequestItem, $data);

            return response()->json($updatedFoodRequestItem);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Food request item not found'], 404);
        }
    }

    public function destroy(int $id): JsonResponse
    {
        try {
            $foodRequestItem = FoodRequestItem::findOrFail($id);
            $this->foodRequestItemService->delete($foodRequestItem);

            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Food request item not found'], 404);
        }
    }
}