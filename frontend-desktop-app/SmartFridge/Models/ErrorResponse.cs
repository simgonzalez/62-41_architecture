﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFridge.Models
{
    internal class ErrorResponse
    {
            public string Message { get; set; }
            public Dictionary<string, string[]> Errors { get; set; }

    }
}
