using praktika.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace praktika.Controller
{
    internal class AdminWindowController
    {
        public AdminWindowController()
        {
            AdminWindowModel = new Model.AdminWindow_Model();
            db_Controller = new Db_controller();
            UpdateModdel();
        }

        public Model.AdminWindow_Model AdminWindowModel;
        private readonly Db_controller db_Controller;

        public void UpdateModdel()
        {
            AdminWindowModel.UsersList = db_Controller.GetUser_Auted_Models();
            AdminWindowModel.BookingsList = db_Controller.GetWredBookingModels();
        }

        internal void UpdateBookingInfo(User_Auted_Model selectedItem)
        {
            AdminWindowModel.BookingsList = db_Controller.GetBookingsWithUserId(selectedItem.id);
        }

        internal void DeleteUserWithID(User_Auted_Model selectedItem)
        {
            if (selectedItem.id == 1)
            {
                throw new Exception("Нет.");
            }
            List<booking_wred_details_Model> BookingsForDeleting = db_Controller.GetBookingsWithUserId(selectedItem.id);
            foreach(booking_wred_details_Model booking in BookingsForDeleting)
            {
                db_Controller.DeleteBookingWithID(booking.id);
            }
            db_Controller.DeleteUserWithId(selectedItem.id);
        }

        internal void DeleteBookingWithID(booking_wred_details_Model selectedItem)
        {
            db_Controller.DeleteBookingWithID(selectedItem.id);
        }
    }
}
