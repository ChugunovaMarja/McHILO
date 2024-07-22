using McHILO.Model;

namespace McHILO.Service
{
    public class RoundService : IRoundService
    {
        public int CalculateStartingUserIndex(int roundIndex, List<User> users)
        {
            return (roundIndex % users.Count);
        }

        public int GenerateMysteryNumber(MysteryNumberRange mysteryNumberRange)
        {
            Random random = new Random();
            return random.Next(mysteryNumberRange.Min, mysteryNumberRange.Max + 1);
        }

        public bool IsOver(Round round, int attemptsLimit)
        {
            return round.IsNumberGuessed || round.UserGuesses.Count >= attemptsLimit;
        }
    }
}
