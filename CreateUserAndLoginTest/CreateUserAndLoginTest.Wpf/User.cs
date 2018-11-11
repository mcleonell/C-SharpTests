using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace CreateUserAndLoginTest.Wpf
{
    /// <summary>
    /// Een klasse voor het toevoegen en uitlezen van de dbo.users database.
    /// </summary>
    class User
    {
        

        #region connection
        static bool connected = false;
        SqlConnection cnn;
        #endregion
        #region readandwrite




        #endregion


        public User()
        {

        }
        SqlConnection ConnectToDatabase()
        {


            string connectionstring;
            connectionstring = @"Data Source = timothy\sqlexpress; Initial Catalog = Test; Integrated Security = True";
            cnn = new SqlConnection(connectionstring);
            cnn.Open();

            connected = true;

            return cnn;

        }

        string ReaderFromDatabase(SqlCommand command)
        {
            string output = "";

            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();

            return output;

        }
        void GetUsername(string username)
        {
            SqlCommand command = new SqlCommand("select username from users where username = '" + username + "'");
            ReaderFromDatabase(command);
        }
        void GetPassword(string password)
        {
            SqlCommand command = new SqlCommand("select username from users where username = '" + password + "'");
            ReaderFromDatabase(command);
        }
        void SetNewUser(string username, string password)
        {
            SqlCommand command = new SqlCommand("insert into users (username,password)" + "Values ('"+ username +"','"+password+"')",cnn);
            command.ExecuteNonQuery();
        }
        void DisconnectFromDatabase()
        {
            if (connected)
            {
                cnn.Close();
            }
            else
            {
                Debug.Print("Databese wasn't connected");
            }
            
            
        }

        public bool Login(string _username, string _password)
        {
            string username = ;
            string password = "pass";
            if (_username == username && _password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateNewUser(string newUsername ,  string newUserpassword)
        {
            
            
            ConnectToDatabase();
            SetNewUser(newUsername,newUserpassword);
            

            // TODO - SqlParameters Toevoegen
        }
    }
}
