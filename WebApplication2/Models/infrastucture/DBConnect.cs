using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebAPITest1.Models.infrastructure
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "127.0.0.1";//"127.0.0.1:3306";
            database = "tdb";
            uid = "root";
            password = "qwerty123456";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";Allow Zero Datetime=true;";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(Customer customer)
        {
            string query = "INSERT INTO tbl_customer (Name, Birthday) VALUES('"+ customer.Name +"', '"+ customer.Birthday.ToString("yyyy-MM-dd").Split(' ')[0] +"');";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(Customer customer)
        {
            string query = "UPDATE tbl_customer SET name='"+ customer.Name +"', Birthday='"+ customer.Birthday.ToString("yyyy-MM-dd").Split(' ')[0] + "' WHERE IDEN="+ customer.Iden + ";";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(Customer customer)
        {
            string query = "DELETE FROM tbl_customer WHERE IDEN="+ customer.Iden + ";";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<Customer> Select()
        {
            string query = "SELECT * FROM tbl_customer;";

            //Create a list to store the result
            List<Customer> customers = new List<Customer>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    bool canParseDate = false;
                    DateTime bday = DateTime.Now;
                    if (dataReader["Birthday"] != null)
                    {
                        canParseDate = DateTime.TryParse(dataReader["Birthday"].ToString(), out bday);
                    }
                        customers.Add(new Customer() { Iden = (long)(int)dataReader["IDEN"], Name = dataReader["Name"].ToString(), Birthday = bday });
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return customers;
            }
            else
            {
                return customers;
            }
        }
    }
}
