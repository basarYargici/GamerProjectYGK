using GamerProject.Entities;

namespace GamerProject.Abstract
{
    public interface IValidationService
    {
        void IsGamerValid(Gamer gamer);
    }
}