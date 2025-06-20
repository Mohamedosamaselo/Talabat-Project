﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Api.Controllers.Errors
{
    public class ApiExceptionResponse : ApiResponse
    {
        public string ?  Details { get; set; }

        public ApiExceptionResponse(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
        {
            Details = details;

            
        }

       // public override string ToString() => JsonSerializer.Serialize(this , new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

    }
}
