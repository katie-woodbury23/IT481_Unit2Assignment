/*
Kathleen Woodbury
Purdue University Global
IT481 Advanced Software Development
Professor Kovacic
Unit 2 Assignment: Data Access Application
10/01/2023
 */

namespace IT481_Unit2Assignment
{
    public partial class Form1 : Form
    {
        private DB? database;
        private String dbConnString = "Server = localhost\\SQLEXPRESS; " +
                                        "Trusted_Connection=true;" +
                                        "Database=northwind;" +
                                        "User Instance=false;" +
                                        "trustServerCertificate=True;" +
                                        "Connection timeout=30";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database = new DB(dbConnString);
            MessageBox.Show("Connection information sent");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (database is null)
            {
            database = new DB(dbConnString);
            }
            string count = database.getCustomerCount();

            MessageBox.Show(count, "Customer count");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (database is null)
            {
            database = new DB(dbConnString);
            }
            string names = database.getCompanyNames();

            MessageBox.Show(names, "Company names");
        }
    }
}