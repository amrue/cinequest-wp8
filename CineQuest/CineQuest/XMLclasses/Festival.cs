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
    [XmlRoot("festival")]
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

        public Festival()
        {
            films = new Films();
            schedules = new Schedules();
            programItems = new ProgramItems();
            venueLocations = new VenueLocations();
        }
    }

    /**
     * List of films to vary size automatically
     */
    public class Films
    {
        [XmlArray("films")]
        [XmlArrayItem("film", typeof(Film))]
        public List<Film> filmsList { get; set; }

        public Films()
        {
            filmsList = new List<Film>();
        }
    }

    /**
     * Individual film object, holds all info from XML doc
     */
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

        public List<String> show_times { get; set; }
    }

    /**
     * List of schedules
     */
    public class Schedules
    {
        [XmlArray("schedules")]
        [XmlArrayItem("schedule", typeof(Schedule))]
        public List<Schedule> schedulesList { get; set; }

        public Schedules()
        {
            schedulesList = new List<Schedule>();
        }
    }

    /**
     * Schedule object
    */
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

    /**
     * List of program items
     */
    [XmlRoot(ElementName = "program_items")]
    public class ProgramItems
    {
        [XmlArray("program_items")]
        [XmlArrayItem("program_item", typeof(ProgramItem))]
        public List<ProgramItem> programItems { get; set; }

        public ProgramItems()
        {
            programItems = new List<ProgramItem>();
        }
    }

    /**
     * ProgramItem holds details
     */
    public class ProgramItem
    {
        [XmlElementAttribute("id")]
        public string id { get; set; }

        [XmlElementAttribute("title")]
        public string title { get; set; }

        [XmlElementAttribute("description")]
        public string description { get; set; }

        public List<int> films { get; set; }

        public ProgramItem()
        {
            films = new List<int>();
        }
    }

    /**
     * Venue locations for program items
     */
    [XmlRoot(ElementName = "venu_locations")]
    public class VenueLocations
    {
        [XmlArray("venue_locations")]
        [XmlArrayItem("venue_location", typeof(VenueLocation))]
        public List<VenueLocation> venueLocationList { get; set; }

        public VenueLocations()
        {
            venueLocationList = new List<VenueLocation>();
        }
    }

    /**
     * Venue location information
     */
    public class VenueLocation
    {
        [XmlElementAttribute("venue")]
        public string venue { get; set; }

        [XmlElementAttribute("description")]
        public string description { get; set; }

        [XmlElementAttribute("location")]
        public string location { get; set; }

        [XmlElementAttribute("imageURL")]
        public string imageURL { get; set; }

        [XmlElementAttribute("directionsURL")]
        public string directionsURL { get; set; }
    }
}
