using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RehabAid.Data.Models
{
   static class JsonHelper
    {
        public static JsonSerializerOptions SerializerOptions => new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}
