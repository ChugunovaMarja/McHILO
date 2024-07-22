using McHILO.Model;
using McHILO.Service;

namespace McHILO.Controller
{
    public class RoundController : IRoundController
    {
        private readonly IRoundService _roundService;
        private readonly IIterationService _iterationService;
        private readonly IUserGuessReaderService _userGuessReaderService;

        public RoundController(IRoundService roundService, IIterationService iterationService, IUserGuessReaderService userGuessReaderService)
        {
            _roundService = roundService;
            _iterationService = iterationService;
            _userGuessReaderService = userGuessReaderService;
        }

        public Round PlayRound(MysteryNumberRange range, List<User> users, int roundIndex)
        {
            Round round = new(roundIndex, _roundService.GenerateMysteryNumber(range));

            Console.Clear();
            Console.WriteLine($"-------------Round {round.Index + 1}-------------");
            Console.WriteLine($"The mystery number in range [{range.Min}, {range.Max}] is chosen. Time to start guessing! You have {range.AttemptsLimit} attempts ;)");

            round.StartingUserIndex = _roundService.CalculateStartingUserIndex(round.Index, users);
            while (!_roundService.IsOver(round, range.AttemptsLimit))
            {
                int userGuess = _iterationService.GetNextUserGuess(users, round, range);
                round.UserGuesses.Add(userGuess);

                GuessOutput output = _iterationService.ProcessUserGuess(userGuess, round.MysteryNumber);
                Console.WriteLine(output.GetMessage());
                if (output == GuessOutput.CORRECT)
                {
                    round.IsNumberGuessed = true;
                }
            }
            if (!round.IsNumberGuessed)
            {
                Console.WriteLine($"You are out of attempts");
                Console.WriteLine($"The mystery number was: {round.MysteryNumber}");
            }
            return round;
        }

    }
}
