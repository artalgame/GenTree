using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GenTreeBE;
using GenTreeCore;
using GenTreeWPF;
namespace GenTreeWPF
{
    /// <summary>
    /// Interaction logic for GraphWindow.xaml
    /// </summary>
    public partial class GraphWindow : Window
    {
        public PersonsGraph graph;
        private DrawPersonGraph drawGraph;
        public GraphWindow()
        {
            InitializeComponent();
        }

        public GraphWindow(PersonsGraph graph):this()
        {
            this.graph = graph;
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (drawGraph == null)
            {
                drawGraph = new DrawPersonGraph(graph, canvas1, (int)ActualWidth / 2, (int)ActualHeight - 200, 30, 70);

            }
            drawGraph.DrawToCanvas();
        }
    }
}
