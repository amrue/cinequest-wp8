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
    public class Schedule
    {
        [XmlElementAttribute("id")]
        public string id { get; set; }
        
        [XmlElementAttribute("program_item_id")]
        public string programItemId { get; set; }
        
        [XmlElementAttribute("start_time")]
        public string startTime { get; set; }

        [XmlElementAttribute("end_time")]
        public string endTime { get; set; }

        [XmlElementAttribute("venue")]
        public string venue { get; set; }
    }
}
