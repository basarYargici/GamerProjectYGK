using System.Collections.Generic;
using GamerProject.Entities;

namespace GamerProject.Abstract
{
    public interface ICampaignService
    {
        void NewCampaign(Campaign campaign);
        void DeleteCampaign(Campaign campaign);
        void UpdateCampaign(Campaign campaign);
        Campaign GetCampaign(int id);
        List<Campaign> AllCampaigns();
    }
}