using Microsoft.EntityFrameworkCore;
using VulcanForge.Models;

namespace VulcanForge.Data
{
    public class VulcanForgeContext : DbContext
    {
        public VulcanForgeContext(DbContextOptions<VulcanForgeContext> options)
            : base(options)
        {
        }

        // public DbSet<CampaignSetting> CampaignSetting { get; set; }

        public DbSet<World> World { get; set; }
        
        public DbSet<CampaignSetting> CampaignSetting { get; set; }

        public DbSet<ResourceType> ResourceType { get; set; }

        public DbSet<Resource> Resource { get; set; }

        public DbSet<Asset> Asset { get; set; }
    }
}