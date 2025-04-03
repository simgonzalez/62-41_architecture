<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class RequestContribution extends Model
{
    use HasFactory;

    protected $fillable = [
        'user_id', 'request_id', 'contribution_date', 'quantity', 'quantity_unit_id'
    ];

    public function user()
    {
        return $this->belongsTo(User::class);
    }

    public function request()
    {
        return $this->belongsTo(FoodRequest::class);
    }

    public function quantityUnit()
    {
        return $this->belongsTo(Unit::class, 'quantity_unit_id');
    }
}
