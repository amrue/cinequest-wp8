/** Holds all the FilmItems as well as the festival object that populates it.
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
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CineQuest
{
    /* This class creates a list of filmitems to populate the film page. */
    public class FilmItemList
    {
        public List<FilmItem> Itemlist;
        Festival festival;
        Show film;
        public FilmItemList(Show s)
        {
            film = s;
        }

        public void populateList()
        {
            Itemlist = new List<FilmItem>();

            foreach (Show show in festival.showList)
            {
                FilmItem temp = new FilmItem();
                temp.Name = show.Name;
                temp.ShortDescription = show.ShortDescription;
                
                Itemlist.Add(temp);
            }

            Itemlist.Sort();
        }
    }
}
