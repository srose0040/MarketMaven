﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace StockMarketWatcherBackend.Controllers
{
    [Route("[controller]")] // Removed "api/" so the route is just /stock
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly string token = "pk_ba830850a33948b4b3a888ac2a569d98";


       
        static public List<Stock> stocks = new List<Stock>()
        {

        };

        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            // Grab latest stock info 

            foreach (var stock in stocks)
            {
                float price = GetPrice(stock.Name); // Sending request to get price for stock

                if (price < 0f)
                {
                    price = 0;
                }

                stock.PriceNow = price;
               
            }

            return stocks;
        }

        [HttpGet("{id}")]
        public ActionResult<Stock> Find(string id)
        {
            // Get stock from watchlist by their name 
            int index = stocks.FindIndex(x => x.Name == id);

            if (index == -1)
            {
                return NotFound();
            }

            return Ok(stocks[index]);
        }

        private void GetHistData(Stock stock)
        {

            string url = String.Format("https://cloud.iexapis.com/v1/stock/{0}/chart/1m?token={1}", stock.Name, token);

            var histData = GetData(url);

            JArray jsonHist = JArray.Parse(histData);

            foreach (JObject item in jsonHist)
            {
                float tmp = (float)item["open"];
                stock.Diff.Add(tmp);
            }

        }

        [HttpPost]
        public IActionResult Create(Param param)
        {
            // Get stock from watchlist by their name 
            int index = stocks.FindIndex(x => x.Name == param.nameInp);

            if (index > -1) // If we have returned a duplicate entry
            {
                return BadRequest();
            }

            float price = GetPrice(param.nameInp);
            if (price < 0) 
            {
                return BadRequest();
            }

            // Retrive stock historical data to add to watchlist
            Stock newStock = new Stock();
            newStock.Diff = new List<float>();
            newStock.Name = param.nameInp;
            newStock.PriceNow = price;
            GetHistData(newStock);

            stocks.Add(newStock);

            return Ok();

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

        private float GetPrice(string stock)
        {
          
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

    public class Param // Class for the API
    {
        public string nameInp { get; set; }
    }

}