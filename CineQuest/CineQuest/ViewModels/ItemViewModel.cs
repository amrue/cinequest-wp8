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
        private string _IVMName;
        /// <summary>
        /// Name
        /// </summary>
        /// <returns></returns>
        public string IVMName
        {
            get
            {
                return _IVMName;
            }
            set
            {
                if (value != _IVMName)
                {
                    _IVMName = value;
                    NotifyPropertyChanged("IVMName");
                }
            }
        }

        private string _IVMShortDescription;
        /// <summary>
        /// ShortDescription
        /// </summary>
        /// <returns></returns>
        public string IVMShortDescription
        {
            get
            {
                return _IVMShortDescription;
            }
            set
            {
                if (value != _IVMShortDescription)
                {
                    _IVMShortDescription = value;
                    NotifyPropertyChanged("IVMShortDescription");
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