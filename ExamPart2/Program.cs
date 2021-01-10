using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreDAO dao = new StoreDAO();

            List<Stores> stores = dao.GetAllStores();
            foreach (Stores store in stores)
            {
                Console.WriteLine($"{store.ID}  {store.Category_ID}  {store.Name} {store.Floor}");
            }
            Console.WriteLine("");
            Console.Write("");

            CategoriesDAO categoriesdao = new CategoriesDAO();

            List<Categories> categories = categoriesdao.GetAllCategories();
            foreach (Categories category in categories)
            {
                Console.WriteLine($"{category.ID}  {category.NameCate}");
            }
            Console.WriteLine("");
            Console.Write("");

            StoreDAO storescategory = new StoreDAO();

            List<Stores> storecat = storescategory.GetStoresCategoriesFloors();
            foreach (Categories category in categories)
            {
                Console.WriteLine($"{category.ID}  {category.NameCate}");
            }
            Console.WriteLine("");
            Console.Write("");
            //code amendment 
        }

    }
}
