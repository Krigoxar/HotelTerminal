using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika.Model
{
    //не вошедший пользователь
    public class User_Autnt_Model
    {
        public User_Autnt_Model(User_Autnt_Model user)
        {
            this.login = user.login;
            this.password = user.password;
        }
        public User_Autnt_Model(string login,string password)
        {
            this.login = login;
            this.password = password;
        }

        public string login { get; }
        public string password { get; }
    }
    //вошедший пользователь
    public class User_Auted_Model : User_Autnt_Model
    {
        public User_Auted_Model(User_Autnt_Model user, int id, bool IsAdmin = false)
            : base(user)
        {
            this.IsAdmin = IsAdmin;
            this.id = id;
        }

        public int id{ get; }
        public bool IsAdmin { get; }
    }
}
