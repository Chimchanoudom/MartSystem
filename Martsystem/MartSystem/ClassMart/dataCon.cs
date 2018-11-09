 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using MartSystem;
using System.Drawing;
using System.IO;

namespace MartSystem
{
    public class dataCon
    {
        public static SqlConnection Con
        {
            get { return con; }
            set { con = value; }
        }

        static SqlConnection con = new SqlConnection("Server=localhost;Database=mart;Trusted_Connection=true;");

        public static string FormatDateTime(DateTime dt)
        {
            return dt.Day.ToString("00") + "/" + dt.Month.ToString("00") + "/" + dt.Year + " " + dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00");
        }

        public static SqlDataReader ExecuteQry(string qry)
        {
            SqlDataReader dataReader = null;
            SqlCommand sql = new SqlCommand(qry, con);
            dataReader = sql.ExecuteReader();
            return dataReader;
        }

        public static int rate { get; set; }

        public static void getRate()
        {
            if (File.Exists("Rate.avi"))
            {
                using (StreamReader sr = new StreamReader("Rate.avi"))
                {
                    try
                    {
                        rate = int.Parse(sr.ReadLine());
                    }
                    catch (FormatException)
                    {
                        rate = 4000;
                    }

                }
            }
            else
            {
                rate = 4000;
                
            }
        }


        public static DateTime ConvertStringToDateTime(string st)
        {
            int day = int.Parse(st.Substring(0, 2));
            int month = int.Parse(st.Substring(3, 2));
            int year = int.Parse(st.Substring(6, 4));
            int hour = int.Parse(st.Substring(11, 2));
            int minute = int.Parse(st.Substring(14, 2));

            DateTime dt = new DateTime(year, month, day, hour, minute, 0);

            return dt;
        }

        public static void ExecuteActionQry(string qry, ref bool error)
        {
            error = false;
            SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                SqlCommand sql = new SqlCommand(qry, con, trans);
                sql.ExecuteNonQuery();
                trans.Commit();
                error = false;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                error = true;
            }
            finally
            {
                con.Close();
            }
        }

        public static class exActionQuery
        {
            public static bool insertDataToDB(string TableName, List<object> DataValues)
            {
                ///Example: INSERT INTO Employee (ColumnName) VALUES (dataToInsert);
                string cmdInsert = "INSERT INTO " + TableName + " ";
                string values = " VALUES (";
                
                for(int i = 0; i < DataValues.Count; i++)
                {
                    if(DataValues[i] is Image)
                    {
                        values += DataValues[i] + ",";
                        continue;
                    }
                    values += DataValues[i] + ",";
                }
                
                values = values.Substring(0, values.Length - 1) + ")";

                string sqlCmd = cmdInsert + values + ";";
                //MessageBox.Show(sqlCmd);
                bool error = false;
                dataCon.ExecuteActionQry(sqlCmd, ref error);
                if(error)
                    MessageBox.Show("Insertion Failed!");
                return error;
            }

            public static bool insertDataToDB(string TableName, Dictionary<string, string> columnNameAndDataValues)
            {
                ///Example: INSERT INTO Employee (ColumnName) VALUES (dataToInsert);
                string cmdInsert = "INSERT INTO " + TableName + " ";
                string columns = "(";
                string values = " VALUES (";

                foreach (string columnName in columnNameAndDataValues.Keys)
                {
                    columns += columnName + ",";
                    values += "N'" + columnNameAndDataValues[columnName] + "'COLLATE Latin1_General_100_CI_AI,";
                }
                columns = columns.Substring(0, columns.Length - 1) + ")";
                values = values.Substring(0, values.Length - 1) + ")";

                string sqlCmd = cmdInsert + columns + values + ";";
                //MessageBox.Show(sqlCmd);
                bool error = false;
                dataCon.ExecuteActionQry(sqlCmd, ref error);
                if (error)
                    MessageBox.Show("Insertion Failed!");
                return error;
            }

            public static bool insertDataToDB(string TableName, string[] dataToInsert)
            {
                ///Example: INSERT INTO Employee VALUES (dataToInsert);
                string cmdInsert = "INSERT INTO " + TableName + " ";
                string values = " VALUES (";

                for (int i = 0; i < dataToInsert.Length; i++)
                {
                    values += "N'" + dataToInsert[i] + "'COLLATE Latin1_General_100_CI_AI,";
                }
                values = values.Substring(0, values.Length - 1) + ");";
                string sqlCmd = cmdInsert + values;
                bool error = false;
                dataCon.ExecuteActionQry(sqlCmd, ref error);
                if (error)
                    MessageBox.Show("Insertion Failed!");
                return error;
            }

            public static bool updateDataToDB(string TableName, Dictionary<string, string> columnNameAndDataValues, string condition = "")
            {
                string cmdUpdate = "update " + TableName + " SET ";
                string Operation = "";
                foreach (string columnName in columnNameAndDataValues.Keys)
                {
                    Operation += columnName + "=N'" + columnNameAndDataValues[columnName] + "'COLLATE Latin1_General_100_CI_AI,";
                }
                Operation = Operation.Substring(0, Operation.Length - 1) + " ";
                condition = (condition == String.Empty) ? ";" : ((condition[condition.Length - 1]).ToString() == ";") ? condition : condition + ";";

                string sqlCmd = cmdUpdate + Operation + condition;
                //MessageBox.Show(sqlCmd);
                bool error = false;
                dataCon.ExecuteActionQry(sqlCmd, ref error);
                if (error)
                    MessageBox.Show("update Failed!");
                return error;
            }

            public static void CollateData(ref List<string> data)
            {
                List<string> temp = new List<string>();
                foreach (string st in data)
                {
                    temp.Add("N'" + st + "' COLLATE Latin1_General_100_CI_AI");
                }

                data = temp;
            }

            public static bool deleteDataFromDB(string TableName, string condition = "")
            {
                
                string cmdDelete = "DELETE FROM " + TableName + " ";

                condition = (condition == String.Empty) ? "WHERE 1=1;" : ((condition[condition.Length - 1]).ToString() == ";") ? condition : condition + ";";

                string sqlCmd = cmdDelete + condition;
                //MessageBox.Show(sqlCmd);
                bool error = false;
                dataCon.ExecuteActionQry(sqlCmd, ref error);
                if (error)
                    MessageBox.Show("Delete Failed!");
                return error;                    
            }
           
        }
    }      
}
