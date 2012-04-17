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
        private bool isDeleteButtonActive;//for add/delete persons, use 1 button
        public TreeEditorWindow()
        {
            InitializeComponent();
            isDeleteButtonActive = false;
        }        

       /* private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectPersonIndex = PeopleListView.SelectedIndex;
            if (selectPersonIndex != -1)
            {
                isDeleteButtonActive = true;
                NewPersonButton.Content = "Delete person";
                TreeProcessor.TreeProcessorSingletone.CurrentPerson =
                    TreeProcessor.TreeProcessorSingletone.CurrentTree.Persons.GetPersonList()[selectPersonIndex];
                RefreshPersonEditor(TreeProcessor.TreeProcessorSingletone.CurrentPerson);
            }
        }*/

        private void RefreshPersonEditor(Person person)
        {
            NameTextBox.Text = person.NameOfPerson;
            if(person.DateOfBorn != null)
            BornDatePicker.Text = person.DateOfBorn.ToString();
            if (person.DateOfDeath != null)
                DeathDatePicker.Text = person.DateOfDeath.ToString();
            if (person.Gender == Genders.Male)
                GenderComboBox.SelectedIndex = 1;
            else GenderComboBox.SelectedIndex = 0;
            NoteTextBox.Text = person.Note;
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
            RefreshListViewOfPerson();
            
        }

        private void NewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            if (isDeleteButtonActive)
            {
                TreeProcessor.TreeProcessorSingletone.CurrentTree.DeletePerson(
                    TreeProcessor.TreeProcessorSingletone.CurrentPerson);
                TreeProcessor.TreeProcessorSingletone.CurrentPerson = null;
                isDeleteButtonActive = false;
                NewPersonButton.Content = "Add New Person";
                RefreshListViewOfPerson();
            }
            else
            {
                if (TreeProcessor.TreeProcessorSingletone.AddNewPersonToTree(
                    new Person("person name", DateTime.Now, null, Genders.Female, "")))
                {
                    RefreshListViewOfPerson();
                }
                else
                    MessageBox.Show("Some error");
            }
        }
        private void RefreshListViewOfPerson()
        {
            PeopleDataGrid.Items.Clear();
            foreach (Person person in TreeProcessor.TreeProcessorSingletone.CurrentTree.Persons)
            {
                PeopleDataGrid.Items.Add(person);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TreeProcessor.TreeProcessorSingletone.CurrentPerson != null)
            {
                isDeleteButtonActive = false;
                string name = NameTextBox.Text;
                DateTime? bornDate = BornDatePicker.SelectedDate;
                DateTime? deathDate = DeathDatePicker.SelectedDate;
                Genders gender = (Genders)Enum.Parse(typeof(Genders), GenderComboBox.SelectedItem.ToString());
                string note = NoteTextBox.Text;
                TreeProcessor.TreeProcessorSingletone.CurrentPerson.NameOfPerson = name;
                TreeProcessor.TreeProcessorSingletone.CurrentPerson.DateOfBorn = bornDate;
                TreeProcessor.TreeProcessorSingletone.CurrentPerson.DateOfDeath = deathDate;
                TreeProcessor.TreeProcessorSingletone.CurrentPerson.Gender = gender;
                TreeProcessor.TreeProcessorSingletone.CurrentPerson.Note = note;
                RefreshListViewOfPerson();
                TreeProcessor.TreeProcessorSingletone.CurrentPerson = null;
            }
        }

        private void SaveTreeButton_Click(object sender, RoutedEventArgs e)
        {
            TreeProcessor.TreeProcessorSingletone.SaveCurrentTreeToFile();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SaveTreeButton_Click(this, null);
            Application.Current.Shutdown();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            SaveTreeButton_Click(null, null);
            var wind = new MainWindow();
            wind.Show();
            this.Close();
        }

        private void PeopleListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectPersonIndex = PeopleDataGrid.SelectedIndex;
            if (selectPersonIndex != -1)
            {
                isDeleteButtonActive = true;
                NewPersonButton.Content = "Delete person";
                TreeProcessor.TreeProcessorSingletone.CurrentPerson =
                    TreeProcessor.TreeProcessorSingletone.CurrentTree.Persons.GetPersonsList()[selectPersonIndex];
                RefreshPersonEditor(TreeProcessor.TreeProcessorSingletone.CurrentPerson);
            }
        }

        private void EditRelativesButton_Click(object sender, RoutedEventArgs e)
        {
            var wind = new EditRelativesWindow();
            wind.Show();
        }

        private void button1_Click_2(object sender, RoutedEventArgs e)
        {
            if (PeopleDataGrid.SelectedIndex != -1)
            {
                Person person = PersonList.GetPersonList().GetPersonsList()[PeopleDataGrid.SelectedIndex];
                var wind = new GraphWindow();
                PersonsGraph graph = new PersonsGraph(PersonList.GetPersonList(), RelationsTable.GetTable(),person);
                new DrawPersonGraph(graph, wind.canvas1,(int)wind.Width/2,(int)wind.Height-100,50,50).DrawToCanvas();
                wind.ShowDialog();
            }
        }
    }
}
