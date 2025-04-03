<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Address extends Model
{
    use HasFactory;

    protected $fillable = ['organization_id', 'street_name', 'street_number', 'npa', 'city'];

    /**
     * Define a belongs-to relationship with Organization.
     */
    public function organization()
    {
        return $this->belongsTo(Organization::class);
    }
}