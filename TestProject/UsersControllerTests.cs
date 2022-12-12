using CodecoolAdvanced.Controller;
using NSubstitute;
using NUnit.Framework;

namespace TestProject
{
    public class UsersControllerTests
    {

        private UsersController _usersController;
        private readonly CodecoolContext _context = Substitute.For<CodecoolContext>();
 
        public UsersControllerTests()
        {
            _usersController = new UsersController(_context);
        }

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}