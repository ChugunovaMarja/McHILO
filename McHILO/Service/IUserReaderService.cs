using McHILO.Model;

namespace McHILO.Service
{
    public interface IUserReaderService
    {
        public User ReadUser(int userIndex);
    }
}