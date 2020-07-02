using System.ComponentModel.DataAnnotations;

namespace VulcanForge.Models
{
    public class Resource
    {
        public long Id { get; set; }

        [Required]
        public long resourceTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public long worldId { get; set; }
    }
}