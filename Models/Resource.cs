namespace VulcanForge.Models
{
    public class Resource
    {
        public long Id { get; set; }
        public ResourceType resourceType { get; set; }
        public string Name { get; set; }
        public World world { get; set; }
    }
}