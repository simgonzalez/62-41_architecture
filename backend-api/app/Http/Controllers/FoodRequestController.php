<?php

namespace App\Http\Controllers;

use App\Enums\Status;
use App\Services\FoodRequestService;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Exception;

class FoodRequestController extends Controller
{
    protected FoodRequestService $foodRequestService;

    public function __construct(FoodRequestService $foodRequestService)
    {
        $this->foodRequestService = $foodRequestService;
    }

    public function index(): JsonResponse
    {
        try {
            $user = auth()->user();
            $foodRequests = $this->foodRequestService->getAllByUserOrganizations($user->id);

            // Transform the response to include additional names
            $response = $foodRequests->map(function ($foodRequest) {
                return [
                    'id' => $foodRequest->id,
                    'name' => $foodRequest->name,
                    'description' => $foodRequest->description,
                    'deadline_date' => $foodRequest->deadline_date,
                    'organization_id' => $foodRequest->organization_id,
                    'organization_name' => $foodRequest->organization->name, // Include organization name
                    'responsible_user_id' => $foodRequest->responsible_user_id,
                    'responsible_user_name' => $foodRequest->responsibleUser->name, // Include responsible user name
                    'created_by_user_id' => $foodRequest->created_by_user_id,
                    'created_by_user_name' => $foodRequest->createdByUser->name, // Include created by user name
                    'status' => $foodRequest->status->name, // Include status name
                ];
            });

            return response()->json($response);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching food requests'], 500);
        }
    }


    public function show(int $id): JsonResponse
    {
        try {
            $user = auth()->user();
            $foodRequest = $this->foodRequestService->getByIdAndUserOrganizations($id, $user->id);

            if (!$foodRequest) {
                return response()->json(['error' => 'Food request not found or access denied'], 404);
            }

            // Transform the response to include additional names
            $response = [
                'id' => $foodRequest->id,
                'name' => $foodRequest->name,
                'description' => $foodRequest->description,
                'deadline_date' => $foodRequest->deadline_date,
                'organization_id' => $foodRequest->organization_id,
                'organization_name' => $foodRequest->organization->name, // Include organization name
                'responsible_user_id' => $foodRequest->responsible_user_id,
                'responsible_user_name' => $foodRequest->responsibleUser->name, // Include responsible user name
                'created_by_user_id' => $foodRequest->created_by_user_id,
                'created_by_user_name' => $foodRequest->createdByUser->name, // Include created by user name
                'status' => $foodRequest->status->name, // Include status name
            ];

            return response()->json($response);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching the food request'], 500);
        }
    }

    public function store(Request $request): JsonResponse
{
    try {
        $user = auth()->user();

        $data = $request->validate([
            'name' => 'required|string|max:255',
            'description' => 'nullable|string|max:2000',
            'deadline_date' => 'required|date|after:today',
        ]);

        if ($user->organizations->isEmpty()) {
            return response()->json(['error' => 'You do not belong to any organization'], 403);
        }

        $data['organization_id'] = $user->organizations->first()->id;
        $data['responsible_user_id'] = $user->id;
        $data['status_id'] = \App\Models\Status::where('name', 'pending')->firstOrFail()->id;
        $data['created_by_user_id'] = $user->id; 

        $foodRequest = $this->foodRequestService->create($data);

        return response()->json($foodRequest, 201);
    } catch (Exception $e) {
        return response()->json(['error' => 'An error occurred while creating the food request'], 500);
    }
}

    public function update(Request $request, int $id): JsonResponse
    {
        try {
            $user = auth()->user();
            $data = $request->validate([
                'name' => 'sometimes|required|string|max:255',
                'organization_id' => 'sometimes|required|exists:organizations,id',
                'description' => 'nullable|string|max:2000',
                'deadline_date' => 'sometimes|required|date|after:today',
                'responsible_user_id' => 'sometimes|required|exists:users,id',
                'status_id' => 'sometimes|required|exists:statuses,id',
            ]);

            $foodRequest = $this->foodRequestService->getByIdAndUserOrganizations($id, $user->id);

            if (!$foodRequest) {
                return response()->json(['error' => 'Food request not found or access denied'], 404);
            }

            // Ensure the user belongs to the organization if updating the organization_id
            if (isset($data['organization_id']) && !$user->organizations->contains('id', $data['organization_id'])) {
                return response()->json(['error' => 'You do not belong to this organization'], 403);
            }

            $updatedFoodRequest = $this->foodRequestService->update($id, $data);
            return response()->json($updatedFoodRequest);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while updating the food request'], 500);
        }
    }

    public function destroy(int $id): JsonResponse
    {
        try {
            $this->foodRequestService->delete($id);
            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Food request not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while deleting the food request'], 500);
        }
    }
}