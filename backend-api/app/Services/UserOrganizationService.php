<?php

namespace App\Services;

use App\Models\UserOrganization;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class UserOrganizationService
{
    public function getAll(): Collection
    {
        return UserOrganization::all();
    }

    public function getById(int $id): UserOrganization
    {
        return UserOrganization::findOrFail($id);
    }

    public function create(array $data): UserOrganization
    {
        return UserOrganization::create($data);
    }

    public function update(int $id, array $data): UserOrganization
    {
        $userOrganization = UserOrganization::findOrFail($id);
        $userOrganization->update($data);
        return $userOrganization;
    }

    public function delete(int $id): void
    {
        $userOrganization = UserOrganization::findOrFail($id);
        $userOrganization->delete();
    }
}
