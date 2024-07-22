using McHILO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McHILO.Service
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserReaderService _userReaderService;

        public UserRegistrationService(IUserReaderService userReaderService)
        {
            _userReaderService = userReaderService;
        }
        public List<User> RegisterUsers(int usersQuantity)
        {
            List<User> users = new();
            for (int i = 0; i < usersQuantity; i++)
            {
                users.Add(_userReaderService.ReadUser(i));
            }
            return users;
        }
    }
}
