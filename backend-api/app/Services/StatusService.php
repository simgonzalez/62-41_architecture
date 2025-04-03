<?php

namespace App\Services;

use App\Models\Status;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class StatusService
{
    public function getAll(): Collection
    {
        return Status::all();
    }

    public function getById(int $id): Status
    {
        return Status::findOrFail($id);
    }

    public function create(array $data): Status
    {
        return Status::create($data);
    }

    public function update(int $id, array $data): Status
    {
        $status = Status::findOrFail($id);
        $status->update($data);
        return $status;
    }

    public function delete(int $id): void
    {
        $status = Status::findOrFail($id);
        $status->delete();
    }
}
