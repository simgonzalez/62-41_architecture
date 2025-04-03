<?php

namespace App\Services;

use App\Models\FridgeLocation;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class FridgeLocationService
{
    public function getAll(): Collection
    {
        return FridgeLocation::all();
    }

    public function getById(int $id): FridgeLocation
    {
        return FridgeLocation::findOrFail($id);
    }

    public function create(array $data): FridgeLocation
    {
        return FridgeLocation::create($data);
    }

    public function update(int $id, array $data): FridgeLocation
    {
        $fridgeLocation = FridgeLocation::findOrFail($id);
        $fridgeLocation->update($data);
        return $fridgeLocation;
    }

    public function delete(int $id): void
    {
        $fridgeLocation = FridgeLocation::findOrFail($id);
        $fridgeLocation->delete();
    }
}
