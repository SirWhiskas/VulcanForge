using System.Collections.Generic;
using VulcanForge.Models;

namespace VulcanForge.Data
{
    public class MockVulcanForgeRepo : IVulcanForgeRepo
    {
        public World GetWorldById(long id)
        {
            return new World{Id=0, Name="Test World", Description="A new world to explore"};
        }

        public IEnumerable<World> GetWorlds()
        {
            var worlds = new List<World>
            {
                new World{Id=0, Name="Test World", Description="A new world to explore"},
                new World{Id=0, Name="Test World 2", Description="A new world 2 to explore"},
                new World{Id=0, Name="Test World 3", Description="A new world 3 to explore"}
            };

            return worlds;
        }
    }
}