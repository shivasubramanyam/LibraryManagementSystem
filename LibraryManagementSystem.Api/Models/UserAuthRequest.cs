using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Api.Models
{
    public class UserAuthRequest
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
