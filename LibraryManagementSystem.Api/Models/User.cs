using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Api.Models
{
    public class User
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("userRole")]
        public string UserRole { get; set; }

        [JsonPropertyName("isActiveUser")]
        public bool IsActiveUser { get; set; }
    }
}
