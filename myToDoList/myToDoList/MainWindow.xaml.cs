using SQLite;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace myToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Chore> chores;
        public MainWindow()
        {
            InitializeComponent();
            chores = new List<Chore>();
            ReadDatabase();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewToDoWindow addNewToDoWindow = new AddNewToDoWindow();
            addNewToDoWindow.ShowDialog();

            ReadDatabase();
        }

        //db den bilgi çekilerek listview e gönderilcek

        public void ReadDatabase()
        {            
            using (SQLiteConnection conn= new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Chore>();
                chores= conn.Table<Chore>().ToList(); 

            }

            if(chores != null)
            {
                choresListView.ItemsSource = chores;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //burda Linq yani sql komutlarını sanki metod gibi direk kullanıcaz

            List<Chore> filteredList = chores.Where(c => c.Title.ToLower().Contains((sender as TextBox).Text.ToLower())).ToList();
            choresListView.ItemsSource= filteredList;
        }

        private void choresListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(choresListView.SelectedItem != null)
            {
                selectedChoreWindow selectedChoreWindow = new selectedChoreWindow(choresListView.SelectedItem as Chore);
                selectedChoreWindow.ShowDialog();

            }
            ReadDatabase();
        }
    }
}
