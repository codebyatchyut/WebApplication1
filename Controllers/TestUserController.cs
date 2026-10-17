using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestUserController : ControllerBase
    {
        DataContextDapper _dataContextDapper;
        public TestUserController(IConfiguration config)
        {
            _dataContextDapper = new DataContextDapper(config);
        }

        //[HttpGet("GetConnection")]
        //public DateTime GetDateTime()
        //{
        //    return _dataContextDapper.LoadSingleData<DateTime>("SELECT GETDATE()");
        //}


        //[HttpGet("GetUser/{userName}")]
        //public string[] GetUser(string userName)
        //{
        //    string[] usersArray =
        //    {
        //        "User1",
        //        "User2",
        //        userName
        //    };
        //    return usersArray;
        //}

        [HttpGet("GetUsers")]
        public IEnumerable<Models.Users> GetUsers()
        {
            string sqlCommand = @"
                                    SELECT * FROM TutorialAppSchema.Users
                                ";
           return _dataContextDapper.LoadData<Models.Users>(sqlCommand);
        }

        [HttpGet("GetUser/{UserId}")]
        public Models.Users GetUser(int UserId)
        {
            string sqlCommand = @$"
                                    SELECT * FROM TutorialAppSchema.Users WHERE UserId = {UserId}
                                ";
            return _dataContextDapper.LoadSingleData<Models.Users>(sqlCommand);
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser(Models.Users user)
        {
            string sqlCommand = @"
                                    UPDATE TutorialAppSchema.Users
                                    SET FirstName = @FirstName,
                                        LastName = @LastName,
                                        Email = @Email,
                                        Gender = @Gender,
                                        Active = @Active
                                    WHERE UserId = @UserId
                                ";
            if (_dataContextDapper.ExecuteCommand(sqlCommand, user))
            {
                return Ok();
            }
            return NotFound($"User {user.UserId} not found");
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(Dtos.UserToAddDto user)
        {
            string sqlCommand = @"
                                    INSERT INTO TutorialAppSchema.Users (FirstName, LastName, Email, Gender, Active)
                                    VALUES (@FirstName, @LastName, @Email, @Gender, @Active)
                                ";
            if (_dataContextDapper.ExecuteCommand(sqlCommand, user))
            {
                return Ok();
            }
            throw new Exception("Failed to add user");
        }
    }
}
