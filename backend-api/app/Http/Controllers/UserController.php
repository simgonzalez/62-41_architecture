<?php

namespace App\Http\Controllers;

use App\Models\User;
use Auth;
use Illuminate\Http\Request;
use Illuminate\Http\JsonResponse;
use Illuminate\Database\Eloquent\ModelNotFoundException;
use Exception;
use Spatie\Permission\Models\Role;

class UserController extends Controller
{

    public function index(Request $request): JsonResponse
    {
        try {
            $query = User::with('roles');

            if ($request->has('name')) {
                $query->where('name', 'like', '%' . $request->input('name') . '%');
            }

            if ($request->has('email')) {
                $query->where('email', 'like', '%' . $request->input('email') . '%');
            }

            if ($request->has('first_name')) {
                $query->where('first_name', 'like', '%' . $request->input('first_name') . '%');
            }

            $users = $query->get()->map(function ($user) {
                return [
                    'id' => $user->id,
                    'name' => $user->name,
                    'email' => $user->email,
                    'first_name' => $user->first_name,
                    'roles' => $user->roles->pluck('name'), // Include role names
                ];
            });

            return response()->json($users);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching users'], 500);
        }
    }


    public function show(int $id): JsonResponse
    {
        try {
            $user = User::with('roles')->findOrFail($id);

            $response = [
                'id' => $user->id,
                'name' => $user->name,
                'email' => $user->email,
                'first_name' => $user->first_name,
                'roles' => $user->roles->pluck('name'),
            ];

            return response()->json($response);
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
                'first_name' => 'required|string|max:255',
                'email' => 'required|string|email|max:255|unique:users',
                'password' => 'required|string|min:8',
                'role' => 'required|string|in:admin,user',
            ]);

            $data['password'] = bcrypt($data['password']);

            $user = User::create($data);
            $user->assignRole($data['role']);

            $response = [
                'id' => $user->id,
                'name' => $user->name,
                'email' => $user->email,
                'first_name' => $user->first_name,
                'roles' => $user->roles->pluck('name'),
            ];

            return response()->json($response, 201);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while creating the user'], 500);
        }
    }


    public function update(Request $request, int $id): JsonResponse
    {
        try {
            $data = $request->validate([
                'name' => 'sometimes|required|string|max:255',
                'first_name' => 'sometimes|required|string|max:255',
                'email' => 'sometimes|required|string|email|max:255|unique:users,email,' . $id,
                'password' => 'sometimes|required|string|min:8',
                'role' => 'sometimes|required|string|in:admin,user',
            ]);

            if (isset($data['password'])) {
                $data['password'] = bcrypt($data['password']);
            }

            $user = User::findOrFail($id);
            $user->update($data);

            if (isset($data['role'])) {
                $user->syncRoles([$data['role']]);
            }

            $response = [
                'id' => $user->id,
                'name' => $user->name,
                'email' => $user->email,
                'first_name' => $user->first_name,
                'roles' => $user->roles->pluck('name'),
            ];

            return response()->json($response);
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

    public function getProfile(): JsonResponse
    {
        try {
            $user = Auth::user();

            $response = [
                'id' => $user->id,
                'name' => $user->name,
                'email' => $user->email,
                'first_name' => $user->first_name,
                'email_verified_at' => $user->email_verified_at,
                'roles' => $user->roles->pluck('name'),
            ];

            return response()->json($response);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching the user profile'], 500);
        }

    }

    public function getRoles(): JsonResponse
    {
        try {
            // Fetch all roles
            $roles = Role::all()->pluck('name');

            return response()->json($roles);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while fetching roles'], 500);
        }
    }
    public function getOrganization(): JsonResponse
    {
        try {
            $user = auth()->user();

            // Ensure the user belongs to an organization
            if ($user->organizations->isEmpty()) {
                return response()->json(['error' => 'User does not belong to any organization'], 404);
            }

            // Retrieve the first organization of the user with its address
            $organization = $user->organizations()->with('address')->first();

            return response()->json([
                'id' => $organization->id,
                'name' => $organization->name,
                'description' => $organization->description,
                'address' => [
                    'street_name' => $organization->address->street_name ?? null,
                    'street_number' => $organization->address->street_number ?? null,
                    'npa' => $organization->address->npa ?? null,
                    'city' => $organization->address->city ?? null,
                ],
                'created_at' => $organization->created_at,
                'updated_at' => $organization->updated_at,
            ]);
        } catch (Exception $e) {
            return response()->json(['error' => 'An error occurred while retrieving the organization'], 500);
        }
    }
}