<?php

namespace App\Http\Controllers;

use App\Models\FridgeItem;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Http;

class MealController extends Controller
{
    private const API_BASE_URL = 'https://www.themealdb.com/api/json/v1/1';
    private const API_URL = self::API_BASE_URL . '/filter.php';
    private const LOOKUP_URL = self::API_BASE_URL . '/lookup.php';

    /**
     * Get all available ingredients.
     */
    public function getAllIngredients()
    {
        try {
            $response = Http::get(self::API_BASE_URL . '/list.php', ['i' => 'list']);
            return response()->json($response->json());
        } catch (\Exception $e) {
            return response()->json(['error' => 'Failed to fetch ingredients'], 500);
        }
    }

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


    public function recommendMeal(Request $request)
    {
        try {
            $user = auth()->user();

            // Fetch the user's fridge items and find the most perishable item
            $mostPerishableItem = FridgeItem::whereHas('fridge', function ($query) use ($user) {
                $query->where('user_id', $user->id);
            })
                ->orderBy('expiration_date', 'asc')
                ->first();

            if (!$mostPerishableItem) {
                return response()->json(['error' => 'No items found in your fridge'], 404);
            }

            $ingredient = $mostPerishableItem->name;

            // Fetch meal recommendations based on the most perishable item
            $response = Http::get(self::API_URL, ['i' => $ingredient]);

            if ($response->failed()) {
                return response()->json(['error' => 'Failed to fetch meal recommendations'], 500);
            }

            return response()->json([
                'ingredient' => $ingredient,
                'meals' => $response->json(),
            ]);
        } catch (\Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching meal recommendations'], 500);
        }
    }
}