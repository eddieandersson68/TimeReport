using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace TimeReport
{
   public  class Emp
    {
        public int Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Emp(int id, string fname, string lname)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
        }

        public string MakeString()
        {
            return Id +  FirstName + LastName;
        }



        //    public List<string> test()
        //    {
        //    List<string> listToReturn = new List<string>();


        //    string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionStr))
        //        {
        //            //SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);
        //            SqlCommand command = new SqlCommand("SELECT * FROM TimeReport Join Employee " +
        //                "ON Employee.Person_ID = TimeReport.Person_ID " +
        //                "Join Project ON Project.Project_ID = TimeReport.Project_ID " +
        //                "Where Employee.FirstName = ('Eddie')", connection);

        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                // column 1 is FirstName, column 2 is LastName 


        //                //foreach(var i in reader)

        //                //{
        //                //    listToReturn.Add((string)reader[1].ToString() + "\t" + (string)reader[2].ToString());

        //                //}
        //                StringBuilder sb = new StringBuilder();

        //                for (int i = 0; i < reader.FieldCount; i++)
        //                {
        //                    sb.Append(reader[i]);

        //                    //listToReturn.Add(reader[i].ToString());
        //                    listToReturn.Add(sb.ToString());

        //                }

        //                //listToReturn.Add((string) reader[1].ToString() + "\t" + (string) reader[2].ToString());
        //            }
        //        }

        //        return listToReturn;

        //    }

        //    public void DataAdapter()
        //    {
        //        string connStr = Properties.Settings.Default.ToString();
        //        SqlConnection conn = new SqlConnection(connStr);
        //        SqlDataAdapter da = new SqlDataAdapter("SELECT * from Employee;", conn);
        //        SqlCommandBuilder cmb = new SqlCommandBuilder(da);
        //        //string queryString = "SELECT * from Employee;";
        //       /// SqlDataAdapter da = new SqlDataAdapter(queryString, conn);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds, "Employees");
        //        ds.Tables[0].Constraints.Add("Emil", ds.Tables[0].Columns[0], true);
        //        DataRow row;
        //        row = ds.Tables[0].NewRow();
        //        ds.Tables[0].Rows.Add(row);
        //        da.Update(ds.Tables[0]);
        //        MessageBox.Show("Employee Record Added");
        //}
    }
}

