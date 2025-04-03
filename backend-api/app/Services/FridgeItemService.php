<?php

namespace App\Services;

use App\Models\FridgeItem;

class FridgeItemService
{
    public function create(array $data)
    {
        return FridgeItem::create($data);
    }

    public function update(FridgeItem $fridgeItem, array $data)
    {
        $fridgeItem->update($data);
        return $fridgeItem;
    }

    public function delete(FridgeItem $fridgeItem)
    {
        $fridgeItem->delete();
    }
}
