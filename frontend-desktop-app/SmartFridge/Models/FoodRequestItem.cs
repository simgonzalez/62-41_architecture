using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartFridge.Models
{
   
            public class FoodRequestItem
            {
                [JsonPropertyName("id")]
                public int Id { get; set; }

                [JsonPropertyName("request_id")]
                public int RequestId { get; set; }

                [JsonPropertyName("food_id")]
                public int FoodId { get; set; }

                public double Quantity { get; set; }

                [JsonPropertyName("unit_id")]
                public int UnitId { get; set; }

                [JsonPropertyName("food")]
                public Food Food { get; set; } // Nested Food object

                [JsonPropertyName("unit")]
                public Unit Unit { get; set; } // Nested Unit object
            }

}
