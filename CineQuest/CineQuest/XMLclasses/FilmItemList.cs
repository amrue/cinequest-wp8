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
        public FilmItemList(Festival f)
        {
            festival = f;
        }

        public void populateList()
        {
            Itemlist = new List<FilmItem>();

            foreach (Film film in festival.films.filmsList)
            {
                FilmItem temp = new FilmItem();
                temp.id = film.id;
                temp.title = film.title;
                temp.description = film.description;
                temp.tagline = film.tagline;
                temp.genre = film.genre;
                temp.imageURL = film.imageURL;
                temp.director = film.director;
                temp.producer = film.producer;
                temp.cinematographer = film.cinematographer;
                temp.editor = film.editor;
                temp.cast = film.cast;
                temp.country = film.country;
                temp.language = film.language;
                temp.filminfo = film.film_info;
                temp.showtimes = film.show_times;
                Itemlist.Add(temp);
            }

            Itemlist.Sort();
        }
    }
}
