<?php

namespace Database\Seeders;

use App\Models\User;
use Illuminate\Database\Seeder;
use Spatie\Permission\Models\Permission;
use Spatie\Permission\Models\Role;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        $this->call([
            StatusSeeder::class,
            OrganizationSeeder::class,
            FridgeSeeder::class,
            FridgeItemSeeder::class,
            FoodRequestSeeder::class,
            FoodRequestItemSeeder::class,
        ]);

        $permUser = Permission::create(attributes: ['name' => 'user']);
        $permAdmin = Permission::create(['name' => 'admin']);

        // Create roles and assign permissions
        $roleAdmin = Role::create(['name' => 'admin']);
        $roleAdmin->syncPermissions([$permUser, $permAdmin]);

        $roleUser = Role::create(['name' => 'user']);
        $roleUser->syncPermissions([$permUser]);

        $admin = User::factory()->create([
            'first_name' => 'Admin',
            'name' => 'Admin',
            'email' => 'admin@example.com',
            'password' => bcrypt('password'),
        ]);
        $admin->assignRole($roleAdmin);
    }
}