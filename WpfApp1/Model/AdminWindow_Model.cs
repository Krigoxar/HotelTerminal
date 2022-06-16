using System;
using System.Collections.Generic;
using System.Text;

namespace praktika.Model
{
    internal class AdminWindow_Model
    {
        public AdminWindow_Model()
        {
            UsersList = new List<Model.User_Auted_Model>() {new User_Auted_Model(new User_Autnt_Model("Admin", "Password"), 1) };
            BookingsList = new List<Model.booking_wred_details_Model>();
        }

        public List<Model.User_Auted_Model> UsersList { get; set; }
        public List<Model.booking_wred_details_Model> BookingsList { get; set; }
    }
}
