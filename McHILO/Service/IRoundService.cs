using McHILO.Model;

namespace McHILO.Service
{
    public interface IRoundService
    {
        int CalculateStartingUserIndex(int roundIndex, List<User> users);
        int GenerateMysteryNumber(MysteryNumberRange mysteryNumberRange);
        bool IsOver(Round round, int attemptsLimit);
    }

}