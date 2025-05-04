<?php

namespace App\Http\Controllers;

use Illuminate\Http\JsonResponse;
use App\Models\Food;

class FoodController extends Controller
{
    /**
     * Display a list of foods.
     */
    public function index(): JsonResponse
    {
        try {
            $foods = Food::all(['id', 'name']);
            return response()->json($foods);
        } catch (\Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching the list of foods'], 500);
        }
    }
}