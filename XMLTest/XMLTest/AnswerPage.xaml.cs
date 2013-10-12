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
using System.Xml.Linq;

namespace XMLTest
{

    public class Answer
    {
        //IEnumerable<String> Choicess;
        public string Text { get; set; }
        public IEnumerable<XElement> Choicess { get; set; }
        public List<String> Choices { get; set; }
    }
    public partial class AnswerPage : PhoneApplicationPage
    {
        public AnswerPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(RssItemPage_Loaded);
        }

        #region Event Handlers
        void RssItemPage_Loaded(object sender, RoutedEventArgs e)
        {

            // Set page title to news title and navigate to string containing news item.
            //  PageTitle.Text = ((RssItem)DataContext).Title.ToLower();


            Answer iAnswerrDetail = new Answer();
            //PageTitle.Text = ((QuizData)DataContext).Text.
            iAnswerrDetail.Text = ((QuizData)DataContext).Text;
            iAnswerrDetail.Choicess = ((QuizData)DataContext).Choices;

            textBlock1.Text = ((QuizData)DataContext).Text;
            //listBox2.Items.Add(iAnswerrDetail);
            List<Answer> options = new List<Answer>();
            //iAnswerrDetail.Choices = ((QuizData)DataContext).Choices.
            foreach (XElement node in ((QuizData)DataContext).Choices)
            {
                Answer tmp = new Answer();
                tmp.Text = node.Value;
                //options.Add(new Answer().Text);
                 //iAnswerrDetail.Text = node.Value;
                listBox2.Items.Add(tmp);
            }
            // ContentName.Text = ((RssItem)DataContext).Title.ToLower();
            //   image1.Source = ((RssItem)DataContext).Media.ToLower();


        }

        #endregion
    }
}