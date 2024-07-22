using McHILO.Model;

namespace McHILO.Service
{
    public interface IUserGuessReaderService
    {
        int ReadGuess(string username, MysteryNumberRange range);
    }
}