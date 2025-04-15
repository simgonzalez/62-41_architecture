<?php

use App\Http\Controllers\AuthController;
use App\Http\Controllers\FoodRequestController;
use App\Http\Controllers\FoodRequestItemController;
use App\Http\Controllers\FridgeController;
use App\Http\Controllers\MealController;
use App\Http\Controllers\OrganizationController;
use App\Http\Controllers\RoleController;
use App\Http\Controllers\UnitController;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\FridgeItemController;

Route::post('/register', [AuthController::class, 'register']);
Route::post('/login', [AuthController::class, 'login']);
Route::middleware('auth:sanctum')->post('/logout', [AuthController::class, 'logout']);

Route::middleware('auth:sanctum')->group(function () {
    Route::ApiResource('organizations', OrganizationController::class);
    Route::ApiResource('fridges', FridgeController::class);
    Route::prefix('fridges/{fridge}')->group(function () {
        Route::apiResource('items', FridgeItemController::class);
    });
    Route::apiResource('roles', RoleController::class);
    Route::apiResource('units', UnitController::class);
    Route::apiResource('food-requests', FoodRequestController::class);
    Route::prefix('food-requests/{request}')->group(function () {
        Route::apiResource('items', FoodRequestItemController::class);
    });
    Route::get('/ingredients', [MealController::class, 'getAllIngredients']);
    Route::get('/meals', [MealController::class, 'getMealsByIngredient']);
    Route::get('/meals/{idMeal}', [MealController::class, 'getMealById']);
});