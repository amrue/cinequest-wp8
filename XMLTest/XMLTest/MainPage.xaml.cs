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
using System.Xml;
using System.Xml.Linq;

namespace XMLTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        object selectedItem;
        Uri targetPage;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void textBlock_Tap(object sender, GestureEventArgs e)
        {
            Class1 test = new Class1();
            test.getData("http://horstmann.com/sjsu/spring2013/cs185c/hw02/quiz.xml", textBlock);
            //textBlock.Text = text;

        }

        public void setTextBlockText(String s)
        {
            textBlock.Text = s;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                // get RSS item from ListBox and store in class var. Store page to navigate to in class var.
                selectedItem = (QuizData)e.AddedItems[0];
                targetPage = new Uri("/AnswerPage.xaml", UriKind.Relative);

                // reset selection of ListBox
                ((ListBox)sender).SelectedIndex = -1;

                // PageTransition.Begin();

                // change  page navigation 
                NavigationService.Navigate(targetPage);
                FrameworkElement root = Application.Current.RootVisual as FrameworkElement;
                root.DataContext = selectedItem;
            }
        }

        private void listBox1_Tap(object sender, GestureEventArgs e)
        {
            WebClient webclient = new WebClient();
            webclient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webclient_DownloadStringCompleted);
            webclient.DownloadStringAsync(new Uri("http://horstmann.com/sjsu/spring2013/cs185c/hw02/quiz.xml"));
        }

        void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("error");
            }
            // parsing Flickr
            XElement XmlTweet = XElement.Parse(e.Result);
            //var ns = XmlTweet.GetDefaultNamespace(); // get the default namespace 
            //XNamespace ns = "http://search.yahoo.com/mrss/";
            listBox1.ItemsSource = from tweet in XmlTweet.Descendants("question")
                                   select new QuizData
                                   {

                                       Text = tweet.Element("text").Value,

                                       Choices = tweet.Element("text").ElementsAfterSelf("choice")
                                       
                                   };
        }
    }
}