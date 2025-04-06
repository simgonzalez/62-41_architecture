<?php

namespace App\Enums;

class Status
{
    public const PENDING = 'pending';
    public const APPROVED = 'approved';
    public const REJECTED = 'rejected';
    public const COMPLETED = 'completed';
    
    public const EXPIRED = 'expired';

    public static function all(): array
    {
        return [
            self::PENDING,
            self::APPROVED,
            self::REJECTED,
            self::COMPLETED,
            self::EXPIRED,
        ];
    }
}