<?php

namespace App\Http\Controllers;

use App\Models\Unit;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class UnitController extends Controller
{
    public function index(): JsonResponse
    {
        $units = Unit::all();
        return response()->json($units);
    }

    public function show(int $id): JsonResponse
    {
        try {
            $unit = Unit::findOrFail($id);
            return response()->json($unit);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Unit not found'], 404);
        }
    }

    public function store(Request $request): JsonResponse
    {
        $data = $request->validate([
            'name' => 'required|string|max:255',
            'code' => 'required|string|max:50|unique:units,code',
        ]);

        $unit = Unit::create($data);

        return response()->json($unit, 201);
    }

    public function update(Request $request, int $id): JsonResponse
    {
        $data = $request->validate([
            'name' => 'sometimes|required|string|max:255',
            'code' => 'sometimes|required|string|max:50|unique:units,code,' . $id,
        ]);

        try {
            $unit = Unit::findOrFail($id);
            $unit->update($data);

            return response()->json($unit);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Unit not found'], 404);
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
        }
    }
}