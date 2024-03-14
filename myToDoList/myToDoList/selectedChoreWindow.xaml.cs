using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace myToDoList
{
    /// <summary>
    /// Interaction logic for selectedChoreWindow.xaml
    /// </summary>
    public partial class selectedChoreWindow : Window
    {
        Chore chore;
        public selectedChoreWindow(Chore chore)
        {
            InitializeComponent();
            this.chore = chore;

            selectedTitle.Text = chore.Title;
            selectedDescription.Text = chore.Description;
            selectedDeadline.Text = chore.DeadLine;
        }

       
        private void editChoreButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteChoreButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn= new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Chore>();
                conn.Delete(chore);   
            }
            
            Close();
        }

    }
}
