/** Where the magic happens. This gets the XML file, gets it parsed, loads the data, then populates
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
using CineQuest.XMLclasses;
using System.Windows.Resources;
using System.IO;


namespace CineQuest
{
    public class MainViewModel : INotifyPropertyChanged
    {

        XMLParser _parser;
        StreamReader reader;

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
            webclient.DownloadStringAsync(new Uri("http://payments.cinequest.org/websales/feed.ashx?guid=70d8e056-fa45-4221-9cc7-b6dc88f62c98&showslist=true&", UriKind.Absolute));
         }
            

        private void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs webString)
        {
            if (webString.Error != null)
            {
                MessageBox.Show("error");
            }

            Show show = null;

            try
            {
                this._parser = XMLParser.Instance;
                _parser.DataToParse = webString.Result;
                _parser.ParseShowData();
                _parser.ParseCustomPropertyData();

                FilmItemList list = new FilmItemList(show);
                list.populateList();

                foreach (FilmItem item in list.Itemlist)
                {
                    /* connect films in ItemList to UI elements */
                    this.Items.Add(new ItemViewModel() {
                        IVMName = item.Name,
                        IVMShortDescription = item.ShortDescription,
                        
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