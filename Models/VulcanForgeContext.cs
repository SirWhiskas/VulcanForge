using Microsoft.EntityFrameworkCore;
using VulcanForge.Models;

namespace VulcanForge.Models
{
    public class VulcanForgeContext : DbContext
    {
        public VulcanForgeContext(DbContextOptions<VulcanForgeContext> options)
            : base(options)
        {
        }

        public DbSet<CampaignSetting> CampaignSetting { get; set; }

        public DbSet<VulcanForge.Models.World> World { get; set; }

        public DbSet<VulcanForge.Models.ResourceType> ResourceType { get; set; }

        public DbSet<VulcanForge.Models.Resource> Resource { get; set; }
    }
}