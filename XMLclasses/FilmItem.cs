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

namespace CineQuest
{
    //used by FilmItemList to populate the film page
    public class FilmItem
    {
        Films films = new Films();

        public String lineone { get; set; }
        public String linetwo { get; set; }
        public String linethree { get; set; }
        public String linefour { get; set; }

        public FilmItem()
        {
            
        }
    }
}
