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
        //DataReaderClass dataReader = new DataReaderClass();

        int index;

        string QueryCommand1 = "SELECT * FROM TimeReport " +
                    "Join Employee " +
                    "ON Employee.Person_ID = TimeReport.Person_ID " +
                    "Join Project " +
                    "ON Project.Project_ID = TimeReport.Project_ID " +
                    "Where Employee.FirstName = ('Sven')";

        string QuerycCommand2 = "Select * From Project";

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
            PupulateListBox();
        }

        public void PupulateListBox()
        {

            var list = DBTableToReturn();

            foreach (var i in list)
            {

                listbxDataFromDB.Items.Add(i);

                listbxDataFromDB.Text = i.ToString();
            }
        }
        public void PopulateComboBox()
        {


            var list2 = DBTableToReturn();
            foreach (var i in list2)
            {
                cmbxEmployee.Items.Add(i.ToString());
            }
        }

        public void cmbxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

            index = cmbxEmployee.SelectedIndex + 1;

            var list = DBTableToReturn();

            listbxDataFromDB.Items.Add(list.ToString());

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
                SqlCommand command = new SqlCommand(SetSQLQueryCommandString(QueryCommand1), connection);



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
                    //    listToReturn.Add((string)reader[1].ToString() + "\t" + (string)reader[2].ToString());

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
