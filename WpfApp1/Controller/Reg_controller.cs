using System;
using System.Collections.Generic;
using System.Text;

namespace praktika.Controller
{
    class Reg_controller
    {
        internal Reg_controller()
        {
            db_Controller = new Db_controller();
        }

        private readonly Db_controller db_Controller;
        internal bool AddkUser(string login, string password)
        {
            if (db_Controller.CheсkUser(new Model.User_Autnt_Model(login, password)) == null)
            {
                return db_Controller.AddUser(new Model.User_Autnt_Model(login, password));
            }
            return false;
        }
    }
}
