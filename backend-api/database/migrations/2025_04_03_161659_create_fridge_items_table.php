<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateFridgeItemsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::dropIfExists('fridge_items');

        Schema::create('fridge_items', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->foreignId('food_id')->constrained('foods')->onDelete('cascade');
            $table->float('quantity', 53);
            $table->foreignId('quantity_unit_id')->constrained('quantity_units')->onDelete('cascade');
            $table->timestamp('expiration_date');
            $table->foreignId('fridge_id')->constrained('fridges')->onDelete('cascade');
            $table->foreignId('added_by_user_id')->constrained('users')->onDelete('cascade');
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('fridge_items');
    }
}
