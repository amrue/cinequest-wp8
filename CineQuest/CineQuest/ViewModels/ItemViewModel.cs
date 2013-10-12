/** This is where the ViewModel pulls to populate the UI elements. It has to be synced 
 * with the data in the festival object.
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace CineQuest
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string _IVMid;
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        public string IVMid
        {
            get
            {
                return _IVMid;
            }
            set
            {
                if (value != _IVMid)
                {
                    _IVMid = value;
                    NotifyPropertyChanged("IVMid");
                }
            }
        }

        private string _IVMtitle;
        /// <summary>
        /// title
        /// </summary>
        /// <returns></returns>
        public string IVMtitle
        {
            get
            {
                return _IVMtitle;
            }
            set
            {
                if (value != _IVMtitle)
                {
                    _IVMtitle = value;
                    NotifyPropertyChanged("IVMtitle");
                }
            }
        }

        private string _IVMdescription;
        /// <summary>
        /// description
        /// </summary>
        /// <returns></returns>
        public string IVMdescription
        {
            get
            {
                return _IVMdescription;
            }
            set
            {
                if (value != _IVMdescription)
                {
                    _IVMdescription = value;
                    NotifyPropertyChanged("IVMdescription");
                }
            }
        }

        private string _IVMtagline;
        /// <summary>
        /// tagline
        /// </summary>
        /// <returns></returns>
        public string IVMtagline
        {
            get
            {
                return _IVMtagline;
            }
            set
            {
                if (value != _IVMtagline)
                {
                    _IVMtagline = value;
                    NotifyPropertyChanged("IVMtagline");
                }
            }
        }

        private string _IVMgenre;
        /// <summary>
        /// genre.
        /// </summary>
        /// <returns></returns>
        public string IVMgenre
        {
            get
            {
                return _IVMgenre;
            }
            set
            {
                if (value != _IVMgenre)
                {
                    _IVMgenre = value;
                    NotifyPropertyChanged("IVMgenre");
                }
            }
        }

        private string _IVMimageURL;
        /// <summary>
        /// imageURL
        /// </summary>
        /// <returns></returns>
        public string IVMimageURL
        {
            get
            {
                return _IVMimageURL;
            }
            set
            {
                if (value != _IVMimageURL)
                {
                    _IVMimageURL = value;
                    NotifyPropertyChanged("IVMimageURL");
                }
            }
        }

        private string _IVMdirector;
        /// <summary>
        /// director
        /// </summary>
        /// <returns></returns>
        public string IVMdirector
        {
            get
            {
                return _IVMdirector;
            }
            set
            {
                if (value != _IVMdirector)
                {
                    _IVMdirector = value;
                    NotifyPropertyChanged("IVMdirector");
                }
            }
        }

        private string _IVMproducer;
        /// <summary>
        /// producer
        /// </summary>
        /// <returns></returns>
        public string IVMproducer
        {
            get
            {
                return _IVMproducer;
            }
            set
            {
                if (value != _IVMproducer)
                {
                    _IVMproducer = value;
                    NotifyPropertyChanged("IVMproducer");
                }
            }
        }

        private string _IVMcinematographer;
        /// <summary>
        /// cinematographer
        /// </summary>
        /// <returns></returns>
        public string IVMcinematographer
        {
            get
            {
                return _IVMcinematographer;
            }
            set
            {
                if (value != _IVMcinematographer)
                {
                    _IVMcinematographer = value;
                    NotifyPropertyChanged("IVMcinematographer");
                }
            }
        }

        private string _IVMeditor;
        /// <summary>
        /// editor
        /// </summary>
        /// <returns></returns>
        public string IVMeditor
        {
            get
            {
                return _IVMeditor;
            }
            set
            {
                if (value != _IVMeditor)
                {
                    _IVMeditor = value;
                    NotifyPropertyChanged("IVMeditor");
                }
            }
        }

        private string _IVMcast;
        /// <summary>
        /// cast
        /// </summary>
        /// <returns></returns>
        public string IVMcast
        {
            get
            {
                return _IVMcast;
            }
            set
            {
                if (value != _IVMcast)
                {
                    _IVMcast = value;
                    NotifyPropertyChanged("IVMcast");
                }
            }
        }

        private string _IVMcountry;
        /// <summary>
        /// country
        /// </summary>
        /// <returns></returns>
        public string IVMcountry
        {
            get
            {
                return _IVMcountry;
            }
            set
            {
                if (value != _IVMcountry)
                {
                    _IVMcountry = value;
                    NotifyPropertyChanged("IVMcountry");
                }
            }
        }

        private string _IVMlanguage;
        /// <summary>
        /// language
        /// </summary>
        /// <returns></returns>
        public string IVMlanguage
        {
            get
            {
                return _IVMlanguage;
            }
            set
            {
                if (value != _IVMlanguage)
                {
                    _IVMlanguage = value;
                    NotifyPropertyChanged("IVMlanguage");
                }
            }
        }

        private string _IVMfilminfo;
        /// <summary>
        /// film info
        /// </summary>
        /// <returns></returns>
        public string IVMfilminfo
        {
            get
            {
                return _IVMfilminfo;
            }
            set
            {
                if (value != _IVMfilminfo)
                {
                    _IVMfilminfo = value;
                    NotifyPropertyChanged("IVMfilminfo");
                }
            }
        }

        private List<String> _IVMshowtimes;
        /// <summary>
        /// showtimes + venue
        /// </summary>
        /// <returns></returns>
        public List<String> IVMshowtimes
        {
            get
            {
                return _IVMshowtimes;
            }
            set
            {
                if (value != _IVMshowtimes)
                {
                    _IVMshowtimes = value;
                    NotifyPropertyChanged("IVMshowtimes");
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