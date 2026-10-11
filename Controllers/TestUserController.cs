using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestUserController: ControllerBase
    {
        [HttpGet("GetUser/{userName}")]
        public string[] GetUser(string userName)
        {
            string[] usersArray = new string[]
            {
                "User1",
                "User2",
                userName
            };
            return usersArray;
        }
    }
}
