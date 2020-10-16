using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    //public class NewsAPI
    //{
    //    public string publishedAt { get; set; }
    //    public string author { get; set; }
    //    public string title { get; set; }
    //    public string description { get; set; }
    //    public string url { get; set; }
    //    public string urlToImage { get; set; }
    //    public string content { get; set; }

    //}


    public class Source
    {
        public object id { get; set; }
        public string name { get; set; }
    }

    public class Root
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }


}
