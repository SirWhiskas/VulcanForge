namespace VulcanForge.Models
{
    public class CampaignSetting
    {
        public long Id { get; set; }
        public long WorldId { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }

        public void UpdateWithDTO(CampaignSettingDTO campaignSettingDto)
        {
            WorldId = campaignSettingDto.WorldId;
            Name = campaignSettingDto.Name;
        }
    }
}