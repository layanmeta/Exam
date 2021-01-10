using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPart2
{
    class CategoriesDAO
    {
        public List<Categories> GetAllCategories()
        {
            List<Categories> tests = new List<Categories>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=.;Initial Catalog=PartTwo;Integrated Security=True");
            cmd.Connection.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Categories";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["NameCate"]} ");
                var e = new
                {
                    Id = reader["ID"],
                    name = reader["NameCate"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();
            return tests;
        }

    }
}
