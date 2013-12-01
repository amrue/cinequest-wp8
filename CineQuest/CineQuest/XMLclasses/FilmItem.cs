/** Each film object gets put here to populate the UI elements
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
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace CineQuest
{
    /* Fills the filmlist */
    public class FilmItem:IComparable<FilmItem>
    {
        ArrayOfShows arrayOfShows = new ArrayOfShows();

        public String Name { get; set; }
        public String ShortDescription { get; set; }

        public FilmItem()
        {
            
        }

        /* Custom CompareTo so filmitems are sortable by film title */
        public int CompareTo(FilmItem other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
