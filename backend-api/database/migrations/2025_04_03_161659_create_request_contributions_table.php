<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::create('request_contributions', function (Blueprint $table) {
            $table->id();
            $table->foreignId('user_id')->constrained('users');
            $table->foreignId('request_id')->constrained('food_requests')->onDelete('cascade');
            $table->timestamp('contribution_date')->default(DB::raw('CURRENT_TIMESTAMP'));
            $table->float('quantity');
            $table->foreignId('quantity_unit_id')->constrained('units');
            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('request_contributions');
    }
};
