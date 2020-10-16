using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SoftArchCW
{
    /// <summary>
    /// Interaction logic for CallOutDetail.xaml
    /// </summary>
    public partial class CallOutDetail : Window
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root"); //Logins into SQL Server
        MySqlCommand command; //Loads command variables
        MySqlDataReader mdr;
        patient newpatient; //Loads data from Business Logic Layer
        ambulance newambulance; 
        public CallOutDetail()
        {
            InitializeComponent();
            newpatient = new patient(); //Initializes Business Logic Layer codes
            newambulance = new ambulance();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open(); //Starts a connection
            string postcodeString = patientLoc.Text; //Converts text boses to strings
            string strPostCode = postcodeString.Substring(0, 3);
            //string selectQuery = "SELECT * FROM patient_medical.hospital WHERE POSTCODE = " + "'" + postcodeString + "'";
            string selectQuery = "SELECT * FROM patient_medical.hospital WHERE POSTCODE LIKE " + "'" + "%" + strPostCode + "%" + "'"; //runs an SQL command to the SQL server
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader(); //Starts a Reader
            if (mdr.Read()) //If the reader is successful 
            {
                //patientName.Text = mdr.GetString("PATIENT_NAME");
                //nhsNumber.Text = mdr.GetInt32("NHS_NUMBER").ToString();
                //addressName.Text = mdr.GetString("ADDRESS");
                //mediCond.Text = mdr.GetString("MEDICAL_COND");
                MessageBox.Show("Send the patient to: " + mdr.GetString("HOSPITAL_NAME")); //Display a message of the closest Hospital
                mdr.Close(); //Close the reader
                connection.Close(); //Close the connection
                connection.Open(); //Start a new connection
                newpatient.patientname = patientName.Text; //store text variables into business logic layer code
                newpatient.patienttime = patientTime.Text;
                newpatient.patientloc = patientLoc.Text;
                newambulance.timespent = timeSpent.Text;
                newambulance.actiontaken = actionTaken.Text;
                string insertQuery = "INSERT INTO patient_medical.kwik_hospital(PATIENT_NAME,PATIENT_TIME,PATIENT_WHERE,CALL_LENGTH,ACTION_TAKEN) VALUES('" + newpatient.patientname + "','" + newpatient.patienttime + "','" + newpatient.patientloc + "','" + newambulance.timespent + "','" + newambulance.actiontaken + "') ;";
                //Runs an SQL command that inserts data into database
                command = new MySqlCommand(insertQuery, connection);
                try
                {
                    if (command.ExecuteNonQuery() == 1) //if the command is successful
                    {
                        MessageBox.Show("Data Inserted"); //The data is entered
                        
                    }
                    else //Otherwise
                    {
                        MessageBox.Show("Data Not Inserted"); //The data is not entered
                    }
                }
                catch (Exception ex) //Catch SQL exceptions for error handling
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ERROR: Post Codes start with 'S' and a 1-20 digit number, please check you've entered the data correctly."); //If the user inputs a wrong post code, display an error
            }
            connection.Close(); //Close the connection
        }
    }
}
