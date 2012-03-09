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

namespace GenTreeWPF
{
    /// <summary>
    /// Interaction logic for TreeEditor.xaml
    /// </summary>
    public partial class TreeEditor : Window
    {
        public TreeEditor()
        {
            InitializeComponent();
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("No selected person!!!", "Warning");
        }
    }
}
