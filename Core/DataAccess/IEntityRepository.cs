using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


// Entity'ler üzerinde CRUD işlemleri yaparken her entity için tanımladığımız class içinde aynı metodlar bulunur. IProductDal-ICategoryDal gibi
// Aralarındaki tek fark entity'nin türüdür. Bu yüzden entity tipini ver parametreleri ona göre oluşturayım diyoruz.
// Bu metodu implemente ederken bir entity vermeliyiz <T>

public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // Expression: Fonksiyonun Parametresine filtre koyabilmeye yarar.
        // Her Filtre için ayrı fonk oluşturmayı engeller. 
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // filter=null filtre vermeyebilirsin.  
        T Get(Expression<Func<T, bool>> filter);          // Detaylı Get işlemi için

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

