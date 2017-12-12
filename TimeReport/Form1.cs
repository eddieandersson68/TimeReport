using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeReport
{
    public partial class Form1 : Form
    {
        public List<string> TimeSpentPerEmployeeOnProject = new List<string>();
        public List<string> listOfEmployees = new List<string>();

        string QueryCommandGetTimetableForSelectedPerson = "SELECT * FROM TimeReport " +
                    "Join Employee " +
                    "ON Employee.Person_ID = TimeReport.Person_ID " +
                    "Join Project " +
                    "ON Project.Project_ID = TimeReport.Project_ID " +
                    "Where Employee.FirstName = ('Sven')";

        string QuerycCommandGetProject = "Select * FROM Project";


        /* Nicklas kod 
        string Querycmmand3 = $"select TimeTable.Week,TimeTable.Hour,Projects.ProjectName " +
                $" from TimeTable inner join Anställd " +
                $" on Anställd.Person_ID = TimeTable.Person_ID " +
                $" inner join Projects on " +
                $" TimeTable.Project_ID = projects.Project_ID " +
                $" where Anställd.FirstName = '{tempList[0]}' and Anställd.LastName = '{tempList[1]}'";
    */


        public Form1()
        {
            InitializeComponent();
           // PopulateComboBox();
            PupulateListBox();

            // DataAdapter();
        }


        public void PupulateListBox()
        {
            var list = TimeSpentPerEmployeeOnProject;

            foreach (var i in list)
            {
                listbxDataFromDB.Items.Add(i);

                listbxDataFromDB.Text = i.ToString();
            }
        }


        //public void PopulateComboBox()
        //{
        //    var list2 = ReadDBEmployee();

        //    foreach (var i in list2)
        //    {
        //        cmbxEmployee.Items.Add(i.ToString());
        //    }
        //}


        public void cmbxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbxEmployee.SelectedIndex != -1))
            {
                GetProjektAndPerson();
            }
        }

        public void GetProjektAndPerson()
        {
            var d = cmbxEmployee.SelectedItem.ToString();
            var b = d.Split();
            List<string> testTemp = new List<string>();
            foreach (var i in d)
            {
                if (i != " ")
                {
                    testTemp.Add(i);
                }

            }
            string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

            //ovanför sql frågan du har vil du ju göra typ

            string QueryCommandGetTimetableForSelectedPerson2 = $"SELECT TimeReport.WeekNr, TimeReport.Hours, Project.ProjectName " +
                     $"FROM TimeReport INNER JOIN Employee " +
                     $"ON Employee.Person_ID = TimeReport.Person_ID " +
                     $"INNER JOIN Project " +
                     $"ON TimeReport.Project_ID = Project.Project_ID " +
                     $" = TimeReport.Project_ID " +
                     $"Where Employee.FirstName = '{listOfEmployees[0]}' and Employee.LastName = '{listOfEmployees[1]}'";

         






            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.CommandText = "QueryCommandGetTimetableForSelectedPerson2";
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = testTemp[0];
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = testTemp[1];
                SqlDataAdapter da = new SqlDataAdapter(cmd);


                da.Fill(ds, "TimeReport");
                listbxDataFromDB.Items.Clear();
                if (ds != null)
                {
                    foreach (DataRow row in ds.Tables["TimeReport"].Rows)
                    {
                        listbxDataFromDB.Items.Add("Week: " + row[0].ToString().PadRight(5) + "Hour: " + row[1].ToString().PadRight(5) + "Project: " + row[3].ToString().PadRight(5));
                    }
                }
            }
        }
                //SqlDataAdapter da = new SqlDataAdapter("SELECT * from Employee;", connection);


                //SqlCommand command = new SqlCommand(SetSQLQueryCommandString(QueryCommandGetTimetableForSelectedPerson2), connection3);



        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {

        //            TimeSpentPerEmployeeOnProject.Add(
        //                     "Week: " + (string)reader[3].ToString().PadRight(5)
        //                   + " Hour: " + (string)reader[4].ToString().PadRight(5)
        //                   + " FirstName: " + (string)reader[6].ToString().PadRight(5)
        //                   + " LastName: " + (string)reader[7].ToString().PadRight(5)
        //                   + " Project: " + (string)reader[9].ToString().PadRight(5));

        //            for (int i = 2; i < reader.FieldCount; i++)
        //            {
        //                TimeSpentPerEmployeeOnProject.Add((string)reader[1].ToString() + "\t" + (string)reader[2].ToString());
        //            }
        //        }

        //    }
        //}




        public void ReadDBEmployee()
        {

            string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;


            string QuerycCommandGetPeople = "Select * FROM Employee";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {

                SqlCommand command = new SqlCommand(QuerycCommandGetPeople, connection);


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 2; i < reader.FieldCount; i++)
                    {
                        cmbxEmployee.Items.Add((string)reader[1].ToString() + "\t" + (string)reader[2].ToString());

                    }
                }
            }
        }







        public List<string> DBTableToReturn()
        {
            List<string> listToReturn = new List<string>();


            string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                //SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);
                //SqlCommand command = new SqlCommand("SELECT * FROM TimeReport " +
                //    "Join Employee " +
                //    "ON Employee.Person_ID = TimeReport.Person_ID " +
                //    "Join Project " +
                //    "ON Project.Project_ID = TimeReport.Project_ID " +
                //    "Where Employee.FirstName = ('Eddie')", connection);
                SqlCommand command = new SqlCommand(QueryCommandGetTimetableForSelectedPerson, connection);



                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // column 1 is FirstName, column 2 is LastName 

                    listToReturn.Add(
                             "Week: " + (string)reader[3].ToString().PadRight(5)
                           + " Hour: " + (string)reader[4].ToString().PadRight(5)
                           + " FirstName: " + (string)reader[6].ToString().PadRight(5)
                           + " LastName: " + (string)reader[7].ToString().PadRight(5)
                           + " Project: " + (string)reader[9].ToString().PadRight(5));

                    //foreach(var i in reader)

                    //{
                    //    listOfEmployees.Add((string)reader[6].ToString() + "\t" + (string)reader[7].ToString());

                    //}
                    //StringBuilder sb = new StringBuilder();

                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    //    sb.Append(reader[i]);
                    //    listToReturn.Add(reader[i].ToString());
                    //listToReturn.Add(sb.ToString());

                    //listToReturn.Add((string) reader[1].ToString() + "\t" + (string) reader[2].ToString());
                }
            }
            return listToReturn;

        }







        public void DataAdapter()
        {
            //string connStr = Properties.Settings.Default.ToString();
            //SqlConnection conn = new SqlConnection(connStr);

            string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

            //using (SqlConnection connection = new SqlConnection(connectionStr))
            SqlConnection connection = new SqlConnection(connectionStr);


            SqlDataAdapter da = new SqlDataAdapter("SELECT * from Employee;", connection);

            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            //string queryString = "SELECT * from Employee;";
            /// SqlDataAdapter da = new SqlDataAdapter(queryString, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employees");
            listbxDataFromDB.Text = ds.Tables[0].ToString();
            //ds.Tables[0].Constraints.Add("Emil", ds.Tables[0].Columns[0], true);
            //DataRow row;
            //row = ds.Tables[0].NewRow();

            //ds.Tables[0].Rows.Add(row);
            //da.Update(ds.Tables[0]);

            //MessageBox.Show("Employee Record Added");
        }






        public string SetSQLQueryCommandString(string command)
        {
            return command;
        }

        private void btnSubmitReport_Click(object sender, EventArgs e)
        {

        }
    }
}
