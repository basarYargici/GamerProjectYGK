using System;
using System.Linq;
using GamerProject.Abstract;
using GamerProject.Entities;

namespace GamerProject.Concrete
{
    public class SaleManager : ISaleService
    {
        private readonly ICampaignService _campaignService;

        public SaleManager(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public void SaleProduct(Gamer gamer, Game game)
        {
            // if user used all campaigns there should not be any campaign for gamer
            if (_campaignService.AllCampaigns().Count == gamer.UsedCampaigns.Count)
            {
                Console.WriteLine(gamer.Name + " used all campaigns! \n");
                return;
            }

            SelectCampaign(gamer, game);
        }

        private void SelectCampaign(Gamer gamer, Game game)
        {
            var isSelected = false;

            Console.WriteLine("Available campaigns for " + gamer.Name);
            foreach (var campaign in _campaignService.AllCampaigns()
                .Where(campaign => !gamer.UsedCampaigns.Contains(campaign)))
                Console.WriteLine("Campaign id = " + campaign.Id + "Campaign title = " + campaign.Title +
                                  " discount rate= " + campaign.Discount);

            while (!isSelected)
            {
                Console.WriteLine("\nWhich campaign would you like to select? Please enter id :");
                try
                {
                    var id = int.Parse(Console.ReadLine() ?? "0");
                    if (gamer.UsedCampaigns.FirstOrDefault(campaign => campaign.Id == id) != null)
                    {
                        Console.WriteLine("Please enter valid id!");
                    }

                    else
                    {
                        var selectedCampaign = _campaignService.GetCampaign(id);
                        isSelected = true;
                        gamer.Budget -= game.Price - game.Price * selectedCampaign.Discount / 100;
                        gamer.BoughtGames.Add(game);
                        gamer.UsedCampaigns.Add(selectedCampaign);

                        Console.WriteLine(gamer.Name + " bought " + game.Name + " with %" + selectedCampaign.Discount +
                                          " discounted price !!!");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter valid id!");
                }
            }
        }
    }
}