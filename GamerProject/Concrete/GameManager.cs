using System;
using System.Collections.Generic;
using System.Linq;
using GamerProject.Abstract;
using GamerProject.Entities;

namespace GamerProject.Concrete
{
    public class GameManager : IGameService
    {
        private readonly List<Game> _games = new List<Game>();

        public void AddGame(Game game)
        {
            if (_games.Contains(game))
            {
                Console.WriteLine("Game already exists");
            }
            else
            {
                _games.Add(game);
            }
        }

        public void RemoveGame(Game game)
        {
            var gameInstance = _games.FirstOrDefault(g => g.Id == game.Id);
            if (gameInstance != null)
            {
                _games.Remove(gameInstance);
            }
            else
            {
                Console.WriteLine(game.Name + " not found");
            }
        }

        public void AllGames()
        {
            foreach (var game in _games)
            {
                Console.WriteLine(game.Name);
            }
        }
    }
}