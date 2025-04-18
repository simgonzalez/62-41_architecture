<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Organization extends Model
{
    use HasFactory;

    protected $fillable = ['name', 'description', 'address_id'];

    protected $hidden = ['address_id', 'created_at', 'updated_at'];

    public function address()
    {
        return $this->belongsTo(Address::class);
    }
    public function users()
    {
        return $this->belongsToMany(User::class, 'organization_user');
    }
}
