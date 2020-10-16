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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace SoftArchCW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginPage loginpage = new LoginPage();
        
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root"); //Starts a connection with the SQL server
        patient newpatient; //Prepares the business Logic layer code

        public MainWindow()
        {
            InitializeComponent();
            newpatient = new patient(); //Initializes the patient code
            //string patientNameString = patientName.Text;
            //string nhsNumberString = nhsNumber.Text;
            //string addressString = addressName.Text;
            //string medicalCondString = mediCond.Text;
        }

        
      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            newpatient.patientname = patientName.Text; //Stores the data into the business logic layer code
            newpatient.nhsnumber = Convert.ToInt32(nhsNumber.Text);
            newpatient.address = addressName.Text;
            newpatient.medicalcond = mediCond.Text;


            string insertQuery = "INSERT INTO patient_medical.kwik_medical(PATIENT_NAME,NHS_NUMBER,ADDRESS,MEDICAL_COND) VALUES('" + newpatient.patientname + "','" + newpatient.nhsnumber + "','" + newpatient.address + "','" + newpatient.medicalcond + "') ;";
            //Runs an SQL query to insert data into mySQL server through a string
            connection.Open(); //Opens a SQL connection
            MySqlCommand command = new MySqlCommand(insertQuery, connection); //Runs the command
            try
            {
                if (string.IsNullOrWhiteSpace(patientName.Text) || string.IsNullOrWhiteSpace(nhsNumber.Text) || string.IsNullOrWhiteSpace(addressName.Text) || string.IsNullOrWhiteSpace(addressName.Text) || string.IsNullOrWhiteSpace(mediCond.Text))
                { //If no data is entered in ANY boxes display an error
                    MessageBox.Show("Data Not Inserted");
                }
                else //Otherwise
                {
                    if (command.ExecuteNonQuery() == 1) //If the SQL command ran succesfully then
                    {
                        MessageBox.Show("Data Inserted"); //Insert the data
                    }
                    else
                    {
                        MessageBox.Show("Data Not Inserted"); //Dont insert the data
                    }
                }
            }
            catch (Exception ex) //Catch all SQL exceptions for error handling
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close(); //Close the connection
        }

        private void PatientSearch_Click(object sender, RoutedEventArgs e)
        {
            Patient_Medical pn = new Patient_Medical(); 
            pn.Show(); //Start patient medical menu
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CallOutDetail ca = new CallOutDetail();
            ca.Show(); //Start Call Out Menu
        }
    }
}
