using McHILO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McHILO.Service
{
    public class RangeRegistrationService : IRangeRegistrationService
    {
        private readonly IRangeReaderService _rangeReaderService;

        public RangeRegistrationService(IRangeReaderService rangeReaderService)
        {
            _rangeReaderService = rangeReaderService;
        }
        public MysteryNumberRange InitializeRange(double attemptsNumberCoefficient = 1.75)
        {
            MysteryNumberRange range = _rangeReaderService.ReadRange();
            range.AttemptsLimit = CalculateAttemptsQuantity(range.Min, range.Max, attemptsNumberCoefficient);
            return range;
        }
        private int CalculateAttemptsQuantity(int min, int max, double coefficient) => (int)Math.Ceiling(Math.Log2(max - min + 1) * coefficient);
    }
}
