using System;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Core.Entities
{
    public class BookReviewRequest
    {
        [JsonPropertyName("reviewId")]
        public int ReviewId { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("bookId")]
        public int BookId { get; set; }

        [JsonPropertyName("review")]
        public string Review { get; set; }
        
        [JsonPropertyName("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
    }
}
