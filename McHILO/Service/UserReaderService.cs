using McHILO.Configuration;
using McHILO.Model;
using Microsoft.Extensions.Options;
using Spectre.Console;

namespace McHILO.Service
{
    public class UserReaderService : IUserReaderService
    {
        private readonly IInputReaderService _inputReaderService;
        private readonly ValidationConfiguration _validationConfiguration;

        public UserReaderService(IInputReaderService inputReaderService, IOptions<ValidationConfiguration> validationConfiguration)
        {
            _inputReaderService = inputReaderService;
            _validationConfiguration = validationConfiguration.Value;
        }

        public User ReadUser(int userIndex)
        {
            return new User(ReadUsername(userIndex));
        }
        private string ReadUsername(int userIndex)
        {
            int maxLength = _validationConfiguration.MaxUsernameLength;
            InputInformation<string> inputInformation = new($"What's your name player #{userIndex+1}? Max {maxLength} characters: ", "It's not a valid string, try again:", s =>
            {
                return s.Length switch
                {
                    0 => ValidationResult.Error("[red]String shouldn't be empty![/]"),
                    _ when s.Length > maxLength => ValidationResult.Error($"[red]Should be {maxLength} max![/]"),
                    _ => ValidationResult.Success(),
                };
            });

            return _inputReaderService.ReadInput(inputInformation);
        }
    }
}
