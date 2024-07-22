using McHILO.Configuration;
using McHILO.Model;
using McHILO.Service;
using Microsoft.Extensions.Options;
using Spectre.Console;
using System.Text;

namespace McHILO.Controller
{
    public class MainController
    {

        private readonly IUserReaderService _userReaderService;
        private readonly IGameController _gameController;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly GameConfiguration _gameConfiguration;

        public MainController( IGameController gameController, IOptions<GameConfiguration> gameConfiguration, IUserReaderService userReaderService, IUserRegistrationService userRegistrationService)
        {
            _gameController = gameController;
            _userReaderService = userReaderService;
            _gameConfiguration = gameConfiguration.Value;
            _userRegistrationService = userRegistrationService;
        }

        public void Start()
        {
            Console.WriteLine("Hello, User! Let's play");
            Console.WriteLine("I'm going to pick a number in range [Min, Max]. You need to guess it in a minimum of iterations.");
            Console.WriteLine("Who wants to play? ");

            int usersQuantity = (_gameConfiguration.DefaultGameMode == GameMode.SINGLE) ? 1 : throw new Exception("Not yet implemented");
            List<User> users = _userRegistrationService.RegisterUsers(usersQuantity);

            if (IsReadyToPlay())
            {
                Game game = new(users);
                _gameController.PlayGame(game);
                ShowResults(game);
            }
            else
            {
                Console.WriteLine("Okay, bye");
            }
        }

        private bool IsReadyToPlay()
        {

            string answer = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Are you ready?")
                            .AddChoices("Yes", "No")
                    );
            return answer == "Yes";
        }

        private void ShowResults(Game game)
        {
            Console.WriteLine($"\n-------Here are the results-------");

            Round bestRound = game.Rounds.Where(x => x.IsNumberGuessed == true).ToList()
                                         .OrderBy(u => u.UserGuesses.Count)
                                         .FirstOrDefault();
            if (bestRound != null)
            {
                Console.WriteLine($"Best result: {bestRound.UserGuesses.Count}");
            }
            else
            {
                Console.WriteLine("There were no successful rounds, sorry ;(");
            }
        }
    }
}
