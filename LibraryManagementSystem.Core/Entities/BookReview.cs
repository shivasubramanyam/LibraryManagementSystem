using System;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Core.Entities
{
    public class BookReview
    {
        [JsonPropertyName("reviewId")]
        public int ReviewId { get; set; }

        [JsonPropertyName("reviewBy")]
        public string ReviewBy { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("Author")]
        public string Author { get; set; }

        [JsonPropertyName("review")]
        public string Review { get; set; }

        [JsonPropertyName("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
    }
}
