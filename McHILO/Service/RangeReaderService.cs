using McHILO.Configuration;
using McHILO.Model;
using Microsoft.Extensions.Options;
using Spectre.Console;

namespace McHILO.Service
{
    public class RangeReaderService : IRangeReaderService
    {
        private readonly IInputReaderService _inputReaderService;
        private readonly ValidationConfiguration _validationConfiguration;

        public RangeReaderService(IInputReaderService inputReaderService, IOptions<ValidationConfiguration> validationConfiguration)
        {
            _inputReaderService = inputReaderService;
            _validationConfiguration = validationConfiguration.Value;
        }
        public MysteryNumberRange ReadRange()
        {
            Console.WriteLine("Let's choose the range!");
            int minimum = ReadMinimum();
            int maximum = ReadMaximum(minimum);
            return new MysteryNumberRange(minimum, maximum);
        }

        private int ReadMinimum()
        {
            InputInformation<int> inputInformation = new("Enter minimum value: ", "It's not a valid number, try again:",
            null);

            return _inputReaderService.ReadInput(inputInformation);
        }

        private int ReadMaximum(int minimum)
        {
            int minDelta = _validationConfiguration.MinRangeDelta;
            InputInformation<int> inputInformation = new("Enter maximum value: ", "It's not a valid number, try again:",
            n =>
            {
                return n switch
                {
                    _ when (n - minimum) < minDelta => ValidationResult.Error($"[red]Maximum should exceed minimum at least by {minDelta}![/]"),
                    _ => ValidationResult.Success()
                };
            });

            return _inputReaderService.ReadInput(inputInformation);
        }
    }
}
