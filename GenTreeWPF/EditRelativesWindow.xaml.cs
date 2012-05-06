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

namespace GenTreeWPF
{
    /// <summary>
    /// Interaction logic for EditRelativesWindow.xaml
    /// </summary>
    public partial class EditRelativesWindow : Window
    {
        private int personIndex;
        private List<RelationBetweenTwoPerson> relations; 
        private RelationBetweenTwoPerson _currentRelation;
        private EditRelativesWindow()
        {
            InitializeComponent();
        }
        public  EditRelativesWindow(int index):this()
        {
            personIndex = index;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load names of relatives to comboBox
            foreach (string relativeName in Enum.GetNames(typeof(Relatives)))
            {
                RelationComboBox.Items.Add(relativeName);
            }
            RefreshTable();
        }

        private void RefreshTable()
        {
            RelationTableDataGrid.Items.Clear();

            relations =
                RelationsTable.GetTable().Where(
                    x => PersonList.GetPersonList().GetPersonIndexInTable(x.FirstPerson) == personIndex).ToList();
            foreach(RelationBetweenTwoPerson relation in relations)
            {
                RelationTableDataGrid.Items.Add(relation);
            }
        }

        private void RelationTableDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(RelationTableDataGrid.SelectedIndex!=-1)
                _currentRelation = relations[RelationTableDataGrid.SelectedIndex];
            else
            {
                _currentRelation = null;
            }
        }

        private void SaveRelationButton_Click(object sender, RoutedEventArgs e)
        {
            if (RelationTableDataGrid.SelectedIndex != -1)
            {
                Relatives relative;
                if (Relatives.TryParse(RelationComboBox.SelectedValue.ToString(), out relative))
                {
                    RelationsTable.GetTable().SetRelationBetweenPersons(_currentRelation.FirstPerson,
                                                                        _currentRelation.SecondPerson, relative);
                    RefreshTable();
                }
            }
        }

        private void RelationComboBox_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
