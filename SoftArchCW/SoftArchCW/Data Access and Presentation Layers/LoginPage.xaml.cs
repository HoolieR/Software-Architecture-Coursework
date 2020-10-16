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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root"); //Logins into MySQL Server
        MySqlCommand command; //Initiates a Command
        MySqlDataReader mdr; //Prepares to read from the database
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e) //Upon button click
        {
            connection.Open(); //Starts a connection
            string userNameString = usernameText.Text; //Converts textboxes into strings
            string passwordString = passwordText.Text;
            string selectQuery = "SELECT * FROM patient_medical.login WHERE USER_NAME = " + "'" + userNameString + "'" + " AND PASS_WORD = " + "'" + passwordString + "'"; //Runs an SQL query with the string data
            command = new MySqlCommand(selectQuery, connection); //Runs an SQL Command
            mdr = command.ExecuteReader(); //Executres a Reader
            if (mdr.Read()) //If succesfully read
            {
                MessageBox.Show("Welcome!"); //Display welcome message
                MainWindow mw = new MainWindow();
                mw.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username/Password"); //Otherwise display error
            }
            connection.Close();
        }
    }
}
