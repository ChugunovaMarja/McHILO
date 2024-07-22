namespace McHILO.Model
{
    public class MysteryNumberRange // could use Range, but keeping own class for preserving Min and Max mentioned in task
    {
        public int Min { get; }
        public int Max { get; }
        public int AttemptsLimit { get; set; }

        public MysteryNumberRange(int min, int max)
        {
            Min = min; Max = max;
        }
    }
}
