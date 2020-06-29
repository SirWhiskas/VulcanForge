using System.Collections.Generic;
using VulcanForge.Models;

namespace VulcanForge.Data
{
    public interface IVulcanForgeRepo
    {
        IEnumerable<World> GetWorlds();
        World GetWorldById(long id);
    }
}