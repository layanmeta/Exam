using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPart1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDAO dao = new TestDAO();

            List<Tests> tests = dao.GetAllTests();
            foreach (Tests test in tests)
            {
                Console.WriteLine($"{test.ID}, {test.Car_Id},{test.IsPassed},{test.Date}");
            }
            Console.WriteLine("");

            CarDAO cardao = new CarDAO();

            List<Cars> cars = cardao.GetAllCars();
            foreach (Cars car in cars)
            {
                Console.WriteLine($"{car.IDCar}, {car.Manufacture},{car.Model},{car.Year}");
            }
            Console.WriteLine("");

            List<Cars> manf = cardao.GetManf("vauxhall");
            foreach (Cars car in manf)
            {
                Console.WriteLine($"{car.IDCar}, {car.Manufacture},{car.Model},{car.Year}");
            }
            Console.WriteLine("");

            TestDAO testdoa = new TestDAO();
            List<Tests> testsAndCars = testdoa.GetAllTestsAndTests();
            foreach (Tests testcars in testsAndCars)
            {
                Console.WriteLine($"{testcars.ID}, {testcars.Car_Id},{testcars.IsPassed},{testcars.Date},{testcars.ID}");
            }
            Console.WriteLine("");
        }
       
    }
}
