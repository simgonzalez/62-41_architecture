<?php

namespace App\Services;

use App\Models\Fridge;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class FridgeService
{
    public function getAll(): Collection
{
    return Fridge::with('location')->get(); 
}

public function getById(int $id): Fridge
{
    return Fridge::with('location')->findOrFail($id); 
}

    public function create(array $data): Fridge
    {
        return Fridge::create($data);
    }

    public function update(int $id, array $data): Fridge
    {
        $fridge = Fridge::findOrFail($id);
        $fridge->update($data);
        return $fridge;
    }

    public function delete(int $id): void
    {
        $fridge = Fridge::findOrFail($id);
        $fridge->delete();
    }
}
