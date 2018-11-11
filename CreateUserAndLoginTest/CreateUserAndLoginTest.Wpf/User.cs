using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CreateUserAndLoginTest.Wpf
{
    class User
    {
        string username = "user";
        string password = "pass";

        public User()
        { 
            
        }

        public bool Login(string _username, string _password)
        {
            if(_username == username && _password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateNewUser()
        {
            // TODO - Add new user to database
        }
    }
}
