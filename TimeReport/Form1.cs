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

        string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

        public List<Emp> ListOfEmployees = new List<Emp>();
        public List<string> Projects = new List<string>();

        string QuerycCommandGetProject = "Select * FROM Project";


        public Form1()
        {
            InitializeComponent();
            ReadDBEmployee();
            ProjectsList();
            Weeks();
            
            // DataAdapter();
        }

        public void cmbxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = cmbxEmployee.SelectedIndex;

            string QueryCommandGetTimetableForSelectedPerson2 =
                $"SELECT TimeReport.WeekNr, TimeReport.Hours, Project.ProjectName " +
                    $"FROM TimeReport JOIN Employee " +
                    $"ON Employee.Person_ID = TimeReport.Person_ID " +
                    $"JOIN Project " +
                    $"ON TimeReport.Project_ID = Project.Project_ID " +
                    $"Where Employee.Person_Id =" + s;




            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(QueryCommandGetTimetableForSelectedPerson2, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string text = $"Week: " + reader[0].ToString().PadRight(5) + " Hour: " + reader[1].ToString().PadRight(5) + " Project: " + reader[2].ToString();// + reader[3].ToString();

                    listbxDataFromDB.Items.Add(text);
                }
            }
        }


        public void ReadDBEmployee()
        {
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
                        try
                        {
                            int idint = Int32.Parse(reader[0].ToString());
                            Emp E = new Emp(idint, reader[1].ToString(), reader[2].ToString());
                            ListOfEmployees.Add(E);
                            //cmbxEmployee.Items.Add(E.FirstName);
                            cmbxEmployee.Items.Add(reader[1].ToString() + "\t" + reader[2].ToString());
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }

        #region junk
        //public void GetProjektAndPerson()
        //{
        //    var d = cmbxEmployee.SelectedItem.ToString();
        //    var b = d.Split();
        //    List<string> testTemp = new List<string>();
        //    foreach (var i in d)
        //    {


        //    }
        //    string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

        //    //ovanför sql frågan du har vil du ju göra typ

        //    string QueryCommandGetTimetableForSelectedPerson2 = $"SELECT TimeReport.WeekNr, TimeReport.Hours, Project.ProjectName " +
        //             $"FROM TimeReport INNER JOIN Employee " +
        //             $"ON Employee.Person_ID = TimeReport.Person_ID " +
        //             $"INNER JOIN Project " +
        //             $"ON TimeReport.Project_ID = Project.Project_ID " +
        //             $" = TimeReport.Project_ID " +
        //             $"Where Employee.FirstName = '{listOfEmployees[0]}' and Employee.LastName = '{listOfEmployees[1]}'";



        //    using (SqlConnection connection = new SqlConnection(connectionStr))
        //    {
        //        DataSet ds = new DataSet();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = connection;
        //        cmd.CommandText = "QueryCommandGetTimetableForSelectedPerson2";
        //        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = testTemp[0];
        //        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = testTemp[1];
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);


        //        da.Fill(ds, "TimeReport");
        //        listbxDataFromDB.Items.Clear();
        //        if (ds != null)
        //        {
        //            foreach (DataRow row in ds.Tables["TimeReport"].Rows)
        //            {
        //                listbxDataFromDB.Items.Add("Week: " + row[0].ToString().PadRight(5) + "Hour: " + row[1].ToString().PadRight(5) + "Project: " + row[3].ToString().PadRight(5));
        //            }
        //        }
        //    }
        //}
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


        //public List<string> DBTableToReturn()
        //{
        //    //List<string> listToReturn = new List<string>();


        //    string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionStr))
        //    {
        //        //SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);
        //        //SqlCommand command = new SqlCommand("SELECT * FROM TimeReport " +
        //        //    "Join Employee " +
        //        //    "ON Employee.Person_ID = TimeReport.Person_ID " +
        //        //    "Join Project " +
        //        //    "ON Project.Project_ID = TimeReport.Project_ID " +
        //        //    "Where Employee.FirstName = ('Eddie')", connection);
        //        //SqlCommand command = new SqlCommand(QueryCommandGetTimetableForSelectedPerson, connection);


        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            // column 1 is FirstName, column 2 is LastName 

        //            listToReturn.Add(
        //                     "Week: " + (string)reader[3].ToString().PadRight(5)
        //                   + " Hour: " + (string)reader[4].ToString().PadRight(5)
        //                   + " FirstName: " + (string)reader[6].ToString().PadRight(5)
        //                   + " LastName: " + (string)reader[7].ToString().PadRight(5)
        //                   + " Project: " + (string)reader[9].ToString().PadRight(5));

        //            //foreach(var i in reader)

        //            //{
        //            //    listOfEmployees.Add((string)reader[6].ToString() + "\t" + (string)reader[7].ToString());

        //            //}
        //            //StringBuilder sb = new StringBuilder();

        //            //for (int i = 0; i < reader.FieldCount; i++)
        //            //{
        //            //    sb.Append(reader[i]);
        //            //    listToReturn.Add(reader[i].ToString());
        //            //listToReturn.Add(sb.ToString());

        //            //listToReturn.Add((string) reader[1].ToString() + "\t" + (string) reader[2].ToString());
        //        }
        //    }
        //    return listToReturn;

        //}


        //public void DataAdapter()
        //{
        //    //string connStr = Properties.Settings.Default.ToString();
        //    //SqlConnection conn = new SqlConnection(connStr);

        //    string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

        //    //using (SqlConnection connection = new SqlConnection(connectionStr))
        //    SqlConnection connection = new SqlConnection(connectionStr);


        //    SqlDataAdapter da = new SqlDataAdapter("SELECT * from Employee;", connection);

        //    SqlCommandBuilder cmb = new SqlCommandBuilder(da);
        //    //string queryString = "SELECT * from Employee;";
        //    /// SqlDataAdapter da = new SqlDataAdapter(queryString, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds, "Employees");
        //    listbxDataFromDB.Text = ds.Tables[0].ToString();
        //    //ds.Tables[0].Constraints.Add("Emil", ds.Tables[0].Columns[0], true);
        //    //DataRow row;
        //    //row = ds.Tables[0].NewRow();

        //    //ds.Tables[0].Rows.Add(row);
        //    //da.Update(ds.Tables[0]);

        //    //MessageBox.Show("Employee Record Added");
        //}



        //public string SetSQLQueryCommandString(string command)
        //{
        //    return command;
        //}

        #endregion

        public void ProjectsList()
        {
            string QuerycCommandGetProject = "Select * FROM Project";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(QuerycCommandGetProject, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string text = reader[1].ToString();// + reader[3].ToString();
                    for (int i = 3; i < reader.FieldCount; i++)
                    {
                        cmbxProject.Items.Add(text);
                    }
                }
            }
        }


        public void Weeks()
        {
            for (int i = 1; i < 53; i++)
            {
                cmbxWeek.Items.Add(i);
            }
        }

        public void SetWorkedHours()
        {
            string WorkedHours = tbxWorkedHours.Text;

        }
        

        private void btnSubmitReport_Click(object sender, EventArgs e)
        {
            var s = cmbxEmployee.SelectedIndex;
            var w = cmbxWeek.SelectedIndex;
            var p = cmbxProject.SelectedIndex;
            var h = Int32.Parse(tbxWorkedHours.Text);

            //int Weekint = Int32.Parse(reader[2].ToString());
            //int Hoursint = Int32.Parse(reader[3].ToString());

            //string columns = cmbxEmployee.SelectedIndex + "," + cmbxProject.SelectedIndex + "," + cmbxWeek.SelectedIndex + "," + tbxWorkedHours.Text;
            string columns = s + "," + p + "," + w + "," + h;


            string SqlQuery = "INSERT INTO [TimeReport].[dbo].TimeReport VALUES (" + columns + ")";

            //string EmployeeSubmitHoursToProject = $"INSERT INTO TimeReport(" +
            //    $"Person_ID, " +
            //    $"Project_ID, " +
            //    $"WeekNr, " +
            //    $"Hours)" +
            //    $"VALUES({cmbxEmployee.SelectedIndex} + {cmbxProject.SelectedIndex} + {cmbxWeek.SelectedIndex} + {tbxWorkedHours.Text}";
            

            //string _colums = _week + ", SYSDATETIME(), " + _project + ", " + _employee + ", " + reportHours;



            //INSERT INTO TimeReport(Person_ID, Project_ID, WeekNr, Hours)VALUES(2, 1, 3, 21);

            //$"FROM TimeReport JOIN Employee " +
            //$"ON Employee.Person_ID = TimeReport.Person_ID " +
            //$"JOIN Project " +
            //$"ON TimeReport.Project_ID = " + p +// Project.Project_ID " +
            //$"Where Employee.Person_Id =" + s;


            // string EmployeeSubmitHoursToProject = cmbxEmployee.SelectedIndex + cmbxProject.SelectedIndex + cmbxWeek.SelectedIndex + tbxWorkedHours.Text;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(columns, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string text = reader[1].ToString();// + reader[3].ToString();
                    for (int i = 3; i < reader.FieldCount; i++)
                    {
                        cmbxProject.Items.Add(text);
                    }
                }
            }
        }
    }
}

