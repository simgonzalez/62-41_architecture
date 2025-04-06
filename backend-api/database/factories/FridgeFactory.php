<?php

namespace Database\Factories;

use App\Models\FridgeLocation;
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Fridge>
 */
class FridgeFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [
            'name' => $this->faker->word . ' Fridge',
            'location_id' => FridgeLocation::factory()
        ];
    }
}
