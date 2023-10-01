/*
Kathleen Woodbury
Purdue University Global
IT481 Advanced Software Development
Professor Kovacic
Unit 2 Assignment: Data Access Application
10/01/2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace IT481_Unit2Assignment
{
    class DB
    {
        string connectionString; 
        
        SqlConnection? dbconn; 
        // Default Constructor
        public DB() 
        { 
            connectionString = "Server = localhost\\SQLEXPRESS; " + 
                               "Trusted_Connection=true;" + 
                               "Database=northwind;" + 
                               "User Instance=false;" + 
                               "trustServerCertificate=True;" + 
                               "Connection timeout=30"; 
        } 
        // Constructor that takes a DB connection string
        public DB(string pConnString) 
        { 
            connectionString = pConnString; 
        } 
        // Method to get the customer table count
        public string getCustomerCount() 
        { 
            Int32 count = 0; 
            dbconn = new SqlConnection(connectionString); 
            dbconn.Open(); 
            string countQuery = "SELECT COUNT(*) FROM customers;"; 
            SqlCommand cmd = new SqlCommand(countQuery, dbconn); 
            try 
            { 
                count = Convert.ToInt32(cmd.ExecuteScalar()); 
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            } 
            dbconn.Close(); 
            return count.ToString(); 
        } 
        
        // Method to get the company names
        public string getCompanyNames() 
        { 
            string names = "None"; 
            SqlDataReader dataReader; dbconn = new SqlConnection(connectionString); 
            dbconn.Open(); 
            string countQuery = "SELECT companyname FROM customers;"; 
            SqlCommand cmd = new SqlCommand(countQuery, dbconn); 
            dataReader = cmd.ExecuteReader(); 
            while (dataReader.Read()) 
            { 
                try 
                { 
                    names = names + dataReader.GetValue(0) + "\n"; 
                } 
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message); 
                } 
            } 
            dbconn.Close(); 
            return names; 
        } 
    } 
}
