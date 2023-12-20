using Bank_DotnetCore.Models;
using Bank_DotnetCore.Services;
using NUnit.Framework;
using Moq;
using Bank_DotnetCore.Repos;

namespace AuthenticationTest
{
    [TestFixture]
    public class Tests
    {
        private UserService userService;
        private Mock<IUserRepo> _mockRepo; 

        [SetUp]
        public void Init()
        {
            //_mockRepo = new Mock<UserRepo>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        //[TestCase(3, "SateeshG")]
        //[TestCase(0, "NotFound")]
        //public void GetNameById(int id, string ExpectedResult)
        //{
        //    _mockRepo = new Mock<IUserRepo>(MockBehavior.Strict);
        //    //_mockRepo.Setup(p => p.getNameById(3)).Returns(Task < new User { Id = 3, Address = "", Email = "", FirstName = "", LastName = "", Password = "", PhoneNumber = "" } >);
        //    _mockRepo.Setup(p => p.GetNameById(id)).Returns(ExpectedResult);
        //    userService = new UserService(_mockRepo.Object);
        //    var testResult = userService.GetNameById(id);
        //    Console.WriteLine(testResult);
        //    Assert.That(testResult, Is.EqualTo(ExpectedResult));
        //    _mockRepo.VerifyAll();
        //    //Assert.AreEqual(3, result.Id);
        //    //_mockRepo.Verify(e => e.ExecuteAsync(It.IsAny<DecisionTriggerModel>()), Times.Once);
        //}
    }
}