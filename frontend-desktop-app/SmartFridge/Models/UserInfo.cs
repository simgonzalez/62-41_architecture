using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartFridge.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        [JsonPropertyName("first_name")]
        public required string FirstName { get; set; }
        [JsonPropertyName("email_verified_at")]
        public string EmailVerifiedAt { get; set; }
        public required List<string> Roles { get; set; }
    }
}
