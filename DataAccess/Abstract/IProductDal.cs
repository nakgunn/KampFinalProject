using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // Product ile ilgili veritabanında yapacağımız operasyonları içeren interface
    // Interface metotları default olarak publictir. Interface'in kendisi değildir.
    public interface IProductDal : IEntityRepository<Product> // IProductDal'ı implemente eden class'larda Product parametresini otomatik verecek.
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
