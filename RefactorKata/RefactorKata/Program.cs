using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            //remove redundant using statement, unnecessary to repeat namespace, explicit to implicit "var" || "conn" = Camel Case//
            var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;");

            var cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Products";
            /* Is this line necessary @NHoltkamp
             * cmd.CommandText = "Select * from Invoices";
             */
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();

            //TODO: Replace with Dapper
            //Awaiting class on relational Database//
            while (reader.Read())
            {
                var prod = new Product {Name = reader["Name"].ToString()};
                products.Add(prod);
            }
            conn.Dispose();
            
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}
