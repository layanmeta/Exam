using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPart1
{
    class TestDAO
    {
        public List<Tests> GetAllTests()
        {
            List<Tests> tests = new List<Tests>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=partone;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Tests";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                Console.WriteLine($"ID: {reader["ID"]}, Car Id: {reader["Car_Id"]}, is passed: {reader["IsPassed"]}, Date:{reader["Date"]} ");
                var e = new
                {
                    Id = reader["ID"],
                    car_Id = reader["Car_Id"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();
            return tests;
        }
        public List<Tests> GetAllTestsAndTests()
        {
            List<Tests> tests = new List<Tests>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=partone;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Tests t1 LEFT OUTER JOIN Cars t2 ON t1.Car_Id = t2.IDCar";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                Console.WriteLine($"ID: {reader["ID"]}, Car id: {reader["Car_Id"]}, is passed: {reader["IsPassed"]}, Date:{reader["Date"]} IDCar: {reader["IDCar"]}, Manufacture: {reader["Manufacture"]}, Model: {reader["Model"]}, Year:{reader["Year"]}");
                var e = new
                {
                    Id = reader["ID"],
                    car_Id = reader["Car_Id"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();
            return tests;
        }
    }
}
