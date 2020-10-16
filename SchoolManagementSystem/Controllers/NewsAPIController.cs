using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
//using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Nancy.Json;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Xml.Linq;

using System.Text.Json.Serialization;

namespace SchoolManagementSystem.Controllers
{
    public class NewsAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> NewsAPI()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://newsapi.org/v2/top-headlines?country=ca&category=technology&apiKey=9c3bc0733617451fbff5f91e151dbd87&totalResults=30");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var output = JsonConvert.SerializeObject(apiResponse);
            List<Root> deserialized = JsonConvert.DeserializeObject<List<Root>>(output);
            //Root root = (Root)deserialized;
            return View(deserialized);
        }
    }
}
