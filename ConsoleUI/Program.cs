using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // EntityFramework ekledikten sonra parametredeki InMemoryProductDal'ı ----> EfProductDal yaptık başka hiç bir yere dokunmadık.
            // Bu olaya SOLID'ın Open Closed Principle denir. Yeni bir özellik eklediğimizde mevcut kodlardan hiçbirine dokunmadık.
            ProductManager productManager = new ProductManager(new EfProductDal()); // Parametrede hangi data access tekniğini kullanacağını verdik.


            foreach (var product in productManager.GetByUnitPrice(40, 100)) // productManager'ın kendisi bir liste döndürmüyor. İçerisindeki GetAll() metodu bir product listesi döndürüyor.
            {
                Console.WriteLine(product.ProductName);
            }




            //List<Product> products;
            //products = productManager.GetAll();

            //List<Category> categories = new List<Category> { new Category {CategoryId=1, CategoryName="Mutfak" }, new Category{CategoryId=2, CategoryName="Teknoloji" } };

            //var result = from p in products
            //             join c in categories
            //             on p.CategoryId equals c.CategoryId
            //             where p.CategoryId == 2
            //             orderby p.ProductId
            //             select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName };

            //foreach (var item in result)
            //{ 
            //    Console.WriteLine(item.ProductId + " " +  item.ProductName + " " + item.CategoryName);
            //}


        }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }

    }
}
