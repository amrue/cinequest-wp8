/** The whole enchilada. A this is what holds the parsed XML data. There are [Xml] tags because originally
 * this was going to be populated by deserializing the XML data, easier said then done; deserialization is tricky
 * and very poorly documented. The parser now takes care of that, but if you figure it out it's much faster than
 * using the parser (if not as customizable).
 */

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
using System.Runtime.Serialization;

namespace CineQuest
{
    /**
     * This is the main head of the XML data object
     */
    [XmlRoot("ATSFeed")]
    public class Festival
    {
        [XmlElement("ArrayOfShows")]
        public ArrayOfShows arrayOfShows  { get; set; }


        public Festival()
        {
            arrayOfShows = new ArrayOfShows();
        }
    }

    /**
     * List of films to vary size automatically
     */
    public class ArrayOfShows
    {
        [XmlArray("ArrayOfShows")]
        [XmlArrayItem("Show", typeof(ArrayOfShows))]
        public List<Show> showList { get; set; }

        public ArrayOfShows()
        {
            showList = new List<Show>();
        }
    }

    /**
     * Individual film object, holds all info from XML doc
     */
    public class Show
    {

        [XmlElement("ID")]
        public string ID { get; set; }

        [XmlElement("ExternalID")]
        public string ExternalID { get; set; }

        [XmlElement("OrgID")]
        public string OrgID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Duration")]
        public string Duration { get; set; }

        [XmlElement("ShortDescription")]
        public string ShortDescription { get; set; }

        [XmlElement("ThumbImage")]
        public string ThumbImage { get; set; }

        [XmlElement("EventImage")]
        public string EventImage { get; set; }

        [XmlElement("InfoLink")]
        public string InfoLink { get; set; }

        public List<String> CustomProperty { get; set; }
    }




}
