using System.ComponentModel.DataAnnotations;

namespace VulcanForge.Models
{
    public class World
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(140)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}