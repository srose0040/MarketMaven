using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace StockMarketWatcherBackend.Controllers
{
    [Route("[controller]")] // Removed "api/" so the route is just /stock
    [ApiController]
    public class StockController : ControllerBase
    {
        static public List<Stock> stocks = new List<Stock>()
        {
            new Stock(
                    "MSFT",
                    300,
                    233,
                    new List<float>{0,1,0,3,0,5,0,2,25}
                ) // For testing purposes
        };
    }
}
