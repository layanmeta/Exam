using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPart1
{
    class CarDAO
    {
        public List<Cars> GetAllCars()
        {
            List<Cars> tests = new List<Cars>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=partone;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Cars";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                Console.WriteLine($"ID: {reader["IDCar"]}, Manufacture: {reader["Manufacture"]}, Model: {reader["Model"]}, Year:{reader["Year"]} ");
                var e = new
                {
                    Id = reader["IDCar"],
                    manufacture = reader["Manufacture"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();
            return tests;
        }

        public List<Cars> GetManf(string manf)
        {
            List<Cars> tests = new List<Cars>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=partone;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM Cars WHERE Manufacture = '{manf}'";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                Console.WriteLine($"ID: {reader["IDCar"]}, Manufacture: {reader["Manufacture"]}, Model: {reader["Model"]}, Year:{reader["Year"]} ");
                var e = new
                {
                    Id = reader["IDCar"],
                    manufacture = reader["Manufacture"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();
            return tests;
        }
    }
}
