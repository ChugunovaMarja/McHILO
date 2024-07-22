using McHILO.Model;

namespace McHILO.Service
{
    public interface IIterationService
    {
        int GetNextUserGuess(List<User> users, Round round, MysteryNumberRange range);
        GuessOutput ProcessUserGuess(int userGuess, int MysteryNumber);
        int SelectUserIndex(int userToStart, int iterationIndex, int numberOfUsers);
    }
}