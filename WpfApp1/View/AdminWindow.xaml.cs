using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            Controller = new praktika.Controller.AdminWindowController();
            InitializeComponent();
            Controller.UpdateModdel();
            DataContext = Controller.AdminWindowModel;
        }

        praktika.Controller.AdminWindowController Controller;

        private void WindowClosing(object sender, EventArgs e)
        {
            Owner.Show();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            Controller.UpdateModdel();
            UsersListBox.GetBindingExpression(ListBox.ItemsSourceProperty)
                      .UpdateTarget();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if(UsersListBox.SelectedItem != null)
            {
                try
                {
                    Controller.DeleteUserWithID((praktika.Model.User_Auted_Model)UsersListBox.SelectedItem);
                    Controller.UpdateModdel();
                    UsersListBox.GetBindingExpression(ListBox.ItemsSourceProperty)
                              .UpdateTarget();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message,"Ошибка");
                }
            }
        }

        private void AddBooking_Click(object sender, RoutedEventArgs e)
        {
            Controller.UpdateModdel();
            BookingListBox.GetBindingExpression(ListBox.ItemsSourceProperty)
                      .UpdateTarget();
        }

        private void DeleteBooking_Click(object sender, RoutedEventArgs e)
        {
            if(BookingListBox.SelectedItem != null)
            {
                Controller.DeleteBookingWithID((praktika.Model.booking_wred_details_Model)BookingListBox.SelectedItem);
                Controller.UpdateModdel();
                BookingListBox.GetBindingExpression(ListBox.ItemsSourceProperty)
                          .UpdateTarget();
            }
        }

        private void UsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(UsersListBox.SelectedItem != null)
            {
                Controller.UpdateBookingInfo((praktika.Model.User_Auted_Model)UsersListBox.SelectedItem);
            }
            BookingListBox.GetBindingExpression(ListBox.ItemsSourceProperty)
                      .UpdateTarget();
        }
    }
}
