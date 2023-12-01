using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;

namespace EDCL.WebAPI.Utils.Response
{
    public class BaseResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        
        public T? Data { get; set; }
    }

    public class FormatResponse<T> : BaseResponse<T>
    {
        public T? Data { get; set; }
    }

    public class Response
    {
        public static BaseResponse<IEnumerable<T>> CreateResponse<T>(int status, string message, IEnumerable<T> data)
        {
            return new BaseResponse<IEnumerable<T>>
            {
                Status = status,
                Message = message,
               Data = data
            };
        }

        /*
        public static BaseResponse<IEnumerable<T>> CreateResponse<T>(int status, string message)
        {
            return new BaseResponse<IEnumerable<T>>
            {
                Status = status,
                Message = message,
                Data = null
            };
        }
        */


        public static string SerializeToJson(object data)
        {
            return JsonConvert.SerializeObject(
                data,
                Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            );
        }


    }
}
