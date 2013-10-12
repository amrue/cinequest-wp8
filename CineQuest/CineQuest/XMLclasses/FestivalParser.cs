/** Parses a passed in XML file into a festival object, then returns the object. Eats up memory by re-creating the XmlReader
 * each time rather than restarting to the beginning or reading it from top to bottom (because it was built piece-meal).
 * 
 * XML cheat sheet:
 *   <title id="0000">  elements are between the <> tags
 *                        reader.Name gets the name of the element  --  title
 *                        XmlNodeType.Element
 *                      attributes are inside the <> tags and followed by =""
 *                        reader.GetAttribute(index)  -- 0000
 *                        gotta keep track of these by knowing they layout of the XML doc and counting with zero-index
 *   <description>      values are enclosed by matching <></> tags, typically the words they enclose
 *     Words!             reader.Value
 *                        XmlNodeType.Text
 *   </description>
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
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Collections;

namespace CineQuest.XMLclasses
{
    public class FestivalParser
    {
        /* Instance fields */
        String data;
        Festival festival;

        public FestivalParser()
        {
            festival = new Festival();
        }

        public Festival Parse(String aData)
        {
            data = aData;

            XmlReader reader = XmlReader.Create(new StringReader(data));
            /* jump to 'films' section */
            reader.ReadToFollowing("films");
            while (reader.Read())
            {
                /** Read the films from the xml **/
                bool inFilm = false;
                /* reads in one film element at a time then adds to festival object */
                if (reader.Name == "film")
                {
                    inFilm = true;
                    Film temp = new Film();
                    String tempName = "";
                    String tempValue = "";
                    temp.id = reader.GetAttribute(0);
                    /* cycle through xml elements to pair elements to values */
                    while (inFilm && reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                tempName = reader.Name;
                                break;
                            case XmlNodeType.Text:
                                tempValue = reader.Value;
                                break;
                            /* add name/value pairs to film object */
                            case XmlNodeType.EndElement:
                                if (tempName == "title")
                                    temp.title = tempValue;
                                else if (tempName == "description")
                                    temp.description = tempValue;
                                else if (tempName == "tagline")
                                    temp.tagline = tempValue;
                                else if (tempName == "genre")
                                    temp.genre = tempValue;
                                else if (tempName == "imageURL")
                                    temp.imageURL = tempValue;
                                else if (tempName == "director")
                                    temp.director = tempValue;
                                else if (tempName == "producer")
                                    temp.producer = tempValue;
                                else if (tempName == "cinematographer")
                                    temp.cinematographer = tempValue;
                                else if (tempName == "editor")
                                    temp.editor = tempValue;
                                else if (tempName == "cast")
                                    temp.cast = tempValue;
                                else if (tempName == "country")
                                    temp.country = tempValue;
                                else if (tempName == "language")
                                    temp.language = tempValue;
                                else if (tempName == "film_info")
                                    temp.film_info = tempValue;
                                tempValue = "";
                                break;
                        }   //switch
                        /* at end of film element tree, add created film object to festival film list */
                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "film")
                        {
                            inFilm = false;
                            festival.films.filmsList.Add(temp);
                        }//if end of film tree
                    }//while reading film's elements
                }//if out of film tag
            }//while nothing left to read

            /* restart reader */
            reader = XmlReader.Create(new StringReader(data));
            reader.ReadToFollowing("schedules");
            while (reader.Read())
            {
                /** Read the schedules from the xml **/
                /* start reading into each schedule */
                if (reader.Name == "schedule")
                {
                    /* not used since all the schedule data is included as attributes, not a value enclosed by tags */
                    bool inSchedule = false;
                    /* start reading into list each schedule */
                    if (reader.Name == "schedule")
                    {
                        inSchedule = true;
                        Schedule temp = new Schedule();
                        temp.id = reader.GetAttribute(0);
                        temp.programItemId = reader.GetAttribute(1);
                        temp.startTime = reader.GetAttribute(2);
                        temp.endTime = reader.GetAttribute(3);
                        temp.venue = reader.GetAttribute(4);
                        festival.schedules.schedulesList.Add(temp);
                    }//if out of schedule tag
                }//if out of schedule element (kinda redundant, fix this)
            }//while out of reading schedules

            /* restart reader */
            reader = XmlReader.Create(new StringReader(data));
            /* jump to 'venue locations' section */
            reader.ReadToFollowing("venue_locations");
            while (reader.Read())
            {
                /** Read the venue locations from the xml **/
                bool inVenueLocation = false;
                /* start reading into a temp element each venue location */
                if (reader.Name == "venue_location")
                {
                    inVenueLocation = true;
                    VenueLocation temp = new VenueLocation();
                    String tempName = "";
                    String tempValue = "";
                    temp.venue = reader.GetAttribute(0);
                    /* cycle through xml elements to pair elements to values */
                    while (inVenueLocation && reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                tempName = reader.Name;
                                break;
                            case XmlNodeType.Text:
                                tempValue = reader.Value;
                                break;
                            /* add name/value pairs to venue location object */
                            case XmlNodeType.EndElement:
                                if (tempName == "description")
                                    temp.description = tempValue;
                                else if (tempName == "location")
                                    temp.location = tempValue;
                                else if (tempName == "imageURL")
                                    temp.imageURL = tempValue;
                                else if (tempName == "directionsURL")
                                    temp.directionsURL = tempValue;
                                tempValue = "";
                                break;
                        }   //switch
                        /* at end of venue location tree, add created venue location object to festival venue location list */
                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "venue_location")
                        {
                            inVenueLocation = false;
                            festival.venueLocations.venueLocationList.Add(temp);
                        }//if end of venue location tree
                    }//while reading venue location's elements
                }//if out of venue locations tag
            }//while nothing left to read

            /* restart reader */
            reader = XmlReader.Create(new StringReader(data));
            /* jump to 'program items' section */
            reader.ReadToFollowing("program_items");
            while (reader.Read())
            {
                /** Read the program items from the xml **/
                bool inProgramItem = false;
                /* start reading into list each program item */
                if (reader.Name == "program_item")
                {
                    inProgramItem = true;
                    ProgramItem temp = new ProgramItem();
                    String tempName = "";
                    String tempValue = "";
                    temp.id = reader.GetAttribute(0);
                    /* cycle through xml elements to pair elements to values */
                    while (inProgramItem && reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                tempName = reader.Name;
                                if (tempName.Equals("film"))
                                    tempValue = reader.GetAttribute(0);
                                break;
                            case XmlNodeType.Text:
                                tempValue = reader.Value;
                                break;
                            /* add name/value pairs to venue location object */
                            case XmlNodeType.EndElement:
                                if (tempName == "title")
                                    temp.title = tempValue;
                                else if (tempName == "description")
                                    temp.description = tempValue;
                                else if (tempName == "film")
                                    temp.films.Add(Convert.ToInt16(tempValue));
                                tempValue = "";
                                break;
                        }   //switch
                        /* at end of venue location tree, add created venue location object to festival venue location list */
                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "program_item")
                        {
                            inProgramItem = false;
                            festival.programItems.programItems.Add(temp);
                        }//if end of program item tree
                    }//while reading program item's elements
                }//if out of program item tag
            }//while nothing left to read

            /* return the newly filled festival object */
            return festival;
        }//parse()
    }//class
}
