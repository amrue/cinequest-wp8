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
    public class ShowParser
    {
        /* Instance fields */
        String data;
        Festival festival;
        Boolean customProp = false;

        public ShowParser()
        {
            festival = new Festival();
        }

        public Festival Parse(String aData)
        {
            data = aData;

            XmlReader reader = XmlReader.Create(new StringReader(data));
            /* jump to 'ArrayOfShows' section */
            reader.ReadToFollowing("ArrayOfShows");
            while (reader.Read())
            {
                /** Read the shows from the xml **/
                bool inShow = false;
                /* reads in one show element at a time then adds to festival object */
                if (reader.Name == "Show")
                {
                    inShow = true;
                    Show temp = new Show();
                    String tempName = "";
                    String tempValue = "";
                    //temp.id = reader.GetAttribute(0);
                    /* cycle through xml elements to pair elements to values */
                    while (inShow && reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                tempName = reader.Name;
                                break;
                            case XmlNodeType.CDATA:
                                tempValue = reader.Value;
                                break;
                            /* add name/value pairs to film object */
                            case XmlNodeType.EndElement:
                                if (tempName == "Name")
                                    temp.Name = (string)tempValue;
                                else if (tempName == "ShortDescription")
                                    temp.ShortDescription = (string)tempValue; 
                                tempValue = "";
                                break;
                        }   //switch
                        /* at end of show element tree, add created show object to festival show list */
                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "Show")
                        {
                            inShow = false;
                            festival.arrayOfShows.showList.Add(temp);
                        }//if end of show tree
                    }//while reading show's elements
                }//if out of show tag
            }//while nothing left to read
            
            

            /* return the newly filled festival object */
            return festival;
        }//parse()
    }//class
}
