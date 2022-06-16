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

namespace praktika
{
    /// <summary>
    /// Interaction logic for AuthRegWindow.xaml
    /// </summary>
    public partial class AuthRegWindow : Window
    {
        public AuthRegWindow()
        {
            InitializeComponent();
        }
        private void ButtonAuth_Click(object sender, RoutedEventArgs e)
        {
            Auth a = new Auth();
            a.Owner = this;
            a.Show();
            this.Hide();
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow b = new RegWindow();
            b.Owner = this;
            b.Show();
            this.Hide();
        }
    }
}
