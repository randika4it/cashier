using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using MySql.Data.MySqlClient;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.IO;

namespace Cashier
{

    class OrderDb
    {

        string eachPrice, max, maxId;
        IFirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "lJ00CGCubk8WK0tl0zD2ZUULDmVkUfVA1fXqqs0V",
            BasePath = "https://c-sharp-2a4aa.firebaseio.com/"
        };

        public void saveOrder(string orderNo, string itemCode, string size, string qty, string ePrice, System.String total, String tbleNo)
        {
            String item = getMaxId();
            bool status = false;
            Console.WriteLine("saceOrder Called itemNo " + item);
            String date = DateTime.Now.ToString();
            MySqlDataReader rd;

            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=restauretdb;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            String query;
            query = "insert into restauretdb.orders_tb ( orderNo,itemCode, size, qty, eachPrice, total, date) values" +
                " ('" + orderNo + "','" + itemCode + "','" + size + "','" + qty + "','" + ePrice + "','" + total + "','" + date + "')";

            MySqlCommand command = new MySqlCommand(query, conn);

            try
            {
                conn.Open();
                rd = command.ExecuteReader();

                sendToFirebase(tbleNo, itemCode, qty, orderNo, size, item);
                Console.WriteLine("order saved");
                conn.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                conn.Dispose();
            }


        }
        public String searchItem(String itemCode, String size)
        {


            MySqlDataReader rd;

            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=restauretdb;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            String query;


            query = "select * from itemlist_tb where itemCode = '" + itemCode + "' and size ='" + size + "'";
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            rd = command.ExecuteReader();
            try
            {
                if (rd.Read())
                {
                    eachPrice = (rd["price"].ToString());
                    //txtMobile.Text = (rd["mobile"].ToString());
                    //txtSubject.Text = (rd["subO"].ToString());
                    Console.WriteLine(eachPrice);


                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return eachPrice;
        }

        public String searchNextOrderNo()
        {
            MySqlDataReader rd;

            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=restauretdb;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            String query = "SELECT MAX(orderNo) from orders_tb";
            conn.Open();
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
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
        public async void sendToFirebase(String tblNo, String itemCode, String qty, String orderNo, String size, String item)
        {
            //sendToFirebase(tbleNo, itemCode, qty, orderNo, size);


            Console.WriteLine("in firebase item" + item);
            Console.WriteLine("in firbase tble no " + tblNo);
            IFirebaseClient client = new FireSharp.FirebaseClient(config);

            var data = new Data
            {
                tblNo = tblNo,
                itemCode = itemCode,
                qty = qty,
                status = "pending",
                size = size
            };
            SetResponse response = await client.SetTaskAsync("Orders/" + item, data);
            Data result = response.ResultAs<Data>();
            updatePending(item, tblNo);
        }


        public String getMaxId()
        {
            MySqlDataReader rd;

            MySqlConnection conn;
            string connetionString = null;
            connetionString = "server=localhost;database=restauretdb;uid=root;pwd=;";
            conn = new MySqlConnection(connetionString);
            String query;
            conn.Open();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT MAX(id) from orders_tb", conn);
                maxId = command.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return maxId;
        }
        public async void updatePending(String orderNo, String tbleNo)
        {
            Console.WriteLine("pending called");
            IFirebaseClient client = new FireSharp.FirebaseClient(config);

            var DataPending = new DataPending
            {
                orderNo = orderNo,
                //tbleNo = tbleNo

            };
            SetResponse response = await client.SetTaskAsync("pending/" + orderNo, DataPending);
            DataPending result = response.ResultAs<DataPending>();
        }
    }
}
