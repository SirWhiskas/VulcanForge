namespace VulcanForge.Models
{
    public class Resource
    {
        public long Id { get; set; }
        public long resourceTypeId { get; set; }
        public string Name { get; set; }
        public long worldId { get; set; }
    }
}