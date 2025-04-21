<?php

namespace Database\Factories;

use App\Models\Food;
use Illuminate\Database\Eloquent\Factories\Factory;
use Illuminate\Support\Facades\Storage;

class FoodFactory extends Factory
{
    protected $model = Food::class;

    public function definition(): array
    {
        $ingredients = json_decode(Storage::disk('local')->get('mealdb_ingredients.json'), true);

        $ingredient = $this->faker->randomElement($ingredients);

        return [
            'name' => $ingredient,
            'ingredient_open_meal_db_name' => $ingredient,
        ];
    }
}
