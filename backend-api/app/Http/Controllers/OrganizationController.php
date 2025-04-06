<?php

namespace App\Http\Controllers;

use App\Services\OrganizationService;
use App\Services\AddressService;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;

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
        $organizations = $this->organizationService->getAll();
        return response()->json($organizations);
    }

    public function show(int $id): JsonResponse
    {
        try {
            $organization = $this->organizationService->getById($id);
            return response()->json($organization);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Organization not found'], 404);
        }
    }

    public function store(Request $request): JsonResponse
    {
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

        return response()->json($organization->load('address'), 201);
    }

    public function update(Request $request, int $id): JsonResponse
{
    $data = $request->validate([
        'name' => 'sometimes|required|string|max:255',
        'description' => 'nullable|string|max:2000',
        'address' => 'sometimes|required|array',
        'address.street_name' => 'sometimes|required|string|max:2000',
        'address.street_number' => 'nullable|string|max:20',
        'address.npa' => 'nullable|string|max:10',
        'address.city' => 'nullable|string|max:1000',
    ]);

    try {
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
    }
}

    public function destroy(int $id): JsonResponse
    {
        try {
            $this->organizationService->delete($id);
            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Organization not found'], 404);
        }
    }
}
