using Microsoft.AspNetCore.Mvc;

namespace Api.Bases
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}