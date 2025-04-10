<?php

namespace App\Http\Controllers;

use App\Models\FoodRequestItem;
use App\Services\FoodRequestItemService;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Exception;

class FoodRequestItemController extends Controller
{
    protected FoodRequestItemService $foodRequestItemService;

    public function __construct(FoodRequestItemService $foodRequestItemService)
    {
        $this->foodRequestItemService = $foodRequestItemService;
    }

    public function index(int $request): JsonResponse
    {
        try {
            $foodRequestItems = FoodRequestItem::where('request_id', $request)
                ->with(['food', 'unit'])
                ->get();

            return response()->json($foodRequestItems);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching food request items'], 500);
        }
    }

    public function show(int $request, int $itemId): JsonResponse
    {
        try {
            $foodRequestItem = FoodRequestItem::where('request_id', $request)
                ->where('id', $itemId)
                ->with(['food', 'unit'])
                ->firstOrFail();

            return response()->json($foodRequestItem);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Food request item not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching the food request item'], 500);
        }
    }

    public function store(Request $request): JsonResponse
    {
        try {
            $data = $request->validate([
                'request_id' => 'required|exists:food_requests,id',
                'food_id' => 'required|exists:foods,id',
                'quantity' => 'required|numeric|min:0',
                'unit_id' => 'required|exists:units,id',
            ]);

            $foodRequestItem = $this->foodRequestItemService->create($data);

            return response()->json($foodRequestItem, 201);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while creating the food request item'], 500);
        }
    }

    public function update(Request $request, int $id): JsonResponse
    {
        try {
            $data = $request->validate([
                'request_id' => 'sometimes|required|exists:food_requests,id',
                'food_id' => 'sometimes|required|exists:foods,id',
                'quantity' => 'sometimes|required|numeric|min:0',
                'unit_id' => 'sometimes|required|exists:units,id',
            ]);

            $foodRequestItem = FoodRequestItem::findOrFail($id);
            $updatedFoodRequestItem = $this->foodRequestItemService->update($foodRequestItem, $data);

            return response()->json($updatedFoodRequestItem);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Food request item not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while updating the food request item'], 500);
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
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while deleting the food request item'], 500);
        }
    }
}