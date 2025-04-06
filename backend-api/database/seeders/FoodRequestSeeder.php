<?php

namespace Database\Seeders;

use App\Models\FoodRequest;
use Illuminate\Database\Seeder;

class FoodRequestSeeder extends Seeder
{
    public function run(): void
    {
        FoodRequest::factory()->count(10)->create();
    }
}