/** Code for the UI layout of the main film page. Lists alphabetically and clicking on a film opens
 * the film detail page. No class manipulation is done here, just linking classes to UI elements.
 */

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
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace CineQuest
{
    public partial class FilmMainPage : PhoneApplicationPage
    {
        /* Constructor */
        public FilmMainPage()
        {
            InitializeComponent();

            /* Set the data context of the listbox control to the sample data */
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(FilmMainPage_Loaded);

        }

        /* Each button in the ApplicationBar of the screen gets it's own click listener. Currently
         * they redirect to the other pages.
         */
        void eventsButton_Click(object sender, EventArgs e)
        {
            /* Navigate to Events page */
            NavigationService.Navigate(new Uri("/EventsMainPage.xaml", UriKind.Relative));
        }

        void forumsButton_Click(object sender, EventArgs e)
        {
            /* Navigate to Forums page */
            NavigationService.Navigate(new Uri("/ForumsMainPage.xaml", UriKind.Relative));
        }

        void dvdsButton_Click(object sender, EventArgs e)
        {
            /* Navigate to DVD page */
            NavigationService.Navigate(new Uri("/DVDMainPage.xaml", UriKind.Relative));
        }

        void scheduleButton_Click(object sender, EventArgs e)
        {
            /* Navigate to Schedule page */
            NavigationService.Navigate(new Uri("/ScheduleMainPage.xaml", UriKind.Relative));
        }

        /* Handle selection changed on ListBox */
        private void FilmList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //I changed selected index to selectedItem and now it seems navigation to filmslistpage does not work
            /* If selected index is -1 (no selection) do nothing */
            if (FilmList.SelectedItem == null)
                return;

            /* Navigate to the new page */
            NavigationService.Navigate(new Uri("/FilmDetailsPage.xaml?selectedItem=" + FilmList.SelectedItem, UriKind.Relative));

            /* Reset selected index to -1 (no selection) */
            FilmList.SelectedItem = null;
        }
        
        /* Load data for the ViewModel Items */
        private void FilmMainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

        }
    }
}