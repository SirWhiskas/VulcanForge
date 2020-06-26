using VulcanForge.Models;
using VulcanForge.Interfaces;

namespace VulcanForge.Repository
{
    public class CampaignSettingRepository : RepositoryBase<CampaignSetting>, ICampaignSettingRepository
    {
        public CampaignSettingRepository(VulcanForgeContext repositoryContext) :base(repositoryContext)
        {
        }
    }
}