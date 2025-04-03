<?php

namespace App\Services;

use App\Models\Organization;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class OrganizationService
{
    public function getAll(): Collection
    {
        return Organization::all();
    }

    public function getById(int $id): Organization
    {
        return Organization::findOrFail($id);
    }

    public function create(array $data): Organization
    {
        return Organization::create($data);
    }

    public function update(int $id, array $data): Organization
    {
        $organization = Organization::findOrFail($id);
        $organization->update($data);
        return $organization;
    }

    public function delete(int $id): void
    {
        $organization = Organization::findOrFail($id);
        $organization->delete();
    }
}
