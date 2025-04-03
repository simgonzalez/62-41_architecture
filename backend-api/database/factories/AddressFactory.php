<?php

namespace Database\Factories;

use App\Models\Address;
use App\Models\Organization;
use Illuminate\Database\Eloquent\Factories\Factory;

class AddressFactory extends Factory
{
    protected $model = Address::class;

    public function definition(): array
    {
        return [
            'organization_id' => Organization::factory(),
            'street_name' => $this->faker->streetName(),
            'street_number' => $this->faker->buildingNumber(),
            'npa' => $this->faker->postcode(),
            'city' => $this->faker->city(),
        ];
    }
}