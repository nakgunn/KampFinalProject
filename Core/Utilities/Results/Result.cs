using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)  // iki parametreyi de gönderirse tek parametreli ctor'u da çalıştır. kod tekrarı yapmamak için.
        {
            Message = message;
        }
 
        public Result(bool success)
        {
            Success = success;
        }



        public bool Success { get; } // constructor dışında set edilemez. sadece okunabilir.

        public string Message { get; }
    }
}
