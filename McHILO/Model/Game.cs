namespace McHILO.Model
{
    public class Game
    {
        public List<User> Users;
        public List<Round> Rounds;
        public MysteryNumberRange MysteryNumberRange;

        public Game(List<User> users)
        {
            Users = users;
            Rounds = new();
        }
    }
}
