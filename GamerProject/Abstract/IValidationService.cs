using GamerProject.Entities;

namespace GamerProject.Abstract
{
    public interface IValidationService
    {
        bool IsGamerValid(Gamer gamer);
    }
}