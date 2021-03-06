using System;
using System.Collections.Generic;
using System.Linq;
using GamerProject.Abstract;
using GamerProject.Entities;

namespace GamerProject.Concrete
{
    public class GamerManager : IGamerService
    {
        private readonly List<Gamer> _gamers = new List<Gamer>();
        private readonly ISaleService _saleService;

        public GamerManager(ISaleService saleService)
        {
            _saleService = saleService;
        }


        public void NewGamer(Gamer gamer)
        {
            if (_gamers.Contains(gamer))
                Console.WriteLine("Gamer already exists");
            else
                _gamers.Add(gamer);
        }

        public void DeleteGamer(Gamer gamer)
        {
            var gamerInstance = _gamers.FirstOrDefault(g => g.Id == gamer.Id);
            if (gamerInstance != null)
                _gamers.Remove(gamerInstance);
            else
                Console.WriteLine(gamer.Name + " not found");
        }

        public void UpdateGamer(Gamer gamer)
        {
            Console.WriteLine(_gamers.Contains(gamer)
                ? gamer.Name + " Updated"
                : gamer.Name + " Not Found");
        }

        public void BuyGame(Gamer gamer, Game game)
        {
            if (gamer.BoughtGames.Contains(game))
                Console.WriteLine(gamer.Name + " has already bought " + game.Name + "\n");
            else if (gamer.Budget < game.Price)
                Console.WriteLine(gamer.Name + " does not have enough budget to buy" + game.Name + "\n");
            else
                _saleService.SaleProduct(gamer, game);
        }

        public void AllGamers()
        {
            foreach (var gamer in _gamers)
            {
                Console.WriteLine("name = " + gamer.Name + "\nbudget = " + gamer.Budget + "\nBought games :");
                AllGameNames(gamer);
            }
        }

        public void AllGameNames(Gamer gamer)
        {
            foreach (var bought in gamer.BoughtGames) Console.WriteLine("name = " + bought.Name);

            Console.WriteLine("\n");
        }
    }
}