using McHILO.Model;

namespace McHILO.Service.Tests
{
    [TestClass()]
    public class RoundServiceTests
    {
        [TestMethod()]
        public void CalculateStartingUserIndexSingleTest()
        {
            int roundIndex = 5;
            List<User> users = [new User("testname")];

            int startingUserIndex = new RoundService().CalculateStartingUserIndex(roundIndex, users);
            Assert.AreEqual(0, startingUserIndex);
        }

        [TestMethod()]
        public void CalculateStartingUserIndexMultiTest()
        {
            int roundIndex = 5;

            List<User> users = [new User("testname1"), new User("testname2"), new User("testname3")];

            int startingUserIndex = new RoundService().CalculateStartingUserIndex(roundIndex, users);
            Assert.AreEqual(2, startingUserIndex);
        }

        [TestMethod()]
        public void GenerateMysteryNumberTest()
        {
            MysteryNumberRange mysteryNumberRange = new MysteryNumberRange(1, 10);

            int mysteryNumber = new RoundService().GenerateMysteryNumber(mysteryNumberRange);
            Assert.IsTrue(mysteryNumber >= 1);
            Assert.IsTrue(mysteryNumber <= 10);
        }

        [TestMethod()]
        public void IsOverByFoundTest()
        {
            int attemptsLimit = 7;
            Round round = new Round(1, 20);
            round.UserGuesses.Add(4);
            round.IsNumberGuessed = true;

            bool isOver = new RoundService().IsOver(round, attemptsLimit);
            Assert.IsTrue(isOver);
        }

        [TestMethod()]
        public void IsOverByMaxAttemptsTest()
        {
            int attemptsLimit = 3;
            Round round = new Round(1, 20);
            for (int i = 0; i < attemptsLimit; i++)
            {
                round.UserGuesses.Add(i);
            }
            round.IsNumberGuessed = false;

            bool isOver = new RoundService().IsOver(round, attemptsLimit);
            Assert.IsTrue(isOver);
        }

        [TestMethod()]
        public void IsOverFalseTest()
        {
            int attemptsLimit = 5;
            Round round = new Round(1, 20);
            for (int i = 0; i < attemptsLimit-2; i++)
            {
                round.UserGuesses.Add(i);
            }
            round.IsNumberGuessed = false;

            bool isOver = new RoundService().IsOver(round, attemptsLimit);
            Assert.IsFalse(isOver);
        }
    }
}