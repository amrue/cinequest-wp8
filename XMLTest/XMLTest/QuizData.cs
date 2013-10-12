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
using System.Collections.Generic;
using System.Xml.Linq;

namespace XMLTest
{
    public class QuizData
    {
        public String Text { get; set; }
        public IEnumerable<XElement> Choices { get; set; }
        public int Answer { get; set; }
    }
}
