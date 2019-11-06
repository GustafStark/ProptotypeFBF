using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using WebApplication1.Models;
using System.Xml.Serialization;
using System.IO;

namespace WebApplication1.Controllers
{
    public class BGGController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Test = GetXmlFile();
            return View("BGGList");
        }

        private GamesModelData GetXmlFile()
        {
            List<string> xTemp = new List<string>();
     
            string URLString = "https://api.geekdo.com/xmlapi2/collection?username=Bleadin";
            //string URLString = "https://api.geekdo.com/xmlapi2/collection?username=Bleadin&excludesubtype=boardgameexpansion";
            GamesModelData gamesModel = new GamesModelData();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(URLString);
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlDocument.WriteTo(xmlTextWriter);
            string Tag = stringWriter.ToString();

            var serializer = new XmlSerializer(typeof(GamesModelData), new XmlRootAttribute("items"));
            using (var stringReader = new StringReader(Tag))
            using (var reader = XmlReader.Create(stringReader))
            {
                var result = (GamesModelData)serializer.Deserialize(reader);
                if (result == null) return new GamesModelData();
                return result;

            }

        }

    }
}