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
    /// Interaction logic for UD.xaml
    /// </summary>
    public partial class UD : Window
    {
        Contactcs contactcs;

        public UD(Contactcs contactcs)
        {
            InitializeComponent();
            this.contactcs = contactcs;
            nameText.Text = contactcs.Name;
            emailText.Text = contactcs.Email;
            phoneText.Text = contactcs.Phone;
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contactcs>();
                connection.Delete(contactcs);
            }
            Close();
        }

        private void updatebutton_Click(object sender, RoutedEventArgs e)
        {
            contactcs.Name = nameText.Text;
            contactcs.Email = emailText.Text; 
            contactcs.Phone = phoneText.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contactcs>();
                connection.Update(contactcs);
            }
            Close();
        }
    }
}
