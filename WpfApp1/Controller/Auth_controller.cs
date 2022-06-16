using System;
using System.Collections.Generic;
using System.Text;

namespace praktika.Controller
{
    internal class Auth_controller
    {
        internal Auth_controller()
        {
            db_Controller = new Db_controller();
        }

        private readonly Db_controller db_Controller;

        internal Model.User_Auted_Model AuthUser(string login, string password)
        {
            return db_Controller.CheсkUser(new Model.User_Autnt_Model(login, password));
        }
    }
}
