<?php
namespace App\Services;

use App\Models\FoodRequest;
use App\Models\FoodRequestItem;

class FoodRequestItemService
{
    public function create(array $data)
    {
        return FoodRequestItem::create($data);
    }

    public function update(FoodRequestItem $foodRequestItem, array $data)
    {
        $foodRequestItem->update($data);
        return $foodRequestItem;
    }

    public function delete(FoodRequestItem $foodRequestItem)
    {
        $foodRequestItem->delete();
    }

    public function userHasAccessToRequest(int $userId, int $requestId): bool
    {
        return FoodRequest::where('id', $requestId)
            ->whereHas('organization.users', function ($query) use ($userId) {
                $query->where('users.id', $userId);
            })
            ->exists();
    }
}
