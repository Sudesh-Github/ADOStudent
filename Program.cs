//using System;
//using System.Data;
//using System.Data.SqlClient;

//namespace ADOStudent
//{
//    class Program
//    {
//        // Connected Approach for Database Access in ADO.NET
//        static void Main(string[] args)
//        {
//            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-7S4I2CM\SQLEXPRESS; Initial Catalog=Sample; Integrated Security=True;Connect Timeout=30");
//            con1.Open();
//            SqlCommand cmd = new SqlCommand();
//            string str = "select * from Matches";
//            cmd.CommandText = str;
//            cmd.Connection = con1;

//            SqlDataReader dr = cmd.ExecuteReader();
//            Console.WriteLine("Book Records...");
//            while (dr.Read())
//            {
//                int MatchID = Int32.Parse(dr[0].ToString());
//                string TeamName1 = dr[1].ToString();
//                Console.WriteLine($"MatchID: {MatchID}, Team Name1: {TeamName1}");
//            }
//        }
//    }
//}






using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOStudent
{
    // Disconnected Approach 
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-7S4I2CM\SQLEXPRESS; Initial Catalog=Sample; Integrated Security=True;Connect Timeout=30");
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Matches", con1);
            DataSet ds = new DataSet();
            da.Fill(ds, "Matches");
            foreach (DataRow dr in ds.Tables["Matches"].Rows)
            {
                int MatchID = Int32.Parse(dr[0].ToString());
                string Status = dr[4].ToString();

                Console.WriteLine($"MatchID: {MatchID}, WinningTeam: {Status}");

            }
        }
    }
}






















