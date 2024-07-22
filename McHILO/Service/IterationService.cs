using McHILO.Model;

namespace McHILO.Service
{
    public class IterationService : IIterationService
    {
        IUserGuessReaderService _userGuessReaderService;

        public IterationService(IUserGuessReaderService userGuessReaderService)
        {
            _userGuessReaderService = userGuessReaderService;
        }

        public int GetNextUserGuess(List<User> users, Round round, MysteryNumberRange range)
        {
            int activeUserIndex = SelectUserIndex(round.StartingUserIndex, round.UserGuesses.Count, users.Count);
            return _userGuessReaderService.ReadGuess(users[activeUserIndex].Name, range);
        }
        public int SelectUserIndex(int userToStart, int iterationIndex, int numberOfUsers)
        {
            return (userToStart + iterationIndex) % numberOfUsers;
        }

        public GuessOutput ProcessUserGuess(int userGuess, int MysteryNumber)
        {
            if (userGuess > MysteryNumber)
            {
                return GuessOutput.TOO_HIGH;
            }
            if (userGuess < MysteryNumber)
            {
                return GuessOutput.TOO_LOW;
            }
            return GuessOutput.CORRECT;
        }
    }
}
