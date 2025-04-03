<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class FoodRequest extends Model
{
    use HasFactory;

    protected $fillable = [
        'name', 'organization_id', 'description', 'deadline_date',
        'responsible_user_id', 'created_by_user_id', 'status_id'
    ];

    public function organization()
    {
        return $this->belongsTo(Organization::class);
    }

    public function responsibleUser()
    {
        return $this->belongsTo(User::class, 'responsible_user_id');
    }

    public function createdByUser()
    {
        return $this->belongsTo(User::class, 'created_by_user_id');
    }

    public function status()
    {
        return $this->belongsTo(Status::class);
    }
}
