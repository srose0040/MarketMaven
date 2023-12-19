using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockMarketWatcherBackend.Controllers
{
    [Route("[controller]")] // Removed "api/" so the route is just /stock
    [ApiController]
    public class StockController : ControllerBase
    {
    }
}
