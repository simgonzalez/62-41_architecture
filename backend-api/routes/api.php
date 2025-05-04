<?php

use App\Http\Controllers\AuthController;
use App\Http\Controllers\FoodController;
use App\Http\Controllers\FoodRequestController;
use App\Http\Controllers\FoodRequestItemController;
use App\Http\Controllers\FridgeController;
use App\Http\Controllers\MealController;
use App\Http\Controllers\OrganizationController;
use App\Http\Controllers\UnitController;
use App\Http\Controllers\UserController;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\FridgeItemController;

Route::post('/register', [AuthController::class, 'register']);
Route::post('/login', [AuthController::class, 'login']);

Route::middleware('auth:sanctum')->group(function () {
    Route::post('/logout', [AuthController::class, 'logout']);
    Route::get('/me', [UserController::class, 'getProfile']);

    Route::middleware('can:admin')->group(function () {
        Route::apiResource('units', UnitController::class);
        Route::apiResource('users', UserController::class);
        Route::get('/roles', [UserController::class, 'getRoles']);
    });

    Route::middleware('can:user')->group(function () {
        Route::get('/me/organization', [UserController::class, 'getOrganization']);
        Route::get('/users-org', [UserController::class, 'listForOrganization']);
        Route::apiResource('organizations', OrganizationController::class);

        Route::get('/organizations/{id}/users', [OrganizationController::class, 'getUsers']);
        Route::post('/organizations/{id}/users', [OrganizationController::class, 'addUser']);
        Route::delete('/organizations/{id}/users/{user_id}', [OrganizationController::class, 'removeUser']);
        
        Route::apiResource('fridges', FridgeController::class);
        Route::prefix('fridges/{fridge}')->group(function () {
            Route::apiResource('items', FridgeItemController::class);
        });
        Route::apiResource('food-requests', FoodRequestController::class);
        Route::prefix('food-requests/{request}')->group(function () {
            Route::apiResource('items', FoodRequestItemController::class);
        });
        Route::get('/ingredients', [MealController::class, 'getAllIngredients']);
        Route::get('/meals', [MealController::class, 'getMealsByIngredient']);
        Route::get('/meals/recommend', [MealController::class, 'recommendMeal']);
        Route::get('/meals/{idMeal}', [MealController::class, 'getMealById']);

        Route::get('/foods', [FoodController::class, 'index']);

        Route::get('/units', [UnitController::class, 'index']);
    });
});