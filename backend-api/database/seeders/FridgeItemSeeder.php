<?php

namespace Database\Seeders;

use App\Models\FridgeItem;
use Illuminate\Database\Seeder;

class FridgeItemSeeder extends Seeder
{
    public function run(): void
    {
        FridgeItem::factory()->count(20)->create();
    }
}