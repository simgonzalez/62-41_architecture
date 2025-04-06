<?php

namespace Database\Factories;

use App\Models\FoodRequest;
use App\Models\Organization;
use App\Models\Status;
use App\Models\User;
use Illuminate\Database\Eloquent\Factories\Factory;

class FoodRequestFactory extends Factory
{
    protected $model = FoodRequest::class;

    public function definition(): array
    {
        return [
            'name' => $this->faker->sentence(3),
            'organization_id' => Organization::factory(),
            'description' => $this->faker->optional()->paragraph,
            'deadline_date' => $this->faker->dateTimeBetween('now', '+1 month'),
            'responsible_user_id' => User::factory(),
            'created_by_user_id' => User::factory(),
            'status_id' => Status::inRandomOrder()->first()->id,
        ];
    }
}