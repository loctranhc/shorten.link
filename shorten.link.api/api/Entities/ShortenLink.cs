using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class ShortenLink
    {
        [Key]
        public int Id { get; set; }
        public string Hash { get; set; } = string.Empty;
        public string RedirectorEndpoint { get; set; } = string.Empty;
        public string OriginalLink { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}