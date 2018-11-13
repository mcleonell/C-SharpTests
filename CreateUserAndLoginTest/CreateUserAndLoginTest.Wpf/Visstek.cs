using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace CreateUserAndLoginTest.Wpf
{
    class Visstek
    {
        public List<string> visstekken = new List<string>();
        public string Naam { get; set; }

        string conString = System.Configuration.SpecialSetting.ConnectionString.ToString();

        Visstek()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MSI\sqlexpress;Initial Catalog=Test;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT naam FROM visstekken" ,con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Console.WriteLine(dt.Columns[0].ToString());

            con.Close();
        }
    }
}
