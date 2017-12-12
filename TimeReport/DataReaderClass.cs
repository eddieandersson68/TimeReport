using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace TimeReport
{
   public  class DataReaderClass
    {
        public List<string> test()
        {
        List<string> listToReturn = new List<string>();


        string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                //SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);
                SqlCommand command = new SqlCommand("SELECT * FROM TimeReport Join Employee " +
                    "ON Employee.Person_ID = TimeReport.Person_ID " +
                    "Join Project ON Project.Project_ID = TimeReport.Project_ID " +
                    "Where Employee.FirstName = ('Eddie')", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // column 1 is FirstName, column 2 is LastName 


                    //foreach(var i in reader)

                    //{
                    //    listToReturn.Add((string)reader[1].ToString() + "\t" + (string)reader[2].ToString());

                    //}
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sb.Append(reader[i]);
                      
                        //listToReturn.Add(reader[i].ToString());
                        listToReturn.Add(sb.ToString());

                    }

                    //listToReturn.Add((string) reader[1].ToString() + "\t" + (string) reader[2].ToString());
                }
            }

            return listToReturn;

        }

        public void DataAdapter()
        {
            string connStr = Properties.Settings.Default.ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string queryString = "SELECT * from Employee;";
            SqlDataAdapter da = new SqlDataAdapter(queryString, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
        }
    }
}

