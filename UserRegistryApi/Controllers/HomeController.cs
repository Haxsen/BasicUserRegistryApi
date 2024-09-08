using Microsoft.AspNetCore.Mvc;

namespace UserRegistryApi.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return $"Welcome to the User Registry API!, ENV1: {Environment.GetEnvironmentVariable("ENV1")}, DBENV: {Environment.GetEnvironmentVariable("DATABASE_URL")}";
        }
    }
}
