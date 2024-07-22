using McHILO.Model;
using McHILO.Service;
using Spectre.Console;

namespace McHILO.Controller
{
    public class GameController : IGameController
    {
        private readonly IRangeRegistrationService _rangeRegistrationService;
        private readonly IRoundController _roundController;
        public GameController(IRangeRegistrationService rangeReaderService, IRoundController roundController)
        {
            _rangeRegistrationService = rangeReaderService;
            _roundController = roundController;
        }

        public void PlayGame(Game game)
        {
            Console.WriteLine("Great!");

            MysteryNumberRange range = _rangeRegistrationService.InitializeRange();

            do
            {
                game.Rounds.Add(_roundController.PlayRound(range, game.Users, game.Rounds.Count));
            } while (ShouldContinue());
        }

        private bool ShouldContinue()
        {
            string userAnswer = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Are you ready for another round?")
                        .AddChoices("Yes", "No, show results")
                );
            return userAnswer == "Yes";
        }
    }
}
