<?php

namespace App\Http\Controllers;

use App\Models\Unit;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Exception;

class UnitController extends Controller
{
    public function index(): JsonResponse
    {
        try {
            $units = Unit::all();
            return response()->json($units);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching units'], 500);
        }
    }

    public function show(int $id): JsonResponse
    {
        try {
            $unit = Unit::findOrFail($id);
            return response()->json($unit);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Unit not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching the unit'], 500);
        }
    }

    public function store(Request $request): JsonResponse
    {
        $data = $request->validate([
            'name' => 'required|string|max:255',
            'code' => 'required|string|max:50|unique:units,code',
        ]);
        try {
            $unit = Unit::create($data);

            return response()->json($unit, 201);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while creating the unit'], 500);
        }
    }

    public function update(Request $request, int $id): JsonResponse
    {
        try {
            $data = $request->validate([
                'name' => 'sometimes|required|string|max:255',
                'code' => 'sometimes|required|string|max:50|unique:units,code,' . $id,
            ]);

            $unit = Unit::findOrFail($id);
            $unit->update($data);

            return response()->json($unit);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Unit not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while updating the unit'], 500);
        }
    }

    public function destroy(int $id): JsonResponse
    {
        try {
            $unit = Unit::findOrFail($id);
            $unit->delete();

            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Unit not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while deleting the unit'], 500);
        }
    }
}