using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarveyNichols.DTO.Common
{
    public class Response<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public static Response<T> GetResponse(T obj, bool success, string message = "", Exception ex = null)
        {
            return new Response<T>
            {
                Result = obj,
                Success = success,
                Message = message,
                Exception = ex
            };
        }
        public static Response<T> GetSuccess(T obj, string message = null)
        {
            return GetResponse(obj, true, message, null);
        }
        public static Response<T> GetError(Exception ex = null, string message = null, T obj = default(T))
        {
            return GetResponse(obj, false, message, ex);
        }
    }
}
