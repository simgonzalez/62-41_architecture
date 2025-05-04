using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartFridge.Models
{
    public class FoodRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("organization_id")]
        public int OrganizationId { get; set; }
        [JsonPropertyName("organization_name")]
        public string OrganizationName { get; set; }
        public string Description { get; set; }
        [JsonPropertyName("deadline_date")]
        public DateTime DeadlineDate { get; set; }
        [JsonPropertyName("responsible_user_id")]
        public int ResponsibleUserId { get; set; }
        [JsonPropertyName("responsible_user_name")]
        public string ResponsibleUserName { get; set; }
        [JsonPropertyName("created_by_user_id")]
        public int CreatedByUserId { get; set; }
        [JsonPropertyName("created_by_user_name")]
        public string CreatedByUserName { get; set; }
        public string Status { get; set; }
    }
}
