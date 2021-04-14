using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message) // Result içindeki constructor'ı çalıştır. Burdan giden success bilgisi oto olarak true. message burada verilen message parametresi gidecek.
        {

        }

        public SuccessResult() : base(true) // SuccessResult eğer parametre vermeden gönderilirse değeri otomatik true olur.
        {
        }
    }
}
