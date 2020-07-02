using System.ComponentModel.DataAnnotations;

namespace VulcanForge.Models
{
    public class CampaignSetting
    {
        public long Id { get; set; }

        [Required]
        public long WorldId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Secret { get; set; }
    }
}