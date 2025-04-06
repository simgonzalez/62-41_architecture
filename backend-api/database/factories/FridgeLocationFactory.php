<?php

namespace Database\Factories;

use App\Models\FridgeLocation;
use Illuminate\Database\Eloquent\Factories\Factory;

class FridgeLocationFactory extends Factory
{
    protected $model = FridgeLocation::class;

    public function definition(): array
    {
        return [
            'name' => $this->faker->city . ' Location',
        ];
    }
}