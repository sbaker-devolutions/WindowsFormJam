using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    public static class DB
    {
        private static SqlConnection conSql = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Jam.mdf;Integrated Security=True");
        private static SqlCommand cmdSql = new SqlCommand();
        private static SqlDataReader readerSql;

        public static bool ConnectionTest()
        {
            try
            {
                conSql.Open();
                conSql.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't connect to DB: " + ex.Message);
                return false;
            }
            return true;
        }

        public static bool ExecCmd(string cmd, DataTable data)
        {
            bool result = false;
            try
            {
                cmdSql.CommandType = CommandType.Text;
                cmdSql.CommandText = cmd;
                
                cmdSql.Connection = conSql;
                conSql.Open();
                readerSql = cmdSql.ExecuteReader();
                data.Load(readerSql);

                readerSql.Close();
                result = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("error ExecPsParams: " + ex.Message);
                result = false;
            }
            finally
            {
                conSql.Close();
            }
            //return result;
            return false;
        }
    }
}
