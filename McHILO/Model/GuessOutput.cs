namespace McHILO.Model
{
    public enum GuessOutput
    {
        [Message("Your guess is too high")]
        TOO_HIGH,

        [Message("Your guess is too low")]
        TOO_LOW,

        [Message("Congratulations! It's a correct number!")]
        CORRECT
    }
}
