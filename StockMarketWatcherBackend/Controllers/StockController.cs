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

    static private string GetData(string url)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";

        try
        {
            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return data;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

}
