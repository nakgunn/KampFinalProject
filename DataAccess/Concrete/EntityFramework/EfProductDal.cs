using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Product varlığını getirirken diğer varlıklarla ilişki kurup getirebiliriz.
    // Linq ile ilişkilendirme işlemini yaparız. Bu ilişkiyi kurmak için bir Dto varlığımızın olması gerekir.

    // EfEntityRepositoryBase içindeki metodları implemente etmedik. Çünkü bir interface değil. Metodları otomatik varmış gibi davranır.
    // Yalnızca IProductDal içerisindeki metodları implemente ediyoruz.
    // Bu class hem IProductDal'dan hem de EfEntityRepository'den CRUD operasyonlarını kazanır.
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId, 
                                                           ProductName = p.ProductName, 
                                                           CategoryName = c.CategoryName, 
                                                           UnitsInStock = p.UnitsInStock 
                             };
                return result.ToList();
            }
        }
    }
}
