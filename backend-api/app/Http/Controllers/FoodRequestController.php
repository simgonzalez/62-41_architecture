<?php

namespace App\Http\Controllers;

use App\Services\FoodRequestService;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class FoodRequestController extends Controller
{
    protected FoodRequestService $foodRequestService;

    public function __construct(FoodRequestService $foodRequestService)
    {
        $this->foodRequestService = $foodRequestService;
    }

    public function index(): JsonResponse
    {
        $foodRequests = $this->foodRequestService->getAll();
        return response()->json($foodRequests);
    }

    public function show(int $id): JsonResponse
    {
        try {
            $foodRequest = $this->foodRequestService->getById($id);
            return response()->json($foodRequest);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Food request not found'], 404);
        }
    }

    public function store(Request $request): JsonResponse
    {
        $data = $request->validate([
            'name' => 'required|string|max:255',
            'organization_id' => 'required|exists:organizations,id',
            'description' => 'nullable|string|max:2000',
            'deadline_date' => 'required|date|after:today',
            'responsible_user_id' => 'required|exists:users,id',
            'created_by_user_id' => 'required|exists:users,id',
            'status_id' => 'required|exists:statuses,id',
        ]);

        $foodRequest = $this->foodRequestService->create($data);

        return response()->json($foodRequest, 201);
    }

    public function update(Request $request, int $id): JsonResponse
    {
        $data = $request->validate([
            'name' => 'sometimes|required|string|max:255',
            'organization_id' => 'sometimes|required|exists:organizations,id',
            'description' => 'nullable|string|max:2000',
            'deadline_date' => 'sometimes|required|date|after:today',
            'responsible_user_id' => 'sometimes|required|exists:users,id',
            'created_by_user_id' => 'sometimes|required|exists:users,id',
            'status_id' => 'sometimes|required|exists:statuses,id',
        ]);

        try {
            $foodRequest = $this->foodRequestService->update($id, $data);
            return response()->json($foodRequest);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Food request not found'], 404);
        }
    }

    public function destroy(int $id): JsonResponse
    {
        try {
            $this->foodRequestService->delete($id);
            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Food request not found'], 404);
        }
    }
}