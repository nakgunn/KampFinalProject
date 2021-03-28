using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; // istersem entity Framework istersem inmemory istersem başka bir tekniği kullanacağım.
        public ProductManager(IProductDal productDal) // ProductManager'daki bir metodu kullanmak için hangi veri erişim katmanını kullanacağını söyle.
        {
            _productDal = productDal; // ctor parametresinde söylediğin veri erişim tekniğini kullanacağım.
        }


        public List<Product> GetAll()
        {
            // Koşulları yazarız. en son alttaki şekilde veriyi döndürürüz.
            return _productDal.GetAll(); // söylediğin veri erişim tekniği içerisindeki metodu kullanacağım.
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

      
    }
}
