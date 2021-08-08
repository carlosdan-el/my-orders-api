using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    sealed public class JsonResponse
    {
        public string status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public DataResponse data { get; set; }
        public string log { get; set; }
        public JsonResponse(string status, List<Object> results, int code, string log = "", string message = "") {

            this.data = new DataResponse();

            this.status = status;
            this.code = code;
            this.message = message;
            this.data.results = results;
            this.log = log;
        }
    }
}