using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUserAndLoginTest.Wpf
{
    class Database
    {
        #region connection
        static bool connected = false;
        SqlConnection cnn;
        #endregion
        #region readandwrite

        ArrayList tempHolder = new ArrayList();
        #endregion

        public Database()
        {

        }
        public SqlConnection ConnectToDatabase()
        {


            string connectionstring;
            connectionstring = @"Data Source = timothy\sqlexpress; Initial Catalog = Test; Integrated Security = True";
            cnn = new SqlConnection(connectionstring);
            cnn.Open();

            connected = true;

            return cnn;

        }
        public void DisconnectFromDatabase()
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
        public bool ReaderFromDatabase(SqlCommand command, string column, string var)
        {
            bool output = false;

            SqlDataReader dataReader = null;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                tempHolder.Add(dataReader[column]);
            }
            for (int i = 0; i < tempHolder.Count; i++)
            {
                if (tempHolder[i].ToString() == var)
                {
                    output = true;
                    break;
                }
                else
                {
                    output = false;
                }

            }

            tempHolder.Clear();

            dataReader.Close();
            return output;

        }
        public bool SetNewUser(string username, string password, string email)
        {

            SqlCommand command = new SqlCommand("select username from users",ConnectToDatabase());
            string column = "username";
            if (ReaderFromDatabase(command, column, username))
            {

                return false;
            }
            else
            {
                
                command = new SqlCommand("insert into users (username,password,email)" + "Values ('" + username + "','" + password + "','" + email + "')", ConnectToDatabase());
                command.ExecuteNonQuery();
                return true;
            }
            
        }















    }
}
