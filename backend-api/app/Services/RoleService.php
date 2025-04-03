<?php

namespace App\Services;

use App\Models\Role;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class RoleService
{
    public function getAll(): Collection
    {
        return Role::all();
    }

    public function getById(int $id): Role
    {
        return Role::findOrFail($id);
    }

    public function create(array $data): Role
    {
        return Role::create($data);
    }

    public function update(int $id, array $data): Role
    {
        $role = Role::findOrFail($id);
        $role->update($data);
        return $role;
    }

    public function delete(int $id): void
    {
        $role = Role::findOrFail($id);
        $role->delete();
    }
}
