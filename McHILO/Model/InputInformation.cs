using Spectre.Console;


namespace McHILO.Model
{
    public class InputInformation<T>
    {
        public string RequestMessage { get; }
        public string TypeValidationError { get; }
        public Func<T, ValidationResult> ValidationFunction { get; }

        public InputInformation(string requestMessage, string typeValidationError, Func<T, ValidationResult> validationFunction)
        {
            RequestMessage = requestMessage;
            TypeValidationError = typeValidationError;
            ValidationFunction = validationFunction;
        }

    }
}
