using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        private string cnnstring;
        public static DataProvider Instance {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
             }
        private DataProvider() {
            cnnstring = @"Data Source = TNSON\SQLEXPRESS; Initial Catalog = QuanLySinhVienCK; Integrated Security = True";
                }
        public bool ExecuteDB(string query)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(cnnstring))
                {
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataTable GetRecords(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cnn = new SqlConnection(cnnstring))
                {
                   SqlCommand cmd = new SqlCommand(query,cnn);
                   SqlDataAdapter da = new SqlDataAdapter(cmd);
                   
                    cnn.Open();
                    da.Fill(dt);
                    cnn.Close();
                    return dt;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}
