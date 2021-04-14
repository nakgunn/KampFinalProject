using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    // Dto - Farklı tablolarda bulunan kolonları tek bir varlık olarak kullanmak istediğimizde oluşturduğumuz class.
    // Tablolar arası ilişkileri DataAccess->Concrete içerisindeki ProductDal class'ında tanımlarız.
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
