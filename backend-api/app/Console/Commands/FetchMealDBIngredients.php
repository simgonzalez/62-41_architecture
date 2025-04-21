<?php

namespace App\Console\Commands;

use Illuminate\Console\Command;
use Illuminate\Support\Facades\Http;
use Illuminate\Support\Facades\Storage;

class FetchMealDBIngredients extends Command
{
    protected $signature = 'fetch:mealdb-ingredients';
    protected $description = 'Fetch ingredients from MealDB and store them locally';

    public function handle()
    {
        $this->info('Fetching ingredients from MealDB...');
        $response = Http::get('https://www.themealdb.com/api/json/v1/1/list.php?i=list');

        if ($response->failed()) {
            $this->error('Failed to fetch ingredients from MealDB.');
            return 1;
        }

        $ingredients = $response->json()['meals'] ?? [];
        $ingredientNames = array_map(fn($meal) => $meal['strIngredient'], $ingredients);

        Storage::disk('local')->put('mealdb_ingredients.json', json_encode($ingredientNames, JSON_PRETTY_PRINT));
        $this->info('Ingredients fetched and stored successfully.');

        return 0;
    }
}