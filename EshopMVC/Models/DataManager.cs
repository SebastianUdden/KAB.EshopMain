using EshopMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EshopMVC.Models
{
    public class DataManager
    {
        CustomerContext Context;

        public DataManager(CustomerContext context)
        {
            this.Context = context;
        }

        //customer related methods
        public void AddCustomer(CreateCustomerViewModel viewModel)
        {
            Customer c = new Customer();
            c.FirstName = viewModel.FirstName;
            c.LastName = viewModel.LastName;
            c.Email = viewModel.Email;
            c.Password = viewModel.Password;
            c.Adress = viewModel.Adress;
            c.Ssn = viewModel.Ssn;

            Context.Customers.Add(c);
            Context.SaveChanges();
        }

        public Customer[] GetCustomer(string email, string password)
        {
            //this needs testing, *should* return a customer object from the database
            var Customer = Context.Customers.Select(x => new Customer
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Password = x.Password,
                Adress = x.Adress,
                Ssn = x.Ssn
            }).Where(x => x.Email == email && x.Password == password).ToArray()/*.Where(x => x.Id == id)*/;
            return Customer;
        }

        public List<OrderHistory> GetOrderHistory(int id)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source = kab.database.windows.net; Initial Catalog = KAB; Integrated Security = False; User ID = Kolumn3; Password = Samal073; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;

            myCommand.CommandText = "GetOrderHistory";
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            SqlDataReader reader = myCommand.ExecuteReader();

            List<OrderHistory> tmpList = new List<OrderHistory>();

            while (reader.Read())
            {
                OrderHistory oh = new OrderHistory();
                oh.OrderId = reader.GetInt32(0);
                oh.Date = reader.GetDateTime(1);
                oh.ProductId = reader.GetInt32(2);
                oh.ProductName = reader.GetString(3);
                oh.Quantity = reader.GetInt32(4);

                tmpList.Add(oh);
            }

            myConnection.Close();
            return tmpList;


        }
    }
}