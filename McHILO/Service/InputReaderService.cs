using McHILO.Model;
using Spectre.Console;

namespace McHILO.Service
{
    public class InputReaderService : IInputReaderService
    {

        public T ReadInput<T>(InputInformation<T> inputInformation)
        {
            T value = AnsiConsole.Prompt(new TextPrompt<T>(inputInformation.RequestMessage)
           .PromptStyle("green")
           .ValidationErrorMessage($"[red]{inputInformation.TypeValidationError} [/]")
           .Validate(inputInformation.ValidationFunction)
           );
            return value;
        }
    }
}

