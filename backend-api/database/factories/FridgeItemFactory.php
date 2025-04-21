<?php

namespace Database\Factories;

use App\Models\Fridge;
use App\Models\FridgeItem;
use App\Models\Food;
use App\Models\Unit;
use App\Models\User;
use Illuminate\Database\Eloquent\Factories\Factory;

class FridgeItemFactory extends Factory
{
    protected $model = FridgeItem::class;

    public function definition(): array
    {
        return [
            'food_id' => Food::factory(),
            'quantity' => $this->faker->randomFloat(2, 0.1, 100),
            'unit_id' => Unit::factory(),
            'expiration_date' => $this->faker->dateTimeBetween('now', '+1 year'), // Removed optional()
            'fridge_id' => Fridge::factory(),
            'added_by_user_id' => User::factory(),
        ];
    }
}