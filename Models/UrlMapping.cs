namespace urlShortener.Models
{
        public class UrlMapping
        {
            // Primary key
            public string ShortenedUrl { get; set; }

            // URL to be mapped
            public string? LongUrl { get; set; }

            // Timestamp for when the mapping was created
            public DateTime CreatedAt { get; set; }

            // Constructor
            public UrlMapping()
            {
                CreatedAt = DateTime.UtcNow;

            }
        }
    

}
