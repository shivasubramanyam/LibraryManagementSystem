using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Core.Entities
{
    public class Book
    {
        [JsonPropertyName("bookId")]
        public int BookId { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("publishedYear")]
        public int PublishedYear { get; set; }
    }
}
