using McHILO.Model;

namespace McHILO.Service
{
    public interface IRangeRegistrationService
    {
        MysteryNumberRange InitializeRange(double attemptsNumberCoefficient = 1.75);
    }
}