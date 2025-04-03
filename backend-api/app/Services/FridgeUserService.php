<?php

namespace App\Services;

use App\Models\FridgeUser;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class FridgeUserService
{
    public function getAll(): Collection
    {
        return FridgeUser::all();
    }

    public function getById(int $id): FridgeUser
    {
        return FridgeUser::findOrFail($id);
    }

    public function create(array $data): FridgeUser
    {
        return FridgeUser::create($data);
    }

    public function update(int $id, array $data): FridgeUser
    {
        $fridgeUser = FridgeUser::findOrFail($id);
        $fridgeUser->update($data);
        return $fridgeUser;
    }

    public function delete(int $id): void
    {
        $fridgeUser = FridgeUser::findOrFail($id);
        $fridgeUser->delete();
    }
}
