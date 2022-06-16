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
using System.Data.SQLite;
using System.ComponentModel;

namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        private readonly Controller.Auth_controller auth_Controller = new Controller.Auth_controller();

        public Auth()
        {
            InitializeComponent();
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            Model.User_Auted_Model user_Auted;
            if(!((user_Auted = auth_Controller.AuthUser(LoginTextBox.Text, PasswordTextBox.Text)) == null))
            {
                if(user_Auted.IsAdmin)
                {
                    WpfApp1.View.AdminWindow mw = new WpfApp1.View.AdminWindow();
                    mw.Owner = this;
                    mw.Show();
                    this.Hide();
                }
                else
                {
                    MainWindow mw = new MainWindow(user_Auted);
                    mw.Owner = this;
                    mw.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль", "Ошибка");
            }
        }
        void AuthWindow_Closing(object sender, CancelEventArgs e)
        {
            Owner.Show();
        }
    }
}
