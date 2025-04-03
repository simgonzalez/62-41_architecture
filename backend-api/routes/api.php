<?php

use App\Http\Controllers\OrganizationController;
use Illuminate\Support\Facades\Route;

Route::ApiResource('organizations', OrganizationController::class)
    ->only(['index', 'show', 'store', 'update', 'destroy']);
