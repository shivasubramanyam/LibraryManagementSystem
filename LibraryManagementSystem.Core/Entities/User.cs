using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Core.Entities
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
        public string RoleType { get; set; }

        [JsonPropertyName("isActiveUser")]
        public bool IsActive { get; set; }

        //public User GetUserWithoutPassword()
        //{
        //    return new User
        //    {
        //        UserId = UserId,
        //        Password = null,
        //        FullName = FullName,
        //        UserName = UserName,
        //        RoleType = RoleType,
        //        IsActive = IsActive
        //    };
        //}
    }
}
