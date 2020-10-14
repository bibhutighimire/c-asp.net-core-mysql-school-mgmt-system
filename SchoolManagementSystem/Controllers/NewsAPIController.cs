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
            List<NewsAPI> news = new List<NewsAPI>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://newsapi.org/v2/top-headlines?country=ca&category=technology&apiKey=9c3bc0733617451fbff5f91e151dbd87&totalResults=30"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //string output = JsonConvert.SerializeObject(apiResponse, Formatting.Indented);
                     news = JsonConvert.DeserializeObject<List<NewsAPI>>(apiResponse);
                }
            }
            return View(news);
        }

        //public ActionResult NewsAPI()
        //{
        //    List<NewsAPI> news = new List<NewsAPI>();
        //    var client = new WebClient();
        //    var text = client.DownloadString("http://newsapi.org/v2/top-headlines?country=ca&category=technology&apiKey=9c3bc0733617451fbff5f91e151dbd87&totalResults=30");

        //    news = JsonConvert.DeserializeObject<List<NewsAPI>>(text);

        //    return View(news);
        //}
    }
}
