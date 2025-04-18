<?php

namespace App\Services;

use App\Models\Organization;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class OrganizationService
{
    public function getAll(): Collection
    {
        return Organization::with('address')->get();
    }

    public function getById(int $id): Organization
    {
        return Organization::with('address')->findOrFail($id);
    }

    public function create(array $data): Organization
    {
        $organization = Organization::create($data);

        $organization->load('address');

        return $organization;
    }

    public function update(int $id, array $data): Organization
    {
        $organization = Organization::findOrFail($id);
        $organization->update($data);

        $organization->load('address');

        return $organization;
    }

    public function delete(int $id): void
    {
        $organization = Organization::findOrFail($id);
        $organization->delete();
    }

    public function getAllByUser(int $userId)
    {
        return Organization::where('user_id', $userId)->get();
    }

    public function getByIdAndUser(int $id, int $userId)
    {
        return Organization::where('id', $id)->where('user_id', $userId)->first();
    }
}
