<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::create('foods', function (Blueprint $table) {
            $table->id();
            $table->string('name', 1000);
            $table->string('ingredient_open_meal_db_name', 1000)->nullable();
            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('foods');
    }
};
