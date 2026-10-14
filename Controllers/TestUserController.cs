using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("GetConnection")]
        public DateTime GetDateTime()
        {
            return _dataContextDapper.LoadSingleData<DateTime>("SELECT GETDATE()");
        }


        [HttpGet("GetUser/{userName}")]
        public string[] GetUser(string userName)
        {
            string[] usersArray =
            {
                "User1",
                "User2",
                userName
            };
            return usersArray;
        }
    }
}
