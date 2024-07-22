using McHILO.Model;

namespace McHILO.Controller
{
    public interface IRoundController
    {
        Round PlayRound(MysteryNumberRange range, List<User> users, int roundIndex);
    }
}