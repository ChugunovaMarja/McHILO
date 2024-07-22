using McHILO.Model;

namespace McHILO.Service
{
    public interface IUserRegistrationService
    {
        List<User> RegisterUsers(int usersQuantity);
    }
}