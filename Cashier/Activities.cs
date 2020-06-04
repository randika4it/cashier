using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cashier
{
    class Activities : InterfaceActivities
    {
        int count = 0;
        bool status=false;

        public bool addNewItem(string itemCode, string itemName, string size, string price, string availability)
        {
            MySqlDataReader rd;
            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=restauretdb;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            String query;
            query = "insert into restauretdb.itemlist_tb ( itemCode,itemName, size, price, availability) values" +
                " ('" + itemCode + "','" + itemName + "','" + size + "','" + price + "','" + availability + "')";

            MySqlCommand command = new MySqlCommand(query, conn);

            try
            {
                conn.Open();
                rd = command.ExecuteReader();
                status = true;
                conn.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
                conn.Dispose();
            }
            return status;
        }

        public void billCal()
        {
            throw new NotImplementedException();
        }

        public void deleteItem()
        {
            throw new NotImplementedException();
        }



        public string getNextItemCode()
        {
            String max="0";
            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=restauretdb;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            conn.Open();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT MAX(itemCode) from itemlist_tb", conn);
                max = command.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return max;
        }

        public bool login(string username, string password)
        {

            MySqlDataReader rd;
            
            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=restauretdb;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            String query;


            query = "select * from users where name = '" + username + "' and password ='" + password + "'";

            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                rd = command.ExecuteReader();
                while (rd.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    status= true;
                }
                else
                {
                    status = false;
                    Console.WriteLine("wrong");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return status;
        }

        public bool loginAdmin(string username, string password)
        {
            MySqlDataReader rd;
            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=restauretdb;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            String query;


            query = "select * from users where name = '" + username + "' and password ='" + password + "'";

            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                rd = command.ExecuteReader();
                while (rd.Read())
                {
                    count = count + 1;
                }
                if (count == 1 && rd["privilages"].ToString()=="1")
                {
                    status = true;
                }
                else
                {
                    status = false;
                    Console.WriteLine("wrong");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return status;
        }

        public void order()
        {
            throw new NotImplementedException();
        }

        public void updateItem()
        {
            throw new NotImplementedException();
        }

    }
}
