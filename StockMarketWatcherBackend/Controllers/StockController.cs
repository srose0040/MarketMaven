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

        private float GetPrice(string stock)
        {
            string token = "pk_ba830850a33948b4b3a888ac2a569d98";

            
            string url = String.Format("https://cloud.iexapis.com/v1/stock/{0}/quote?token={1}", stock, token);

            // Search for stocks price from api
            var result = GetData(url);

            if (result == null)
            {
                return -1;
            }

            JObject json = JObject.Parse(result);

            if (json["latestPrice"] == null)
            {
                return -1;
            }

            float price = (float)json["latestPrice"];
            return price;
        }
    }

}
