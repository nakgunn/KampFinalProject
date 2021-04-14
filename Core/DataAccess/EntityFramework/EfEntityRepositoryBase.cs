using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    // Entity Framework ile eriştiğimiz veritabanı nesneleri üzerinde gerçekleştireceğimiz CRUD operasyonları birbirini tekrar ettiğinden dolayı bir Generic Base Class oluşturduk.
    // Bu class'ı implemente eden class'lar hangi entity üzerinde işlem yapılacağını -TEntity-, hangi veritabanı bağlantı class'ını -context- kullanacak belirtmek zorundayız.
    // Bu class IEntityRepository içerisinde bulunan metotları implemente eder. Metodların parametrelerinde TEntity ile verdiğimiz varlık kullanılır. Çünkü metodlar arasındaki tek fark burasıdır. Bunu IEntityRepository'de generic yapmıştık. 
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity:class,IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // using yukarıdaki using değil. buradaki using bir IDisposable Pattern implementasyonudur.
            // using içine yazdığımız nesneler using kullanıldıktan sonra bellekten atılır -> Garbage Collector
            // Context nesnesi belleği yoran bir nesnedir, bu yüzden using kullanırız. using c#'a özeldir.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // product tipindeki context varlığının referansını yakala -> addedEntity'e ver.
                addedEntity.State = EntityState.Added; // addedEntity'nin eklenecek nesne olduğunu set ettik.
                context.SaveChanges(); // State'i gerçekleştir.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); 
                deletedEntity.State = EntityState.Deleted; // addedEntity'nin silinecek nesne olduğunu set ettik.
                context.SaveChanges();
            }
        }

        // Tek data döndürecek ve filtre zorunluluğu var
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // filtreye göre tek bir Product döndürecek.
            }
        }


        // Filtre belirtmediğimizde tüm verileri getirir. Belirttiğimizde ise filtreye göre getirir.
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {

                return filter == null                                               // filtre null ise ? sonrasını çalıştır - null değilse : sonrasını çalıştır.
                    ? context.Set<TEntity>().ToList()                               // context'in Product barındıran prop'una yerleş(products tablosuna) Products tablosunun içindekileri listeye dönüştür. select * from Products gibi
                    : context.Set<TEntity>().Where(filter).ToList();                // Products tablosuna parametreden dönen linq filtresini uygula ve listeye dönüştür. select * from products where = parametredeki değer gibi çalışır.
            }

        }


        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // product tipindeki contextin varlığının referansını yakala -> addedEntity'e ver.
                updatedEntity.State = EntityState.Modified; // addedEntity'nin güncellenecek nesne olduğunu set ettik.
                context.SaveChanges();
            }
        }
    }
}
