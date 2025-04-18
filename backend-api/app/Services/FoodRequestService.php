<?php

namespace App\Services;

use App\Models\FoodRequest;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class FoodRequestService
{
    public function getAll(): Collection
    {
        return FoodRequest::all();
    }

    public function getById(int $id): FoodRequest
    {
        return FoodRequest::findOrFail($id);
    }

    public function create(array $data): FoodRequest
    {
        return FoodRequest::create($data);
    }

    public function update(int $id, array $data): FoodRequest
    {
        $foodRequest = FoodRequest::findOrFail($id);
        $foodRequest->update($data);
        return $foodRequest;
    }

    public function delete(int $id): void
    {
        $foodRequest = FoodRequest::findOrFail($id);
        $foodRequest->delete();
    }
    
    public function getAllByUserOrganizations(int $userId)
    {
        return FoodRequest::whereHas('organization.users', function ($query) use ($userId) {
            $query->where('users.id', $userId);
        })->get();
    }

    public function getByIdAndUserOrganizations(int $id, int $userId)
    {
        return FoodRequest::where('id', $id)
            ->whereHas('organization.users', function ($query) use ($userId) {
                $query->where('users.id', $userId);
            })->first();
    }
}
