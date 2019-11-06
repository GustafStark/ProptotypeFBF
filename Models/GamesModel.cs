using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebApplication1.Models
{
    public class GamesModel
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "yearpublished")]
        public string YearPublished { get; set; }

        [XmlElement(ElementName = "image")]
        public string Image { get; set; }

        [XmlElement(ElementName = "thumbnail")]
        public string Thumbnail { get; set; }

    }
    [XmlTypeAttribute(AnonymousType = true)]
    public class GamesModelData
    {
        [XmlElement("item")]
        public List<GamesModel> GamesModels { get; set; }
        public GamesModelData()
        {
            GamesModels = new List<GamesModel>();
        }
    }
}
//private string GetGamesModelType(string ReaderName)
//{
//    switch (ReaderName)
//    {
//        case "name":
//            break;
//        case "yearpublished":
//            break;
//        case "image":
//            break;
//        case "thumbnail":
//            break;
//        default:
//            break;
//    }
//    return null;
//}