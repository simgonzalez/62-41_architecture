using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartFridge.Models
{
    namespace SmartFridge.Models
    {
        public class FoodRequestItem
        {
            [JsonPropertyName("request_id")]
            public int RequestId { get; set; }
            [JsonPropertyName("food_id")]
            public int FoodId { get; set; }
            [JsonPropertyName("food_name")]
            public string FoodName { get; set; }
            
            public double Quantity { get; set; }
            [JsonPropertyName("unit_id")]
            public int UnitId { get; set; }
            [JsonPropertyName("unit_name")]
            public string UnitName { get; set; } 
        }
    }

}
