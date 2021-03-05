using System;
using System.Collections.Generic;
using GamerProject.Abstract;
using GamerProject.Concrete;
using GamerProject.Entities;

namespace GamerProject
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Program Working\n");

            ICampaignService campaignService = new CampaignManager();
            ISaleService saleService = new SaleManager(campaignService);
            GamerManager gamerManager = new GamerManager(campaignService, saleService);
            GameManager gameManager = new GameManager();

            Campaign lowCampaign = new Campaign
            {
                Id = 1,
                Discount = 10,
                Title = "%10 discount!"
            };

            Campaign midCampaign = new Campaign
            {
                Id = 2,
                Discount = 20,
                Title = "%20 discount!"
            };

            Campaign highCampaign = new Campaign
            {
                Id = 3,
                Discount = 20,
                Title = "%30 discount!"
            };

            campaignService.NewCampaign(lowCampaign);
            campaignService.NewCampaign(midCampaign);
            campaignService.NewCampaign(highCampaign);

            Game cod4 = new Game
            {
                Id = 1,
                Name = "Call Of Duty 4",
                Price = 100
            };
            Game codBlackOps = new Game
            {
                Id = 2,
                Name = "Call Of Duty Black Ops",
                Price = 200
            };

            Game gta5 = new Game
            {
                Id = 3,
                Name = "GTA 5",
                Price = 2000
            };

            gameManager.AddGame(gta5);
            gameManager.AddGame(cod4);
            gameManager.AddGame(codBlackOps);

            Gamer poorGamer = new Gamer
            {
                Id = 1, Name = "ibrahim",
                Surname = "Yargici",
                IdentityNumber = "12345678910",
                BirthDate = new DateTime(2020, 5, 01),
                BoughtGames = new List<Game> {cod4},
                Budget = 100,
                UsedCampaigns = new List<Campaign>()
            };

            Gamer richGamer = new Gamer
            {
                Id = 2, Name = "basar",
                Surname = "Yargıcı",
                IdentityNumber = "00012345670",
                BirthDate = new DateTime(2000, 11, 01),
                BoughtGames = new List<Game> {gta5},
                Budget = 400,
                UsedCampaigns = new List<Campaign>
                {
                    lowCampaign
                }
            };

            Gamer hackerGamer = new Gamer
            {
                Id = 3,
                Name = "hacker",
                Surname = "gamer",
                IdentityNumber = "null",
                Budget = 9999999999999999,
                BirthDate = new DateTime(1111, 01, 01),
                BoughtGames = new List<Game> {gta5, cod4, codBlackOps},
                UsedCampaigns = new List<Campaign> { }
            };


            gamerManager.NewGamer(poorGamer);
            gamerManager.NewGamer(richGamer);
            gamerManager.NewGamer(hackerGamer);


            gamerManager.AllGamers();

            // gamerManager.DeleteGamer(hackerGamer);
            gamerManager.BuyGame(richGamer, codBlackOps);
            
            gamerManager.AllGamers();
        }
    }
}