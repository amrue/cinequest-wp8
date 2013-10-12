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
using System.Xml.Serialization;
using System.Collections.Generic;

namespace CineQuest
{
    public class Films
    {
        [XmlArray("films")]
        [XmlArrayItem("film", typeof(Film))]
        public List<Film> films { get; set; }

        public Films()
        {
            films = new List<Film>();
        }
    }
}
