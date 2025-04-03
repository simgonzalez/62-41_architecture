<?php

namespace Database\Seeders;

use App\Models\Organization;
use App\Models\Address;
use Illuminate\Database\Seeder;

class OrganizationSeeder extends Seeder
{
    public function run(): void
    {
        // Create 10 organizations, each with one address
        Organization::factory()
            ->count(10)
            ->create()
            ->each(function ($organization) {
                Address::factory()->create([
                    'organization_id' => $organization->id,
                ]);
            });
    }
}