using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
namespace CineQuest
{
    public partial class FilmDetailsPanorama : PhoneApplicationPage
    {
        public FilmDetailsPanorama()
        {
            InitializeComponent();
        }

        /* When page is navigated to set data context to selected item in list */
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex;
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = 0;
                //int index = App.ViewModel.Items.IndexOf(selectedIndex as ItemViewModel);
               // int index = Int32.Parse(selectedIndex);// int.Parse(selectedIndex); //for testing throws error need to look into it
                DataContext = App.ViewModel.Items[index];
                //System.Diagnostics.Debug.WriteLine("test"+DataContext);

            }
        }

        private void addSchedule(object sender, RoutedEventArgs e)
        {
            SaveAppointmentTask saveAppointmentTask = new SaveAppointmentTask();
            //String test = ListTitle.Text;
            saveAppointmentTask.StartTime = DateTime.Now.AddHours(2);
            saveAppointmentTask.EndTime = DateTime.Now.AddHours(3); // == startTime + duration;
            saveAppointmentTask.Subject = (String)ListTitle.Title ;
            saveAppointmentTask.Location = "CineQuest";
            saveAppointmentTask.Details = "Appointment details";
            saveAppointmentTask.IsAllDayEvent = false;
            saveAppointmentTask.Reminder = Reminder.FifteenMinutes;
            saveAppointmentTask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.Busy;
            saveAppointmentTask.Show();
        }
    }
}