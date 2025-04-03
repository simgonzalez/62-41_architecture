<?php namespace App\Services;

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
}
