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
            this.Close();
            var tmpWind = new MainWindow();
            tmpWind.Show();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string info = InfoTextBox.Text;
            if ((name != "") && (name != null))
            {
                int ID = (name + info).GetHashCode();
                this.Hide();
                TreeProcessor.TreeProcessorSingletone.SetCurrentTree(
                    new GenTree(DateTime.Now, DateTime.Now, name, ID, info));
                this.Hide();
                var tmpWind = new TreeEditorWindow();
                tmpWind.Show();
            }
            else
                MessageBox.Show("Please, fill 'tree's name' field");
        }
    }
}
