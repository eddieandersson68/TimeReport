using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            DBProjectsList();
            SetWeeks();
        }

        public void cmbxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            listbxDataFromDB.Items.Clear();

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

      
        public void DBProjectsList()
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


        public void SetWeeks()
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
            listbxDataFromDB.Items.Clear();
            var emp = cmbxEmployee.SelectedIndex;
            var week = cmbxWeek.SelectedIndex +1;
            var project = cmbxProject.SelectedIndex;
            var hour = Int32.Parse(tbxWorkedHours.Text);


            string columns = emp + "," + project + "," + week + "," + hour;

            string SqlQuery =  "INSERT INTO TimeReport(Person_ID, Project_ID, WeekNr, Hours)VALUES("+columns+")";

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(SqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                cmbxEmployee_SelectedIndexChanged(this,e);
            }
        }
    }
}