<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use App\Models\FridgeItem;
use App\Models\FoodRequest;
use App\Models\FoodRequestItem;
use App\Models\RequestContribution;
use App\Services\FridgeItemService;
use App\Services\FoodRequestItemService;
use App\Services\RequestContributionService;
use Illuminate\Support\Facades\DB;
use Exception;

class ContributionController extends Controller
{
    protected $fridgeItemService;
    protected $foodRequestItemService;
    protected $requestContributionService;

    public function __construct(
        FridgeItemService $fridgeItemService,
        FoodRequestItemService $foodRequestItemService,
        RequestContributionService $requestContributionService
    ) {
        $this->fridgeItemService = $fridgeItemService;
        $this->foodRequestItemService = $foodRequestItemService;
        $this->requestContributionService = $requestContributionService;
    }

    /**
     * Handle a contribution: subtract from user fridge and request.
     *
     * Request body:
     * {
     *   "request_id": 1,
     *   "contributions": [
     *     { "food_id": 1, "quantity": 2, "unit_id": 1 }
     *   ]
     * }
     */
    public function contribute(Request $request): JsonResponse
    {
        $user = auth()->user();
        $data = $request->validate([
            'request_id' => 'required|exists:food_requests,id',
            'contributions' => 'required|array',
            'contributions.*.food_id' => 'required|exists:foods,id',
            'contributions.*.quantity' => 'required|numeric|min:0.01',
            'contributions.*.unit_id' => 'required|exists:units,id',
        ]);

        DB::beginTransaction();
        try {
            foreach ($data['contributions'] as $contribution) {
                // 1. Find matching fridge item for user
                $fridgeItem = FridgeItem::whereHas('fridge', function ($q) use ($user) {
                    $q->where('user_id', $user->id);
                })
                ->where('food_id', $contribution['food_id'])
                ->where('unit_id', $contribution['unit_id'])
                ->first();

                if (!$fridgeItem || $fridgeItem->quantity < $contribution['quantity']) {
                    DB::rollBack();
                    return response()->json(['error' => 'Insufficient quantity in fridge for food_id ' . $contribution['food_id']], 400);
                }

                // 2. Subtract from fridge item
                $fridgeItem->quantity -= $contribution['quantity'];
                if ($fridgeItem->quantity <= 0) {
                    $fridgeItem->delete();
                } else {
                    $fridgeItem->save();
                }

                // 3. Subtract from food request item
                $foodRequestItem = FoodRequestItem::where('request_id', $data['request_id'])
                    ->where('food_id', $contribution['food_id'])
                    ->where('unit_id', $contribution['unit_id'])
                    ->first();
                if ($foodRequestItem) {
                    $foodRequestItem->quantity -= $contribution['quantity'];
                    if ($foodRequestItem->quantity <= 0) {
                        $foodRequestItem->delete();
                    } else {
                        $foodRequestItem->save();
                    }
                }

                // 4. Log the contribution
                $this->requestContributionService->create([
                    'user_id' => $user->id,
                    'request_id' => $data['request_id'],
                    'quantity' => $contribution['quantity'],
                    'unit_id' => $contribution['unit_id'],
                ]);
            }
            DB::commit();
            return response()->json(['message' => 'Contribution successful']);
        } catch (Exception $e) {
            DB::rollBack();
            return response()->json(['error' => 'Contribution failed', 'details' => $e->getMessage()], 500);
        }
    }
}
