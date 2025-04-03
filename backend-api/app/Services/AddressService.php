<?php

namespace App\Services;

use App\Models\Address;
use Illuminate\Database\Eloquent\Collection;
use Illuminate\Database\Eloquent\ModelNotFoundException;

class AddressService
{
    /**
     * Get all addresses.
     *
     * @return Collection
     */
    public function getAll(): Collection
    {
        return Address::all();
    }

    /**
     * Get an address by ID.
     *
     * @param int $id
     * @return Address
     * @throws ModelNotFoundException
     */
    public function getById(int $id): Address
    {
        return Address::findOrFail($id);
    }

    /**
     * Create a new address.
     *
     * @param array $data
     * @return Address
     */
    public function create(array $data): Address
    {
        return Address::create($data);
    }

    /**
     * Update an existing address.
     *
     * @param int $id
     * @param array $data
     * @return Address
     * @throws ModelNotFoundException
     */
    public function update(int $id, array $data): Address
    {
        $address = Address::findOrFail($id);
        $address->update($data);
        return $address;
    }

    /**
     * Delete an address by ID.
     *
     * @param int $id
     * @return void
     * @throws ModelNotFoundException
     */
    public function delete(int $id): void
    {
        $address = Address::findOrFail($id);
        $address->delete();
    }
}
