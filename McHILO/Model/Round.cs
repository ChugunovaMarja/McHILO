namespace McHILO.Model
{
    public class Round
    {
        public int Index { get; }
        public List<int> UserGuesses { get; }
        public bool IsNumberGuessed { get; set; }
        public int MysteryNumber { get; }
        public int StartingUserIndex {  get; set; } 

        public Round(int index, int mysteryNumber)
        {
            Index = index;
            MysteryNumber = mysteryNumber;
            UserGuesses = new();
        }
    }
}
