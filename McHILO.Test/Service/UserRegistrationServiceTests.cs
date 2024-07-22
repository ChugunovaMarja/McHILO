using Microsoft.VisualStudio.TestTools.UnitTesting;
using McHILO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using McHILO.Model;

namespace McHILO.Service.Tests
{
    [TestClass()]
    public class UserRegistrationServiceTests
    {
        [TestMethod()]
        public void RegisterUsersSingleTest()
        {
            Mock<IUserReaderService> userReaderService = new();
            User mockedUser = new User("testname");
            userReaderService.Setup(x => x.ReadUser(0)).Returns(mockedUser);
            List<User> expectedResult = [mockedUser];

            UserRegistrationService userRegistrationService = new(userReaderService.Object);
            List<User> actualResult = userRegistrationService.RegisterUsers(1);

            Assert.AreEqual(expectedResult[0], actualResult[0]); 
        }

        [TestMethod()]
        public void RegisterUsersMultipleTest()
        {
            Mock<IUserReaderService> userReaderService = new();
            User mockedUser1 = new User("testname1");
            User mockedUser2 = new User("testname2");
            User mockedUser3 = new User("testname3");
            userReaderService.Setup(x => x.ReadUser(0)).Returns(mockedUser1);
            userReaderService.Setup(x => x.ReadUser(1)).Returns(mockedUser2);
            userReaderService.Setup(x => x.ReadUser(2)).Returns(mockedUser3);
            List<User> expectedResult = [mockedUser1, mockedUser2, mockedUser3];

            UserRegistrationService userRegistrationService = new(userReaderService.Object);
            List<User> actualResult = userRegistrationService.RegisterUsers(3);

            Assert.AreEqual(expectedResult[0], actualResult[0]);
            Assert.AreEqual(expectedResult[1], actualResult[1]);
            Assert.AreEqual(expectedResult[2], actualResult[2]);
        }
    }


}