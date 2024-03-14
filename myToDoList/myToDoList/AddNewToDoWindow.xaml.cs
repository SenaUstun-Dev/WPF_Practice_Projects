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
using System.Windows.Shapes;

namespace myToDoList
{
    /// <summary>
    /// Interaction logic for AddNewToDoWindow.xaml
    /// </summary>
    public partial class AddNewToDoWindow : Window
    {
        public AddNewToDoWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(titleInput.Text)) 
            {
                //en azından title olmak zorunda. 
                MessageBox.Show("Please enter a title.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                Chore chore = new Chore()
                {
                    Title = titleInput.Text,
                    Description = descriptionInput.Text,
                    DeadLine = deadLineInput.Text
                };

                //bağlantıyı kurabilmek için yol yapıyoruz
                
                //yaptık
                //şimdi istediğimizde yolu kullanarak bağlanabiliriz ve istediğimizi yapabiliriz,mesela db oluşturalım ve insert edelim

                using(SQLiteConnection connection = new SQLiteConnection(App.databasePath)){
                    connection.CreateTable<Chore>();
                    connection.Insert(chore); 
                }

                //save butonuna bastıktan sonra pencere oto kapansın diye
                Close();
            }
        }  
    }
}
