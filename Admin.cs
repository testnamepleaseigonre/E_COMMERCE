using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_COMMERCE
{
    public class Admin : User
    {
        public Admin(string id, string name, string surname, DateTime birthDate, string username, string password, string imageLocation, string userType) : base(id, name, surname, birthDate, username, password, imageLocation, userType)
        {
            //Admin admin = new Admin("Valdemar", "Subotkovski", DateTime.Now, "admin", "admin","");
        }
    }
}
