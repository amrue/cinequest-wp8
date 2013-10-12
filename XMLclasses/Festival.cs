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

namespace CineQuest
{
    //[Serializable()]
    //This is the main head of the XML data object
    [System.Xml.Serialization.XmlRoot("festival")]
    public class Festival
    {
        [XmlElement("program_items")]
        public ProgramItems programItems  { get; set; }

        [XmlElement("films")]
        public Films films { get; set; }

        [XmlElement("schedules")]
        public Schedules schedules { get; set; }

        [XmlElement("venue_Locations")]
        public VenueLocations venueLocations { get; set; }
    }
}
