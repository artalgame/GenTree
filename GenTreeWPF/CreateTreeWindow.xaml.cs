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
using GenTreeCore;
using GenTreeBE;
using System.Security.Cryptography;
namespace GenTreeWPF
{
    /// <summary>
    /// Interaction logic for CreateTreeWindow.xaml
    /// </summary>
    public partial class CreateTreeWindow : Window
    {
        public CreateTreeWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var tmpWind = new MainWindow();
            tmpWind.Show();
            this.Close();           
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string info = InfoTextBox.Text;
            if ((name != "") && (name != null))
            {
                int ID = (name + info).GetHashCode();
                TreeProcessor.TreeProcessorSingletone.SetCurrentTree(
                    new GenTree(DateTime.Now, DateTime.Now, name, info));
                var tmpWind = new TreeEditorWindow();
                tmpWind.Show();
                this.Close();
            }
            else
                MessageBox.Show("Please, fill 'tree's name' field");
        }
    }
}
