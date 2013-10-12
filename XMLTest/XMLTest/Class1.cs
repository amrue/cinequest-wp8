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
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace XMLTest
{
    public class Class1
    {
        List<String> data = new List<String>();
        public Class1()
        {
            
        }
        XDocument xdoc;
        //String text = "";
        //TextBlock myTextBlock;
        public void getData(String url, TextBlock t)
        {
            String URLString = url;
            //myTextBlock = t;
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += HttpCompleted;
            wc.DownloadStringAsync(new Uri(url), t);
        }
        private void HttpCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                XElement XmlTweet = XElement.Parse(e.Result);

              /*  listBox1.ItemsSource = from tweet in XmlTweet.Descendants("item")
                                       select new FlickrData
                                       {
                                           ImageSource = tweet.Element(ns + "thumbnail").Attribute("url").Value,
                                           Message = tweet.Element("description").Value,
                                           UserName = tweet.Element("title").Value,
                                           PubDate = DateTime.Parse(tweet.Element("pubDate").Value)
                                       }; 
              */  
                
                //xdoc = XDocument.Parse(e.Result, LoadOptions.None);

                //IEnumerable<XElement> elements= xdoc.Element("quiz").Elements("question");

                /*foreach (XElement el in elements)
                {
                    text += el.Element("text").Value + "\n";
                    foreach (XElement ele in el.Elements("choice"))
                    {
                        text += "\t" + ele.Value + "\n";
                    }
                    //break;
                }

                ((TextBlock)e.UserState).Text = text;*/

                
                // do something with the XDocument here
            }
        }
        
    }
}
