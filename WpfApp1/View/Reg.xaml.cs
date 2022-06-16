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
using System.ComponentModel;

namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        private readonly Controller.Reg_controller reg_Controller = new Controller.Reg_controller();

        public RegWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(reg_Controller.AddkUser(LoginTextBox.Text, PasswordTextBox.Text))
            {
                this.Hide();
                Owner.Show();
            }
            else
            {
                MessageBox.Show("Такой пользователь уже есть", "Ошибка");
            }
        }
        void RegWindow_Closing(object sender, CancelEventArgs e)
        {
            Owner.Show();
        }
    }
}
