using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartFridge.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [JsonPropertyName("first_name")]
        public string First_Name { get; set; }
        public List<string> Roles { get; set; }

        // Single role for backend serialization
        [JsonPropertyName("role")]
        public string Role
        {
            get => Roles != null && Roles.Count > 0 ? Roles.First() : string.Empty;
            set => Roles = !string.IsNullOrWhiteSpace(value) ? new List<string> { value } : new List<string>();
        }

        private string _password;

        [JsonPropertyName("password")]
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public bool ShouldSerializePassword()
        {
            // Only serialize the password if it is not null or empty
            return !string.IsNullOrWhiteSpace(_password);
        }
    }

}
