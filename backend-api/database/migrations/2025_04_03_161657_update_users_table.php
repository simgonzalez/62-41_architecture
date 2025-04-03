<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('users', function (Blueprint $table) {
            $table->string('first_name', 500)->after('email');
            $table->foreignId('role_id')->constrained();
            $table->renameColumn('password', 'password_hash');
        });
    }

    public function down(): void
    {
        Schema::table('users', function (Blueprint $table) {
            $table->dropColumn(['first_name', 'role_id']);
            $table->renameColumn('password_hash', 'password');
        });
    }
};
