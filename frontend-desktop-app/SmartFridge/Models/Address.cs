using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartFridge.Models
{
    public class Address
    {
        public int Id { get; set; }
        [JsonPropertyName("street_name")]
        public string Street_Name { get; set; }
        [JsonPropertyName("street_number")]
        public string Street_Number { get; set; }
        public string Npa { get; set; }
        public string City { get; set; }
    }
}
