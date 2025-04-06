<?php

namespace Database\Seeders;

use App\Models\FoodRequestItem;
use Illuminate\Database\Seeder;

class FoodRequestItemSeeder extends Seeder
{
    public function run(): void
    {
        FoodRequestItem::factory()->count(50)->create();
    }
}