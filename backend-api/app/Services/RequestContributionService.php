<?php

namespace App\Services;

use App\Models\RequestContribution;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class RequestContributionService
{
    public function getAll(): Collection
    {
        return RequestContribution::all();
    }

    public function getById(int $id): RequestContribution
    {
        return RequestContribution::findOrFail($id);
    }

    public function create(array $data): RequestContribution
    {
        return RequestContribution::create($data);
    }

    public function update(int $id, array $data): RequestContribution
    {
        $requestContribution = RequestContribution::findOrFail($id);
        $requestContribution->update($data);
        return $requestContribution;
    }

    public function delete(int $id): void
    {
        $requestContribution = RequestContribution::findOrFail($id);
        $requestContribution->delete();
    }
}
