<?php

namespace Database\Seeders;

use App\Enums\Status;
use Illuminate\Database\Seeder;

class StatusSeeder extends Seeder
{
    public function run(): void
    {
        foreach (Status::all() as $status) {
            \App\Models\Status::updateOrCreate(['name' => $status]);
        }
    }
}