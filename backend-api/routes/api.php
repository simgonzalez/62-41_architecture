<?php

use App\Http\Controllers\FridgeController;
use App\Http\Controllers\OrganizationController;
use App\Http\Controllers\RoleController;
use App\Http\Controllers\UnitController;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\FridgeItemController;

Route::ApiResource('organizations', OrganizationController::class);
Route::ApiResource('fridges', FridgeController::class);
Route::prefix('fridges/{fridge}')->group(function () {
    Route::apiResource('items', FridgeItemController::class);
});
Route::apiResource('roles', RoleController::class);
Route::apiResource('units', UnitController::class);