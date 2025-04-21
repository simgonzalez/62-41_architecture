<?php

namespace App\Http\Controllers;

use App\Models\FridgeLocation;
use App\Services\FridgeService;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Exception;

class FridgeController extends Controller
{
    protected FridgeService $fridgeService;

    public function __construct(FridgeService $fridgeService)
    {
        $this->fridgeService = $fridgeService;
    }

    public function index(): JsonResponse
    {
        try {
            $user = auth()->user();
            $fridges = $this->fridgeService->getAllByUser($user->id);
            return response()->json($fridges);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching fridges'], 500);
        }
    }

    public function show(int $id): JsonResponse
    {
        try {
            $user = auth()->user();
            $fridge = $this->fridgeService->getByIdAndUser($id, $user->id);

            if (!$fridge) {
                return response()->json(['error' => 'Fridge not found or access denied'], 404);
            }

            return response()->json($fridge);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching the fridge'], 500);
        }
    }

    public function store(Request $request): JsonResponse
    {
        try {
            $user = auth()->user();
            $data = $request->validate([
                'name' => 'required|string|max:255',
                'location.name' => 'required|string|max:255',
            ]);

            $locationData = $data['location'];
            $location = FridgeLocation::create(['name' => $locationData['name']]);
            $fridgeData = [
                'name' => $data['name'],
                'location_id' => $location->id,
                'user_id' => $user->id,
            ];
            $fridge = $this->fridgeService->create($fridgeData);

            $fridge->load('location');

            return response()->json($fridge, 201);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while creating the fridge'], 500);
        }
    }

    public function update(Request $request, int $id): JsonResponse
    {
        try {
            $data = $request->validate([
                'name' => 'sometimes|required|string|max:255',
                'location.name' => 'sometimes|required|string|max:255',
            ]);

            $fridge = $this->fridgeService->getById($id);

            if (isset($data['name'])) {
                $fridge->name = $data['name'];
            }

            if (isset($data['location']['name'])) {
                if ($fridge->location) {
                    $fridge->location->update(['name' => $data['location']['name']]);
                } else {
                    $location = FridgeLocation::create(['name' => $data['location']['name']]);
                    $fridge->location_id = $location->id;
                }
            }

            $fridge->save();

            $fridge->load('location');

            return response()->json($fridge);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Fridge not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while updating the fridge'], 500);
        }
    }

    public function destroy(int $id): JsonResponse
    {
        try {
            $user = auth()->user();

            $fridge = $this->fridgeService->getByIdAndUser($id, $user->id);

            if (!$fridge) {
                return response()->json(['error' => 'Fridge not found or access denied'], 404);
            }

            if ($fridge->items()->exists()) {
                return response()->json(['error' => 'Fridge cannot be deleted because it contains items'], 400);
            }

            $this->fridgeService->delete($id);

            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Fridge not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while deleting the fridge'], 500);
        }
    }
}