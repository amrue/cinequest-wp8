﻿/** Where the magic happens. This gets the XML file, gets it parsed, loads the data, then populates
 * the UI with the new data.
 */

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;
using CineQuest.XMLclasses;


namespace CineQuest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            /* Connects to cinequest to get the XML file for the films */
            WebClient webclient = new WebClient();
            webclient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webclient_DownloadStringCompleted);
            webclient.DownloadStringAsync(new Uri("http://mobile.cinequest.org/mobileCQ.php?type=festival"));
        }

        private void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs data)
        {
            if (data.Error != null)
            {
                MessageBox.Show("error");
            }

            Festival festival = null;
            XmlReader reader = null;
            FestivalParser parser = new FestivalParser();
            try
            {
                parser = new FestivalParser();
                festival = parser.Parse(data.Result);

                FilmItemList list = new FilmItemList(festival);
                list.populateList();

                foreach (FilmItem item in list.Itemlist)
                {
                    /* connect films in ItemList to UI elements */
                    this.Items.Add(new ItemViewModel() {
                        IVMid = item.id,
                        IVMtitle = item.title,
                        IVMdescription = item.description,
                        IVMtagline = item.tagline,
                        IVMgenre = item.genre,
                        IVMimageURL = item.imageURL,
                        IVMdirector = item.director,
                        IVMproducer = item.producer,
                        IVMcinematographer = item.cinematographer,
                        IVMeditor = item.editor,
                        IVMcast = item.cast,
                        IVMcountry = item.country,
                        IVMlanguage = item.language,
                        IVMfilminfo = item.filminfo,
                        IVMshowtimes = item.showtimes
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString(), "...hit the fan...", MessageBoxButton.OK);
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            /* house keeping */
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    /* this should keep it from loading every time but doesn't */
                    this.IsDataLoaded = true;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}