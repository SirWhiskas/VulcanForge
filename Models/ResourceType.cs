using System.ComponentModel.DataAnnotations;

namespace VulcanForge.Models
{
    public class ResourceType
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}