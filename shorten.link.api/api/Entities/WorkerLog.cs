using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class WorkerLog
    {
        [Key]
        public int Id { get; set; }
        public string JobName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}