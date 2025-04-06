<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Http;

class MealController extends Controller
{
    private const API_BASE_URL = 'https://www.themealdb.com/api/json/v1/1';
    private const API_URL = self::API_BASE_URL . '/filter.php';
    private const LOOKUP_URL = self::API_BASE_URL . '/lookup.php';

    /**
     * Get meals by ingredient.
     */
    public function getMealsByIngredient(Request $request)
    {
        $ingredient = $request->query('ingredient');

        if (!$ingredient) {
            return response()->json(['error' => 'Ingredient is required'], 400);
        }

        try {
            $response = Http::get(self::API_URL, ['i' => $ingredient]);
            return response()->json($response->json());
        } catch (\Exception $e) {
            return response()->json(['error' => 'Failed to fetch meals'], 500);
        }
    }

    /**
     * Get meal by ID.
     */
    public function getMealById(Request $request, $idMeal)
    {
        try {
            $response = Http::get(self::LOOKUP_URL, ['i' => $idMeal]);
            return response()->json($response->json());
        } catch (\Exception $e) {
            return response()->json(['error' => 'Failed to fetch meal'], 500);
        }
    }
}