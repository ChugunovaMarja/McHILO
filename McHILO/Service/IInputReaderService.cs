using McHILO.Model;

namespace McHILO.Service
{
    public interface IInputReaderService
    {
        T ReadInput<T>(InputInformation<T> inputInformation);
    }
}