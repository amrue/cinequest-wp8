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
            //e.AddedItems.IndexOf(FilmList.SelectedItem)

            if (FilmList.SelectedItem == null)
                return;

            int selectedIndex = FilmList.ItemsSource.IndexOf(FilmList.SelectedItem);
            /* Navigate to the new page */
            //NavigationService.Navigate(new Uri("/FilmDetailsPanorama.xaml?selectedItem=" + FilmList.SelectedItem, UriKind.Relative));
            NavigationService.Navigate(new Uri("/FilmDetailsPanorama.xaml?selectedIndex=" + selectedIndex, UriKind.Relative)); //IT WORKS!!! HOORAHHH

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

        private void OnSessionStateChanged(object sender, Facebook.Client.Controls.SessionStateChangedEventArgs e)
        {

            if (e.SessionState == Facebook.Client.Controls.FacebookSessionState.Opened)
            {
                this.welcomeMessage.Visibility = Visibility.Visible;
                this.shareButton.Visibility = Visibility.Visible;
            }

            else if (e.SessionState == Facebook.Client.Controls.FacebookSessionState.Closed) {
                this.welcomeMessage.Visibility = Visibility.Collapsed;
                this.shareButton.Visibility = Visibility.Collapsed;

                   
            }
        }

        private async void PublishStory() {
            await this.loginButton.RequestNewPermissions("publish_stream");

            var facebookClient = new Facebook.FacebookClient(this.loginButton.CurrentSession.AccessToken);

            var postParams = new

            {
                name = "Facebook SDK for .NET",
                caption = "Build great social apps and get more installs.",
                description = "The Facebook SDK for .NET makes it easier and faster to develop Facebook integrated .NET apps.",
                link = "http://facebooksdk.net/",
                picture = "http://facebooksdk.net/assets/img/logo75x75.png" 
            };

            try
            {
                dynamic fbPostTaskResult = await facebookClient.PostTaskAsync("/me/feed", postParams);
                var result = (IDictionary<string, object>)fbPostTaskResult;

                Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show("Posted Open Graph Action, id: " + (string)result["id"], "Result", MessageBoxButton.OK);
                });
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show("Exception during post: " + ex.Message, "Error", MessageBoxButton.OK);
                });
            }

        }

        private void OnShareButtonClick(object sender, RoutedEventArgs e) {
            this.PublishStory();
        }
    }
}