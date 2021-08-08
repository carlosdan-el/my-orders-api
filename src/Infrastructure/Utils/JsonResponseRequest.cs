using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Enums;

namespace Infrastructure.Utils
{
    public static class JsonResponseRequest
    {
        public static JsonResponse Success(object data, int code = 0)
        {
            List<object> list = new List<object>();
            list.Add(data);

            JsonResponse response = new JsonResponse(
                status: ResponseStatusEnum.Sucess.ToString().ToLower(),
                results: list,
                code: code
            );
            
            return response;
        }
    
        public static JsonResponse Failure(string message, int code, string log)
        {
            List<object> list = new List<object>();

            JsonResponse response = new JsonResponse(
                status: ResponseStatusEnum.Failure.ToString().ToLower(),
                message: message,
                code: code,
                results: list,
                log: log
            );

            return response;
        }

        public static JsonResponse Error(string message, int code, string log)
        {
            List<object> list = new List<object>();

            JsonResponse response = new JsonResponse(
                status: ResponseStatusEnum.Error.ToString().ToLower(),
                message: message,
                code: code,
                results: list,
                log: log
            );
            return response;
        }
    
    }
}
