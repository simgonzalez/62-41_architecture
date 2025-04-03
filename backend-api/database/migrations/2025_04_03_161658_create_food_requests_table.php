<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::create('food_requests', function (Blueprint $table) {
            $table->id();
            $table->string('name', 1000);
            $table->foreignId('organization_id')->constrained();
            $table->text('description')->nullable();
            $table->timestamp('deadline_date');
            $table->foreignId('responsible_user_id')->constrained('users');
            $table->foreignId('created_by_user_id')->constrained('users');
            $table->foreignId('status_id')->constrained('status');
            $table->index('deadline_date', 'idx_food_request_deadline');
            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('food_requests');
    }
};
