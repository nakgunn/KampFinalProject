using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // Generic Constraint - Genericleri kısıtlama
    // class: Referans Tip olmalı
    // IEntity: Sadece IEntity ve IEntity implemente eden nesne olmalı yani Entities'dekiler olabilir.
    // new(): IEntity new'lenemediği için <T> sadece IEntity implemente eden nesneler verilebilir.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // Genel bir entity CRUD operasyonları yapacağız. Entity'e bağımlı olmadan. 
        // Yani ister Category ister Product üzerinde çalış.
        // Expression: Fonksiyonun Parametresine filtre koyabilmeye yarar. Her Filtre için ayrı fonk oluşturmayı engeller.
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // filter=null filtre vermeyebilirsin.  
        T Get(Expression<Func<T, bool>> filter);          // Detaylı Get işlemi için


        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
