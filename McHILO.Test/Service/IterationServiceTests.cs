using McHILO.Model;
using McHILO.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McHILO.Service.Tests
{
    [TestClass()]
    public class IterationServiceTests
    {
        [TestMethod()]
        public void SelectUserIndexTest()
        {
            Mock<IUserGuessReaderService> userGuessReaderService = new();
            IterationService iterationService = new IterationService(userGuessReaderService.Object);
            int userToStart = 1;
            int iterationIndex = 4;
            int usersNumber = 3;
            int expectedResult = 2;
            int actualResult = iterationService.SelectUserIndex(userToStart, iterationIndex, usersNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void ProcessUserGuessHighTest()
        {
            Mock<IUserGuessReaderService> userGuessReaderService = new();
            IterationService iterationService = new IterationService(userGuessReaderService.Object);
            GuessOutput output = iterationService.ProcessUserGuess(10, 7);
            Assert.AreEqual(GuessOutput.TOO_HIGH, output);
        }

        [TestMethod()]
        public void ProcessUserGuessLowTest()
        {
            Mock<IUserGuessReaderService> userGuessReaderService = new();
            IterationService iterationService = new IterationService(userGuessReaderService.Object);
            GuessOutput output = iterationService.ProcessUserGuess(7, 10);
            Assert.AreEqual(GuessOutput.TOO_LOW, output);
        }

        [TestMethod()]
        public void ProcessUserGuessCorrectTest()
        {
            Mock<IUserGuessReaderService> userGuessReaderService = new();
            IterationService iterationService = new IterationService(userGuessReaderService.Object);
            GuessOutput output = iterationService.ProcessUserGuess(10, 10);
            Assert.AreEqual(GuessOutput.CORRECT, output);
        }
    }
}