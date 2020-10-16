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
    /// Interaction logic for Patient_Medical.xaml
    /// </summary>
    public partial class Patient_Medical : Window
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root"); //Starts a connection with the SQL Server
        MySqlCommand command; //Prepares the commands and Business Logic Layer code
        MySqlDataReader mdr;
        patient newpatient;
        public Patient_Medical()
        {
            InitializeComponent();
            newpatient = new patient(); //Initializes the new patient code
        }

        private void Button_Click(object sender, RoutedEventArgs e) //On Button click
        {
            connection.Open(); //Start a connection
            
  
            string patientNameString = patientName.Text; //Output textboxes to strings
            string patientID = nhsNumber.Text;
            string selectQuery = "SELECT * FROM patient_medical.patient_medical WHERE NHS_NUMBER = " + int.Parse(nhsNumber.Text); //Stores a SQL query into a string
            command = new MySqlCommand(selectQuery, connection); //Runs the command
            mdr = command.ExecuteReader(); //Execute a reader
            if (mdr.Read()) //If the read is succesfull
            {
                patientName.Text = mdr.GetString("PATIENT_NAME"); //Enter the data into the DATABASE AND BUSINESS CASE Variables
                nhsNumber.Text = mdr.GetInt32("NHS_NUMBER").ToString();
                addressName.Text = mdr.GetString("ADDRESS");
                mediCond.Text = mdr.GetString("MEDICAL_COND");
                newpatient.patientname = patientName.Text;
                newpatient.nhsnumber = Convert.ToInt32(nhsNumber.Text);
                newpatient.address = addressName.Text;
                newpatient.medicalcond = mediCond.Text;
            }
            else //otherwise dont
            {
                patientName.Text = " ";
                nhsNumber.Text = " ";
                addressName.Text = " ";
                mediCond.Text = " ";
                MessageBox.Show("No Data For This NHS Number.");
            }
            connection.Close(); //Close the connection
        }
    }
}
