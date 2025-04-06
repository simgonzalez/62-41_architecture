<?php

namespace Database\Factories;

use App\Models\Food;
use Illuminate\Database\Eloquent\Factories\Factory;

class FoodFactory extends Factory
{
    protected $model = Food::class;

    public function definition(): array
    {
        $fakeName = $this->faker->word;
        return [
            'name' => $fakeName,
            'ingredient_open_meal_db_name' => $fakeName,
        ];
    }
}