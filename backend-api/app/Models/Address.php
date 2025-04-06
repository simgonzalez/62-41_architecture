<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Address extends Model
{
    use HasFactory;

    protected $fillable = ['street_name', 'street_number', 'npa', 'city'];

    public function organizations()
    {
        return $this->hasMany(Organization::class);
    }
}