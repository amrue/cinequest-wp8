using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace CineQuest
{
    public class Film
    {
        [XmlElementAttribute("id")]
        public string id { get; set; }

        [XmlElement("title")]
        public string title { get; set; }

        [XmlElement("description")]
        public string description { get; set; }

        [XmlElement("tagline")]
        public string tagline { get; set; }

        [XmlElement("genre")]
        public string genre { get; set; }

        [XmlElement("imageURL")]
        public string imageURL { get; set; }

        [XmlElement("director")]
        public string director { get; set; }

        [XmlElement("producer")]
        public string producer { get; set; }

        [XmlElement("cinematographer")]
        public string cinematographer { get; set; }

        [XmlElement("editor")]
        public string editor { get; set; }

        [XmlElement("cast")]
        public string cast { get; set; }

        [XmlElement("country")]
        public string country { get; set; }

        [XmlElement("language")]
        public string language { get; set; }

        [XmlElement("film_info")]
        public string film_info { get; set; }
    }
}
