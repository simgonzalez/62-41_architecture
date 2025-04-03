<?php

namespace App\Services;

use App\Models\Food;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class FoodService
{
    public function getAll(): Collection
    {
        return Food::all();
    }

    public function getById(int $id): Food
    {
        return Food::findOrFail($id);
    }

    public function create(array $data): Food
    {
        return Food::create($data);
    }

    public function update(int $id, array $data): Food
    {
        $food = Food::findOrFail($id);
        $food->update($data);
        return $food;
    }

    public function delete(int $id): void
    {
        $food = Food::findOrFail($id);
        $food->delete();
    }
}
