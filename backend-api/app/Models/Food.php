<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Food extends Model
{
    use HasFactory;

    protected $fillable = ['name', 'ingredient_open_meal_db_name'];

    protected $hidden = [
        'created_at', 'updated_at'
    ];

    protected $table = 'foods';
}
