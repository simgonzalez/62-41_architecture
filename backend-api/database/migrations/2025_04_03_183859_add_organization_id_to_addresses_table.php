<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class AddOrganizationIdToAddressesTable extends Migration
{
    public function up(): void
    {
        Schema::table('addresses', function (Blueprint $table) {
            $table->foreignId('organization_id')->nullable()->constrained()->onDelete('cascade');
        });
    }

    public function down(): void
    {
        Schema::table('addresses', function (Blueprint $table) {
            $table->dropForeign(['organization_id']);
            $table->dropColumn('organization_id');
        });
    }
}