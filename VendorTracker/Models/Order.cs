using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace VendorTracker.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Date {get; set;}

        public Order(string title, string description, int price, string date)
        {
            Title = title;
            Description = description;
            Price = price;
            Date = date;
            
        }
        public Order(string title, string description, int price, string date, int id)
        {
            Title = title;
            Description = description;
            Price = price;
            Date = date;
            Id = id;
            
        }
        public override bool Equals(System.Object otherOrder)
        {
            if (!(otherOrder is Order))
            {
                return false;
            }
            else
            {
                Order newOrder = (Order) otherOrder;
                bool titleEquality = (this.Title == newOrder.Title);
                bool descriptionEquality = (this.Description == newOrder.Description);
                bool priceEquality = (this.Price == newOrder.Price);
                bool dateEquality = (this.Date == newOrder.Date);
                bool idEquality = (this.Id == newOrder.Id);
                return (titleEquality && descriptionEquality && priceEquality && dateEquality && idEquality);
            }
        }

        public static List<Order> GetAll()
        {
            List<Order> allOrders = new List<Order> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"Select * From orders;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int orderID = rdr.GetInt32(0);
                string title = rdr.GetString(1);
                string orderDescription = rdr.GetString(2);
                int price = rdr.GetInt32(3);
                string date = rdr.GetString(4);
                Order newOrder = new Order(title, orderDescription, price, date, orderID);
                allOrders.Add(newOrder);
            }
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return allOrders;
        }
        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"TRUNCATE TABLE orders;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public static Order Find(int SearchId)
        {
            List<Order> holder = new List<Order> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"Select * From `orders` Where order_id = "+ SearchId+";";
            Console.WriteLine(cmd.CommandText);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                Console.WriteLine("taco");
                int orderID = rdr.GetInt32(0);
                string title = rdr.GetString(1);
                string orderDescription = rdr.GetString(2);
                int price = rdr.GetInt32(3);
                string date = rdr.GetString(4);
                Order newOrder = new Order(title, orderDescription, price, date, orderID);
                holder.Add(newOrder);
            }

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return holder[0];






        }
        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText =@"INSERT INTO orders (title,description,price,date) VALUES (@OrderTitle,@OrderDescription,@OrderPrice,@OrderDate);";

            MySqlParameter title = new MySqlParameter();
            title.ParameterName = "@OrderTitle";
            title.Value = this.Title;
            cmd.Parameters.Add(title);  

            MySqlParameter description = new MySqlParameter();
            description.ParameterName = "@OrderDescription";
            description.Value = this.Description;
            cmd.Parameters.Add(description);

            MySqlParameter price = new MySqlParameter();
            price.ParameterName = "@OrderPrice";
            price.Value = this.Price;
            cmd.Parameters.Add(price); 

            MySqlParameter date = new MySqlParameter();
            date.ParameterName = "@OrderDate";
            date.Value = this.Date;
            cmd.Parameters.Add(date);

            cmd.ExecuteNonQuery();
            Id = (int)cmd.LastInsertedId;
        }
    }
}