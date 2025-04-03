<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class FridgeItem extends Model
{
    use HasFactory;

    protected $fillable = [
        'food_id',
        'quantity',
        'quantity_unit_id',
        'expiration_date',
        'fridge_id',
        'added_by_user_id',
    ];

    public function food()
    {
        return $this->belongsTo(Food::class, 'food_id');
    }

    public function quantityUnit()
    {
        return $this->belongsTo(QuantityUnit::class, 'quantity_unit_id');
    }

    public function fridge()
    {
        return $this->belongsTo(Fridge::class, 'fridge_id');
    }

    public function user()
    {
        return $this->belongsTo(User::class, 'added_by_user_id');
    }
}
