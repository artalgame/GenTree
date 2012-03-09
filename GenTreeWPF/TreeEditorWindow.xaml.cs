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

namespace GenTreeWPF
{
    /// <summary>
    /// Interaction logic for TreeEditor.xaml
    /// </summary>
    public partial class TreeEditorWindow : Window
    {
        public TreeEditorWindow()
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

        private void BornDateCalendar_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BornDatePicker.SelectedDate = DateTime.Now;
            DeathDatePicker.SelectedDate = null;
            GenderComboBox.Items.Clear();
            GenderComboBox.Items.Add(Genders.Female.ToString());
            GenderComboBox.Items.Add(Genders.Male.ToString());
            foreach(Person person in TreeProcessor.TreeProcessorSingletone.CurrentTree.Persons)
            {
                PeopleListView.Items.Add(person.NameOfPerson + "   " + person.Gender.ToString());          
            }
        }
    }
}
