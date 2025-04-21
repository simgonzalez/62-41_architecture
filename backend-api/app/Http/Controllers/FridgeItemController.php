<?php

namespace App\Http\Controllers;

use App\Models\FridgeItem;
use App\Services\FridgeItemService;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Exception;

class FridgeItemController extends Controller
{
    protected FridgeItemService $fridgeItemService;

    public function __construct(FridgeItemService $fridgeItemService)
    {
        $this->fridgeItemService = $fridgeItemService;
    }

    public function index(): JsonResponse
    {
        try {
            $user = auth()->user();

            $fridgeItems = FridgeItem::with(['food', 'unit', 'fridge', 'user'])
                ->whereHas('fridge', function ($query) use ($user) {
                    $query->where('user_id', $user->id);
                })
                ->get();

            return response()->json($fridgeItems);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching fridge items'], 500);
        }
    }

    public function show(int $fridgeId, int $itemId): JsonResponse
    {
        try {
            $user = auth()->user();


            $fridgeItem = FridgeItem::with(['food', 'unit', 'fridge', 'user'])
                ->where('id', $itemId)
                ->where('fridge_id', $fridgeId)
                ->whereHas('fridge', function ($query) use ($user) {
                    $query->where('fridges.user_id', $user->id);
                })
                ->firstOrFail();

            return response()->json($fridgeItem);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Fridge item not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching the fridge item'], 500);
        }
    }

    public function store(Request $request, int $fridge): JsonResponse
    {
        $user = auth()->user();

        $fridgeBelongsToUser = $user->fridges()->where('fridges.id', $fridge)->exists();

        if (!$fridgeBelongsToUser) {
            return response()->json(['error' => 'You do not have permission to add items to this fridge'], 403);
        }

        $data = $request->validate([
            'food_id' => 'required|exists:foods,id',
            'quantity' => 'required|numeric|min:0',
            'unit_id' => 'required|exists:units,id',
            'expiration_date' => 'nullable|date|after:today',
        ]);

        try {
            $data['fridge_id'] = $fridge;
            $data['added_by_user_id'] = $user->id;

            $fridgeItem = $this->fridgeItemService->create($data);

            return response()->json($fridgeItem, 201);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while creating the fridge item'], 500);
        }
    }

    public function update(Request $request, int $fridgeId, int $itemId): JsonResponse
    {
        try {
            $user = auth()->user();

            $data = $request->validate([
                'food_id' => 'sometimes|required|exists:foods,id',
                'quantity' => 'sometimes|required|numeric|min:0',
                'unit_id' => 'sometimes|required|exists:units,id',
                'expiration_date' => 'nullable|date|after:today',
                'fridge_id' => 'sometimes|required|exists:fridges,id',
            ]);

            $fridgeItem = FridgeItem::where('id', $itemId)
                ->where('fridge_id', $fridgeId)
                ->whereHas('fridge', function ($query) use ($user) {
                    $query->where('fridges.user_id', $user->id);
                })
                ->firstOrFail();

            if (isset($data['fridge_id']) && $data['fridge_id'] !== $fridgeId) {
                $newFridgeBelongsToUser = $user->fridges()->where('id', $data['fridge_id'])->exists();
                if (!$newFridgeBelongsToUser) {
                    return response()->json(['error' => 'You do not have permission to move this item to the specified fridge'], 403);
                }
            }

            $updatedFridgeItem = $this->fridgeItemService->update($fridgeItem, $data);

            return response()->json($updatedFridgeItem);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Fridge item not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while updating the fridge item'], 500);
        }
    }

    public function destroy(int $fridgeId, int $itemId): JsonResponse
    {
        try {
            $user = auth()->user();

            $fridgeItem = FridgeItem::where('id', $itemId)
                ->where('fridge_id', $fridgeId)
                ->whereHas('fridge', function ($query) use ($user) {
                    $query->where('fridges.user_id', $user->id);
                })
                ->firstOrFail();

            $this->fridgeItemService->delete($fridgeItem);

            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Fridge item not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while deleting the fridge item'], 500);
        }
    }
}