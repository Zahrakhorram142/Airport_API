using Microsoft.AspNetCore.Mvc;

namespace Airport_API.Controllers
{
    [Route("api/V{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseController : Controller

    {
        //Shared Code
        
    }
}
