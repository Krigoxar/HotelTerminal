using System;
using System.Collections.Generic;
using System.Text;

namespace praktika.Controller
{
    class MainWindow_controller
    {
        public MainWindow_controller()
        {
            db_Controller = new Db_controller();
            mainWindow = new Model.MainWindow_Model();
        }

        private readonly Db_controller db_Controller;
        public readonly Model.MainWindow_Model mainWindow;

        public void AddBookingDetails(int userId, DateTime checkInDate, DateTime checkOutDate, string roomType)
        {
            db_Controller.CleanBookingDetailsDb();
            Model.booking_wrnt_details_Model booking_Wrnt_Details = new Model.booking_wrnt_details_Model(userId, checkInDate, checkOutDate, roomType);
            int roomNumber;
            if ((roomNumber = db_Controller.FindFreeRoom(booking_Wrnt_Details,roomType)) != 0)
            {
                db_Controller.AddBookingDetails(booking_Wrnt_Details, roomNumber);
            }
            else
            {
                throw new Exception("Все комнаты этого типа заняты");
            }
        }

        internal int checkHowManyRoomsIsAvilible(string roomType, DateTime dateTime)
        {
            return db_Controller.HowManyRoomsISAvilible(roomType, dateTime);
        }
    }
}
