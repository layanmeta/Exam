using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPart2
{
    class StoreDAO
    {
        public List<Stores> GetAllStores()
        {
            List<Stores> stores = new List<Stores>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=PartTwo;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Stores";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                Console.WriteLine($"id: {reader["ID"]}, name: {reader["Name"]}, floor: {reader["Floor"]}, category {reader["Category_ID"]}");
                var e = new
                {
                    Id = reader["ID"],
                    name = reader["Name"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();
            return stores;
           

        }
        public List<Stores> GetStoresCategoriesFloors()
        {
            List<Stores> stores = new List<Stores>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=PartTwo;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Stores s1 LEFT OUTER JOIN Categories s2 ON s1.Category_ID = s2.ID WHERE s1.Floor = 1 AND s2.NameCate ='Cloth'";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                Console.WriteLine($"id: {reader["ID"]}, name: {reader["Name"]}, floor: {reader["Floor"]}, category {reader["Category_ID"]}, ID: {reader["ID"]}, Category Name: {reader["NameCate"]} ");
                var e = new
                {
                    Id = reader["ID"],
                    name = reader["Name"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();
            return stores;
            
            

        }

    }
}
