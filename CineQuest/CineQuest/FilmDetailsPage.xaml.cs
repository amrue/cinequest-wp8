using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace CineQuest
{
    public partial class FilmDetailsPage : PhoneApplicationPage
    {
        /* Constructor */
        public FilmDetailsPage()
        {
            InitializeComponent();
        }

        /* When page is navigated to set data context to selected item in list */
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = 0; //setting to 0 just to test if it works...
                //need to find out how to obtain selected Index from panorama
                //int index = int.Parse(selectedIndex);
                DataContext = App.ViewModel.Items[index];
            }
        }
    }
}