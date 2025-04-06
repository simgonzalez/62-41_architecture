<?php

namespace Database\Seeders;

use App\Models\Fridge;
use Illuminate\Database\Seeder;

class FridgeSeeder extends Seeder
{
    public function run(): void
    {
        Fridge::factory()->count(10)->create();
    }
}