using GamerProject.Abstract;
using GamerProject.Entities;

namespace GamerProject.Concrete
{
    public class ValidationManager : IValidationService
    {
        public bool IsGamerValid(Gamer gamer)
        {
            // simulation of validation 
            return gamer.Name == "Basar" && gamer.Surname == "Yargici";
        }
    }
}