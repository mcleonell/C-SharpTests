using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Collections;

namespace CreateUserAndLoginTest.Wpf
{
    /// <summary>
    /// Een klasse voor het toevoegen en uitlezen van de dbo.users database.
    /// </summary>
    class User
    {

        Database dbAcces = new Database();







        public User()
        {

        }
        

        
        bool GetUsername(string username)
        {
            bool output;
            string column = "username";
            SqlCommand command = new SqlCommand("select username from users where username = '" + username + "'",dbAcces.ConnectToDatabase());
            output = dbAcces.ReaderFromDatabase(command, column, username);
            return output;
        }
        bool GetPassword(string password)
        {
            bool output;
            string column = "password";
            SqlCommand command = new SqlCommand("select password from users where password = '" + password + "'", dbAcces.ConnectToDatabase());
            output = dbAcces.ReaderFromDatabase(command, column, password);
            return output;
        }
        
        

        public bool Login(string _username, string _password)
        {
            dbAcces.ConnectToDatabase();
            
            if(GetUsername(_username) && GetPassword(_password))
            {
                return true;
                
            }
            else
            {
                return false;
                
            }

            
                
        }

        public bool CreateNewUser(string newUsername ,  string newUserpassword, string newUseremail)
        {           
            
            dbAcces.ConnectToDatabase();
            if(dbAcces.SetNewUser(newUsername, newUserpassword, newUseremail) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
