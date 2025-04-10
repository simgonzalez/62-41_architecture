<?php

namespace App\Http\Controllers;

use App\Services\RoleService;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Exception;

class RoleController extends Controller
{
    protected RoleService $roleService;

    public function __construct(RoleService $roleService)
    {
        $this->roleService = $roleService;
    }

    public function index(): JsonResponse
    {
        try {
            $roles = $this->roleService->getAll();
            return response()->json($roles);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching roles'], 500);
        }
    }

    public function show(int $id): JsonResponse
    {
        try {
            $role = $this->roleService->getById($id);
            return response()->json($role);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Role not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching the role'], 500);
        }
    }

    public function store(Request $request): JsonResponse
    {
        try {
            $data = $request->validate([
                'name' => 'required|string|max:255',
                'description' => 'nullable|string|max:1000',
                'code' => 'required|string|max:50|unique:roles,code',
            ]);

            $role = $this->roleService->create($data);

            return response()->json($role, 201);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while creating the role'], 500);
        }
    }

    public function update(Request $request, int $id): JsonResponse
    {
        try {
            $data = $request->validate([
                'name' => 'sometimes|required|string|max:255',
                'description' => 'nullable|string|max:1000',
                'code' => 'sometimes|required|string|max:50|unique:roles,code,' . $id,
            ]);

            $role = $this->roleService->update($id, $data);
            return response()->json($role);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Role not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while updating the role'], 500);
        }
    }

    public function destroy(int $id): JsonResponse
    {
        try {
            $this->roleService->delete($id);
            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'Role not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while deleting the role'], 500);
        }
    }
}