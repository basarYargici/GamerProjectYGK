using GamerProject.Entities;

namespace GamerProject.Abstract
{
    public interface IGamerService
    {
        void NewGamer(Gamer gamer);
        void DeleteGamer(Gamer gamer);
        void UpdateGamer(Gamer gamer);
        void BuyGame(Gamer gamer, Game game);
    }
}