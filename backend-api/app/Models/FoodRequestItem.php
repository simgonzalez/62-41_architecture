<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class FoodRequestItem extends Model
{
    use HasFactory;

    protected $fillable = [
        'request_id',
        'food_id',
        'quantity',
        'unit_id',
    ];

    protected $hidden = [
        'created_at', 'updated_at'
    ];

    public function foodRequest()
    {
        return $this->belongsTo(FoodRequest::class, 'request_id');
    }

    public function food()
    {
        return $this->belongsTo(Food::class, 'food_id');
    }

    public function unit()
    {
        return $this->belongsTo(Unit::class, 'unit_id');
    }
}
