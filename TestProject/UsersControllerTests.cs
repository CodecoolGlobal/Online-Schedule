using CodecoolAdvanced.Controller;
using CodecoolAdvanced.Model;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

/*namespace TestProject
{
    /*public class UsersControllerTests
    {
  
        private readonly UsersController _usersController;
        private readonly CodecoolContext _context = Substitute.For<CodecoolContext>(DbContextOptions < CodecoolContext > options);

        public UsersControllerTests()
        {
            _usersController = new UsersController(_context);
        }

        [Fact]

        public async Task GetStudent_By_Id_If_Exist()
        {
            var studentID = 1;
            string studentName = "kata";
            Student student = new Student
            {
                ID = studentID,
                Name = studentName
            };
            _usersController.GetStudentById(studentID).Returns(student);
            
            Student student2 = await _usersController.GetStudentById(studentID);

            Assert.Equal(student2.ID, studentID);
            Assert.Equal(student2.Name, studentName);
        
        }
    }/*
}*/