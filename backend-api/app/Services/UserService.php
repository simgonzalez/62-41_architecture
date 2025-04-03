<?php

namespace App\Services;

use App\Models\User;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class UserService
{
    public function getAll(): Collection
    {
        return User::all();
    }

    public function getById(int $id): User
    {
        return User::findOrFail($id);
    }

    public function create(array $data): User
    {
        return User::create($data);
    }

    public function update(int $id, array $data): User
    {
        $user = User::findOrFail($id);
        $user->update($data);
        return $user;
    }

    public function delete(int $id): void
    {
        $user = User::findOrFail($id);
        $user->delete();
    }
}
