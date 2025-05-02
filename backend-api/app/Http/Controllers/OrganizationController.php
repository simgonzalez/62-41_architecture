<?php

namespace App\Http\Controllers;

use App\Services\OrganizationService;
use App\Services\AddressService;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Exception;

class OrganizationController extends Controller
{
    protected OrganizationService $organizationService;
    protected AddressService $addressService;

    public function __construct(OrganizationService $organizationService, AddressService $addressService)
    {
        $this->organizationService = $organizationService;
        $this->addressService = $addressService;
    }

    public function index(): JsonResponse
    {
        try {
            $user = auth()->user();

            if ($user->hasRole('admin')) {
                $organizations = $this->organizationService->getAll();
            } else {
                $organizations = $this->organizationService->getAllByUser($user->id);
            }


            return response()->json($organizations);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching organizations'], 500);
        }
    }

    public function show(int $id): JsonResponse
    {
        try {
            $user = auth()->user();
            $organization = $this->organizationService->getByIdAndUser($id, $user->id);

            if (!$organization) {
                return response()->json(['error' => 'Organization not found'], 404);
            }

            return response()->json($organization);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching the organization'], 500);
        }
    }

    public function store(Request $request): JsonResponse
    {
        try {
            $user = auth()->user();

            // Validate the request data
            $data = $request->validate([
                'name' => 'required|string|max:255',
                'description' => 'nullable|string|max:2000',
                'address' => 'required|array',
                'address.street_name' => 'required|string|max:2000',
                'address.street_number' => 'nullable|string|max:20',
                'address.npa' => 'nullable|string|max:10',
                'address.city' => 'nullable|string|max:1000',
            ]);

            $organizationData = [
                'name' => $data['name'],
                'description' => $data['description'] ?? null,
            ];
            $organization = $this->organizationService->create($organizationData);

            $addressData = $data['address'];
            $address = $this->addressService->create($addressData);
            $organization->address()->associate($address);
            $organization->save();

            $organization->users()->attach($user->id);

            return response()->json($organization->load('address'), 201);
        } catch (Exception $e) {
            // Log the exception for debugging
            \Log::error('Error creating organization: ' . $e->getMessage(), ['exception' => $e]);

            return response()->json(['error' => 'An error occurred while creating the organization'], 500);
        }
    }

    public function update(Request $request, int $id): JsonResponse
    {
        try {
            $user = auth()->user();

            $organization = $this->organizationService->getById($id);
            if (!$organization || (!$user->hasRole('admin') && !$organization->users->contains('id', $user->id))) {
                return response()->json(['error' => 'Organization not found or access denied'], 404);
            }

            $data = $request->validate([
                'name' => 'sometimes|required|string|max:255',
                'description' => 'nullable|string|max:2000',
                'address' => 'sometimes|required|array',
                'address.street_name' => 'sometimes|required|string|max:2000',
                'address.street_number' => 'nullable|string|max:20',
                'address.npa' => 'nullable|string|max:10',
                'address.city' => 'nullable|string|max:1000',
            ]);

            $organization = $this->organizationService->update($id, $data);

            if (isset($data['address'])) {
                $addressData = $data['address'];

                if ($organization->address) {
                    $this->addressService->update($organization->address->id, $addressData);
                } else {
                    $address = $this->addressService->create($addressData);
                    $organization->address()->associate($address);
                    $organization->save();
                }
            }

            return response()->json($organization->load('address'));
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Organization not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while updating the organization'], 500);
        }
    }

    public function destroy(int $id): JsonResponse
    {
        try {
            $user = auth()->user();

            if (!$user->hasRole('admin')) {
                return response()->json(['error' => 'Access denied. Only admins can delete organizations.'], 403);
            }

            $this->organizationService->delete($id);

            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Organization not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while deleting the organization'], 500);
        }
    }
}