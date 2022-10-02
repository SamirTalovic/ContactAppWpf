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

namespace Imenik
{
    /// <summary>
    /// Interaction logic for Prozor.xaml
    /// </summary>
    public partial class Prozor : Window
    {
        public Prozor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contactcs Kontakt = new Contactcs()
            {
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Phone = PhoneTextBox.Text
            };
           
            string databaseName="Contact.db";
            string pathFolder= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string databasePath = System.IO.Path.Combine(pathFolder, databaseName);

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contactcs>();
                connection.Insert(Kontakt);
            }
            Close();
        }
    }
}
