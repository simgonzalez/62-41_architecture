<?php

namespace App\Http\Controllers;

use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Exception;

class UserController extends Controller
{
    public function index(): JsonResponse
    {
        try {
            $users = User::all();
            return response()->json($users);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching users'], 500);
        }
    }

    public function show(int $id): JsonResponse
    {
        try {
            $user = User::findOrFail($id);
            return response()->json($user);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'User not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching the user'], 500);
        }
    }

    public function store(Request $request): JsonResponse
    {
        try {
            $data = $request->validate([
                'name' => 'required|string|max:255',
                'email' => 'required|string|email|max:255|unique:users',
                'password' => 'required|string|min:8',
                'role' => 'required|string|in:admin,user', // Ensure valid roles
            ]);

            $data['password'] = bcrypt($data['password']); // Hash the password

            $user = User::create($data);
            $user->assignRole($data['role']); // Assign the role using Spatie

            return response()->json($user, 201);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while creating the user'], 500);
        }
    }

    public function update(Request $request, int $id): JsonResponse
    {
        try {
            $data = $request->validate([
                'name' => 'sometimes|required|string|max:255',
                'email' => 'sometimes|required|string|email|max:255|unique:users,email,' . $id,
                'password' => 'sometimes|required|string|min:8',
                'role' => 'sometimes|required|string|in:admin,user', // Ensure valid roles
            ]);

            if (isset($data['password'])) {
                $data['password'] = bcrypt($data['password']); // Hash the password
            }

            $user = User::findOrFail($id);
            $user->update($data);

            if (isset($data['role'])) {
                $user->syncRoles([$data['role']]); // Update the role using Spatie
            }

            return response()->json($user);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'User not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while updating the user'], 500);
        }
    }

    public function destroy(int $id): JsonResponse
    {
        try {
            $user = User::findOrFail($id);
            $user->delete();

            return response()->json(null, 204);
        } catch (ModelNotFoundException $e) {
            return response()->json(['error' => 'User not found'], 404);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while deleting the user'], 500);
        }
    }

    public function listForOrganization(): JsonResponse
    {
        try {
            $users = User::select('id', 'first_name', 'name', 'email')->get();

            return response()->json($users);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching users for the organization'], 500);
        }
    }
}