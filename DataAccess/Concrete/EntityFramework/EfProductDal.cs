using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // using yukarıdaki using değil. buradaki using bir IDisposable Pattern implementasyonudur.
            // using içine yazdığımız nesneler using kullanıldıktan sonra bellekten atılır -> Garbage Collector
            // Context nesnesi belleği yoran bir nesnedir, bu yüzden using kullanırız. using c#'a özeldir.
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); // product tipindeki context varlığının referansını yakala -> addedEntity'e ver.
                addedEntity.State = EntityState.Added; // addedEntity'nin eklenecek nesne olduğunu set ettik.
                context.SaveChanges(); // State'i gerçekleştir.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); // product tipindeki contextin varlığının referansını yakala -> addedEntity'e ver.
                deletedEntity.State = EntityState.Deleted; // addedEntity'nin silinecek nesne olduğunu set ettik.
                context.SaveChanges();
            }
        }
        // Tek data döndürecek ve filtre zorunluluğu var
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); // filtreye göre tek bir Product döndürecek.
            }
        }

     
        // Data listesi döndürecek ve filtre zorunlu değil.
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                return filter == null                                               // filtre null ise ? sonrasını çalıştır - null değilse : sonrasını çalıştır.
                    ? context.Set<Product>().ToList()                               // context'in Product barındıran prop'una yerleş(products tablosuna) Products tablosunun içindekileri listeye dönüştür. select * from Products gibi
                    : context.Set<Product>().Where(filter).ToList();                // Products tablosuna parametreden dönen linq filtresini uygula ve listeye dönüştür. select * from products where = parametredeki değer gibi çalışır.
            }

        }

       

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); // product tipindeki contextin varlığının referansını yakala -> addedEntity'e ver.
                updatedEntity.State = EntityState.Modified; // addedEntity'nin güncellenecek nesne olduğunu set ettik.
                context.SaveChanges();
            }
        }
    }
}
