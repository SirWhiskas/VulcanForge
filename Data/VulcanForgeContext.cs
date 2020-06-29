using Microsoft.EntityFrameworkCore;
using VulcanForge.Models;

namespace VulcanForge.Data
{
    public class VulcanForgeContext : DbContext
    {
        private string v;

        public VulcanForgeContext(DbContextOptions<VulcanForgeContext> options)
            : base(options)
        {
        }

        public DbSet<CampaignSetting> CampaignSetting { get; set; }

        public DbSet<VulcanForge.Models.World> World { get; set; }

        public DbSet<VulcanForge.Models.ResourceType> ResourceType { get; set; }

        public DbSet<VulcanForge.Models.Resource> Resource { get; set; }

        public DbSet<VulcanForge.Models.Asset> Asset { get; set; }
    }
}