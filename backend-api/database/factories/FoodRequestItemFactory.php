<?php

namespace Database\Factories;

use App\Models\FoodRequest;
use App\Models\FoodRequestItem;
use App\Models\Food;
use App\Models\Unit;
use Illuminate\Database\Eloquent\Factories\Factory;

class FoodRequestItemFactory extends Factory
{
    protected $model = FoodRequestItem::class;

    public function definition(): array
    {
        return [
            'request_id' => FoodRequest::factory(),
            'food_id' => Food::factory(),
            'quantity' => $this->faker->randomFloat(2, 1, 100),
            'unit_id' => Unit::factory(),
        ];
    }
}