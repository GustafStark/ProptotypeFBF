using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string Table = "</table>";
            var Client = new WebClient();
            var data = Client.DownloadString("https://boardgamegeek.com/browse/boardgame");
            int From = data.IndexOf("<table");
            int To = data.IndexOf(Table);
            string Result = data.Substring(From, To - From) + Table;

            ViewBag.Data = Result;
            ViewBag.WhatImLookingFor = GetDiv(Result);

            return View();
        }

        private dynamic GetDiv(string result)
        {
            List<object> test = new List<object>(); ;
            var m1 = Regex.Matches(result,"collection_objectname");

            int collectionObjNameIndex = result.IndexOf("collection_objectname");
    
            if (collectionObjNameIndex != 0)
            {
                int NameIndex = result.IndexOf("</a>",collectionObjNameIndex);
                return result.Substring(NameIndex - 10, 10);
            }


            return m1.ToArray().Length;
        }

        //public dynamic GetDiv(string MyHTML, int Count = 0, int Index = 1)
        //{
        //    foreach(HtmlNode)
        //    {

        //    }


        //    if (Count >= 100) return Count;
        //    int IndexOf = MyHTML.IndexOf("</tr>", Index);
        //    return Count = GetDiv(MyHTML, Count + 1, IndexOf + 1);
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
