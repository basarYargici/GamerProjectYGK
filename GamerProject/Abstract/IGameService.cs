using GamerProject.Entities;

namespace GamerProject.Abstract
{
    public interface IGameService
    {
        void AddGame(Game game);
        void RemoveGame(Game game);
    }
}