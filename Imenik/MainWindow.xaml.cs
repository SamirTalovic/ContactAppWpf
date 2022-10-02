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

namespace Imenik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prozor prozor = new Prozor();
            prozor.ShowDialog();
            ReadDatabase();
        }
        List<Contactcs> contact;
        void ReadDatabase()
        {
           
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contactcs>();
                contact = (conn.Table<Contactcs>().ToList()).OrderBy(c => c.Name).ToList();


            }
            if (contact != null)
            {
                //foreach (var c in contact)
                //{
                //    ContactListView.Items.Add(new ListViewItem()
                //    {
                //        Content = c
                //    }
                //        );
                //}
                ContactListView.ItemsSource=contact; 
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;    
            var filter =  contact.Where(c => c.Name.ToLower().Contains(textBox.Text.ToLower())).ToList();
            ContactListView.ItemsSource = filter;
        }

        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contactcs selectedContact = (Contactcs)ContactListView.SelectedItem;
            if(selectedContact != null)
            {
                UD ud = new UD(selectedContact);
                ud.ShowDialog();
            }
            ReadDatabase();
        }
    }
}
