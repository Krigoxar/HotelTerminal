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

namespace praktika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Model.User_Auted_Model CurentUser)
        {
            mainWindow_Controller = new Controller.MainWindow_controller();
            mainWindow_Controller.mainWindow.MassivOfDates = new int[30];
            int j = 0;
            for (int i = 1; i < 31; i++)
            {
                mainWindow_Controller.mainWindow.MassivOfDates[j] = i;
                j++;
            }
            this.CurentUser = CurentUser;

            DataContext = mainWindow_Controller.mainWindow;
            InitializeComponent();
            UpdateEmptyRoomsAmount();
        }

        private readonly Controller.MainWindow_controller mainWindow_Controller;
        public Model.User_Auted_Model CurentUser;
        public string chosenRoomType = null;

        private void Update_DataContext()
        {
            OneRoomed.GetBindingExpression(Label.ContentProperty)
                      .UpdateTarget();
            TwoRoomed.GetBindingExpression(Label.ContentProperty)
                      .UpdateTarget();
            ThreeRoomed.GetBindingExpression(Label.ContentProperty)
                      .UpdateTarget();
            VipRoomed.GetBindingExpression(Label.ContentProperty)
                      .UpdateTarget();
        }
        private void UpdateEmptyRoomsAmount()
        {
            if(calendar.SelectedDate != null)
            {
                mainWindow_Controller.mainWindow.RoomsАmount["OneRoomed"] = mainWindow_Controller.checkHowManyRoomsIsAvilible("OneRoomed", (DateTime)calendar.SelectedDate);
                mainWindow_Controller.mainWindow.RoomsАmount["TwoRoomed"] = mainWindow_Controller.checkHowManyRoomsIsAvilible("TwoRoomed", (DateTime)calendar.SelectedDate);
                mainWindow_Controller.mainWindow.RoomsАmount["ThreeRoomed"] = mainWindow_Controller.checkHowManyRoomsIsAvilible("ThreeRoomed", (DateTime)calendar.SelectedDate);
                mainWindow_Controller.mainWindow.RoomsАmount["VipRoomed"] = mainWindow_Controller.checkHowManyRoomsIsAvilible("VipRoomed", (DateTime)calendar.SelectedDate);
            }
            else
            {
                mainWindow_Controller.mainWindow.RoomsАmount["OneRoomed"] = mainWindow_Controller.checkHowManyRoomsIsAvilible("OneRoomed", DateTime.Now);
                mainWindow_Controller.mainWindow.RoomsАmount["TwoRoomed"] = mainWindow_Controller.checkHowManyRoomsIsAvilible("TwoRoomed", DateTime.Now);
                mainWindow_Controller.mainWindow.RoomsАmount["ThreeRoomed"] = mainWindow_Controller.checkHowManyRoomsIsAvilible("ThreeRoomed", DateTime.Now);
                mainWindow_Controller.mainWindow.RoomsАmount["VipRoomed"] = mainWindow_Controller.checkHowManyRoomsIsAvilible("VipRoomed", DateTime.Now);
            }
            mainWindow_Controller.mainWindow.UpdateModel();
            Update_DataContext();
        }
        private void monthCalendar1_DateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEmptyRoomsAmount();
        }
        public static Dictionary<string, string> RoomsTranslate = new Dictionary<string, string>()
        {
            {"Одноместный номер", "OneRoomed"},
            {"Двухместный номер", "TwoRoomed"},
            {"Трехместный номер", "ThreeRoomed"},
            {"VIP номер", "VipRoomed"}
        };
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (calendar.SelectedDate == null)
                {
                    throw new Exception("Дата прибытия не выброна");
                }
                if (Box1.SelectedItem == null)
                {
                    throw new Exception("Время прибывания не выбрано");
                }
                if (chosenRoomType == null)
                {
                    throw new Exception("Нужно выбрать тип комнаты");
                }
                if (calendar.SelectedDate < DateTime.Now)
                {
                    throw new Exception("Нельзя выбрать эту дату");
                }
                mainWindow_Controller.AddBookingDetails(
                    CurentUser.id,
                    (DateTime)calendar.SelectedDate,
                    ((DateTime)calendar.SelectedDate).AddDays((int)Box1.SelectedItem),
                    RoomsTranslate[chosenRoomType]);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Ошибка");
            }
            UpdateEmptyRoomsAmount();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            chosenRoomType = (string)((RadioButton)sender).Content;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Show();
        }
    }
}
