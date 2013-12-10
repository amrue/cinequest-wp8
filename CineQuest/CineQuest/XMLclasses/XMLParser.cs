using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Xml.Serialization; //add referance
using System.Xml.Linq;
using System.Windows;
using System.Windows.Resources;
using System.IO;//add referance

namespace CineQuest.XMLclasses
{
    class XMLParser
    {
        private string _dataToParse;
        private static XMLParser _instance;

        private ObservableCollection<Show> _showCollection;
        private ObservableCollection<CustomProperty> _customPropertyCollection;

        private XMLParser()
        {

        }

        public static XMLParser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new XMLParser();
                }
                return _instance;
            }
        }


        public string DataToParse
        {
            get
            {
                return _dataToParse;
            }
            set
            {
                this._dataToParse = value;
            }
        }

        public ObservableCollection<Show> ShowCollection
        {
            get
            {
                return _showCollection;
            }
            set
            {
                _showCollection = value;
            }
        }

        public ObservableCollection<CustomProperty> CustomPropertyCollection
        {
            get
            {
                return _customPropertyCollection;
            }
            set
            {
                _customPropertyCollection = value;
            }
        }


        public ObservableCollection<Show> ParseShowData()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Festival));
                XDocument document = XDocument.Parse(this._dataToParse);

                Festival showXML = (Festival)serializer.Deserialize(document.CreateReader());
                
                this._showCollection = showXML.showList;


                return this._showCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ParseShowData()::" + ex.Message);
            }

            return null;
        }

        public ObservableCollection<CustomProperty> ParseCustomPropertyData()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Show));
                XDocument document = XDocument.Parse(this._dataToParse);

                Show rootXML = (Show)serializer.Deserialize(document.CreateReader());

                this._customPropertyCollection = rootXML.customPropertyList;

                return rootXML.customPropertyList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ParseCustomPropertyData()::" + ex.Message);
            }

            return null;
        }
    }
}
