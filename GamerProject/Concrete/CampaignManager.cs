using System;
using System.Collections.Generic;
using System.Linq;
using GamerProject.Abstract;
using GamerProject.Entities;

namespace GamerProject.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private readonly List<Campaign> _campaigns = new List<Campaign>();

        public void NewCampaign(Campaign campaign)
        {
            if (_campaigns.Contains(campaign))
            {
                Console.WriteLine("Campaign already exists");
            }
            else
            {
                _campaigns.Add(campaign);
            }
        }

        public void DeleteCampaign(Campaign campaign)
        {
            var a = _campaigns.FirstOrDefault(c => c.Id == campaign.Id);
            if (a != null)
            {
                _campaigns.Remove(a);
            }
            else
            {
                Console.WriteLine(campaign.Title + " not found");
            }
        }

        public void UpdateCampaign(Campaign campaign)
        {
            Console.WriteLine(_campaigns.Contains(campaign)
                ? campaign.Title + " Updated"
                : campaign.Title + " Not Found");
        }

        public Campaign GetCampaign(int id)
        {
            return _campaigns.FirstOrDefault(campaign => campaign.Id == id);
        }

        public List<Campaign> AllCampaigns()
        {
            return _campaigns;
        }
    }
}