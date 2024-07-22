using McHILO.Model;
using Spectre.Console;

namespace McHILO.Service
{
    public class UserGuessReaderService : IUserGuessReaderService
    {
        private readonly IInputReaderService _inputReaderService;

        public UserGuessReaderService(IInputReaderService inputReaderService)
        {
            _inputReaderService = inputReaderService;
        }

        public int ReadGuess(string username, MysteryNumberRange range)
        {
            InputInformation<int> inputInformation = new($"{username}, enter your guess: ", "It's not a valid number, try again:", n =>
            {
                return n switch
                {
                    _ when n > range.Max => ValidationResult.Error("[red]Number is out of range![/]"),
                    _ when n < range.Min => ValidationResult.Error("[red]Number is out of range![/]"),
                    _ => ValidationResult.Success(),
                };
            });

            return _inputReaderService.ReadInput(inputInformation);
        }
    }
}
