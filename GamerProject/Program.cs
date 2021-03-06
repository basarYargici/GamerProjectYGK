using System;
using System.Collections.Generic;
using GamerProject.Concrete;
using GamerProject.Entities;

namespace GamerProject
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Program Working\n");

            #region Manager instantiation

            var campaignManager = new CampaignManager();
            var saleManager = new SaleManager(campaignManager);
            var gamerManager = new GamerManager(saleManager);
            var gameManager = new GameManager();
            var validationManager = new ValidationManager();

            #endregion

            #region Campaign insantiation

            var lowCampaign = new Campaign
            {
                Id = 1,
                Discount = 10,
                Title = "%10 discount!"
            };

            var midCampaign = new Campaign
            {
                Id = 2,
                Discount = 20,
                Title = "%20 discount!"
            };

            var highCampaign = new Campaign
            {
                Id = 3,
                Discount = 20,
                Title = "%30 discount!"
            };

            #endregion

            campaignManager.NewCampaign(lowCampaign);
            campaignManager.NewCampaign(midCampaign);
            campaignManager.NewCampaign(highCampaign);

            #region Game insantiation

            var cod4 = new Game
            {
                Id = 1,
                Name = "Call Of Duty 4",
                Price = 100
            };
            var codBlackOps = new Game
            {
                Id = 2,
                Name = "Call Of Duty Black Ops",
                Price = 200
            };

            var gta5 = new Game
            {
                Id = 3,
                Name = "GTA 5",
                Price = 2000
            };

            #endregion

            gameManager.AddGame(gta5);
            gameManager.AddGame(cod4);
            gameManager.AddGame(codBlackOps);

            #region Gamer instantiation

            var poorGamer = new Gamer
            {
                Id = 1, Name = "Ibrahim",
                Surname = "Yargici",
                IdentityNumber = "12345678910",
                BirthDate = new DateTime(2020, 5, 01),
                BoughtGames = new List<Game>(),
                Budget = 100,
                UsedCampaigns = new List<Campaign> {midCampaign}
            };

            var richGamer = new Gamer
            {
                Id = 2, Name = "Basar",
                Surname = "Yargici",
                IdentityNumber = "00012345670",
                BirthDate = new DateTime(2000, 11, 01),
                BoughtGames = new List<Game> {gta5},
                Budget = 400,
                UsedCampaigns = new List<Campaign>
                {
                    lowCampaign,
                    midCampaign,
                    highCampaign
                }
            };

            var hackerGamer = new Gamer
            {
                Id = 3,
                Name = "hacker",
                Surname = "gamer",
                IdentityNumber = "null",
                Budget = 9999999999999999,
                BirthDate = new DateTime(1111, 01, 01),
                BoughtGames = new List<Game> {gta5, cod4},
                UsedCampaigns = new List<Campaign>()
            };

            #endregion

            // Add gamers
            gamerManager.NewGamer(poorGamer);
            gamerManager.NewGamer(richGamer);
            gamerManager.NewGamer(hackerGamer);

            // Is gamer valid
            // Console.WriteLine(validationManager.IsGamerValid(richGamer));

            // Print all gamers
            // gamerManager.AllGamers();

            // All games
            // gameManager.AllGames();

            // All games that hackerGamer has
            // gamerManager.AllGameNames(hackerGamer);

            // All conditions on buying games
            // gamerManager.BuyGame(richGamer, codBlackOps);
            // 
            // gamerManager.BuyGame(poorGamer, cod4);
            // 
            // gamerManager.BuyGame(hackerGamer, codBlackOps);
            // 
            // gamerManager.AllGamers();


            // Delete gamer            
            // gamerManager.DeleteGamer(hackerGamer);

            // Update gamer
            // gamerManager.UpdateGamer(hackerGamer);
        }
    }
}