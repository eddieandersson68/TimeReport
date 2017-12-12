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

        int indexNr; 

        //DataReaderClass dataReader = new DataReaderClass();

        int index;

        string QueryCommandGetTimetableForSelectedPerson = "SELECT * FROM TimeReport " +
                    "Join Employee " +
                    "ON Employee.Person_ID = TimeReport.Person_ID " +
                    "Join Project " +
                    "ON Project.Project_ID = TimeReport.Project_ID " +
                    "Where Employee.FirstName = ('Sven')";

        
        

        string QuerycCommandGetProject = "Select * FROM Project";

        string QuerycCommandGetPeople = "Select * FROM Employee";

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
            PopulateComboBox();
           // PupulateListBox();
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


        public void PopulateComboBox()
        {
            var list2 = ReadDBEmployee();

            foreach (var i in list2)
            {
                cmbxEmployee.Items.Add(i.ToString());
            }
        }

        public void cmbxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            //private void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)

            //I test if the combox box i selected and if it is execute this method QuveryListBox
            if ((cmbxEmployee.SelectedIndex != -1))
            {
                


                string QueryCommandGetTimetableForSelectedPerson = "SELECT * FROM TimeReport " +
                        "Join Employee " +
                        "ON Employee.Person_ID = TimeReport.Person_ID " +
                        "Join Project " +
                        "ON Project.Project_ID = TimeReport.Project_ID " +
                        cmbxEmployee.SelectedItem.ToString();


                //List<string> TimeSpentPerEmployeeOnProject = new List<string>();

                string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

                using (SqlConnection connection3 = new SqlConnection(connectionStr))
                {
                    SqlCommand command3 = new SqlCommand(SetSQLQueryCommandString(QueryCommandGetTimetableForSelectedPerson), connection3);


                    connection3.Open();
                    SqlDataReader reader3 = command3.ExecuteReader();
                    while (reader3.Read())
                    {

                        TimeSpentPerEmployeeOnProject.Add(
                                 "Week: " + (string)reader3[3].ToString().PadRight(5)
                               + " Hour: " + (string)reader3[4].ToString().PadRight(5)
                               + " FirstName: " + (string)reader3[6].ToString().PadRight(5)
                               + " LastName: " + (string)reader3[7].ToString().PadRight(5)
                               + " Project: " + (string)reader3[9].ToString().PadRight(5));

                        //for (int i = 2; i < reader3.FieldCount; i++)
                        //{
                        //    TimeSpentPerEmployeeOnProject.Add((string)reader3[1].ToString() + "\t" + (string)reader3[2].ToString());
                        //}
                    }

                }


                PupulateListBox();
                //cmbxEmploye.SelectedItem;
                ////cmbxEmployee.SelectedIndex;
                //cmbxEmployee.SelectedIdex(indexNr);
                //var list2 = DBTableToReturn();

                //foreach (var i in list2)
                //{
                //    cmbxEmployee.Items.Add(i.ToString());
                //}

            }

        }



        public List<string> ReadDBEmployee()
        {
            List<string> listOfEmployees = new List<string>();

            string connectionStr = ConfigurationManager.ConnectionStrings["StaffConnection"].ConnectionString;

            using (SqlConnection connection2 = new SqlConnection(connectionStr))
            {
                SqlCommand command2 = new SqlCommand(SetSQLQueryCommandString(QuerycCommandGetPeople), connection2);


                connection2.Open();
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    for (int i = 2; i < reader2.FieldCount; i++)
                    {
                        listOfEmployees.Add((string)reader2[1].ToString() + "\t" + (string)reader2[2].ToString());
                    }
                }
                return listOfEmployees;
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
                SqlCommand command = new SqlCommand(SetSQLQueryCommandString(QueryCommandGetTimetableForSelectedPerson), connection);



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

        public string SetSQLQueryCommandString(string command)
        {
            return command;
        }
    }
}
