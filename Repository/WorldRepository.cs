using VulcanForge.Models;
using VulcanForge.Interfaces;

namespace VulcanForge.Repository
{
    public class WorldRepository : RepositoryBase<World>, IWorldRepository
    {
        public WorldRepository(VulcanForgeContext repositoryContext) :base(repositoryContext)
        {
        }
    }
}