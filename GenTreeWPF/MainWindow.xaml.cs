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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GenTreeCore;
using GenTreeBE;

namespace GenTreeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void Main_Window_Loaded(object sender, RoutedEventArgs e)
        {
            VersionLabel.Content = "current version 0.1";
            List<GenTree> treesInfo = TreeProcessor.TreeProcessorSingletone.GetTreesInfo();
            GridView treesInfoGrid = new GridView();
            if((treesInfo!=null)&&(treesInfo.Count!=0))
            {
                GridView treeGrid= (GridView)CrTreesListView.View;
            }
            else
            {
               SelectedTreeLabel.Content = "No created trees";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Main_Window, "Gen tree.Created by artalgame");
        }

        private void CreateTreeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CreateTreeWindow t = new CreateTreeWindow(); ;
            t.Show();
        }

      
  

    }
}
