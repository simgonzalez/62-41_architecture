<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Fridge extends Model
{
    use HasFactory;

    protected $fillable = ['name', 'location_id'];

    protected $hidden = ['location_id', 'created_at', 'updated_at'];

    public function location()
    {
        return $this->belongsTo(FridgeLocation::class);
    }

    public function user()
    {
        return $this->belongsTo(User::class);
    }

    public function items()
    {
        return $this->hasMany(FridgeItem::class);
    }
}
