<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Relations\Pivot;

class FridgeUser extends Pivot
{
    use HasFactory;

    protected $hidden = [
        'created_at', 'updated_at'
    ];

    protected $table = 'fridge_user';
}
