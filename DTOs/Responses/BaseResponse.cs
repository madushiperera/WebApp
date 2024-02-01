using System;
using System.Net;
using WebApplication1.DTOs.Requests;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Responses
{
    public class BaseResponse
    {
        public int status_code { get; set; }// to return the status code of the response
        public object data { get; set; } // to return data associated with the response

        ///<summary>
        /// This method can be used to generate the response object from the classes which are inherited from the BaseResponse
        /// </summary>
        /// <param name="statuscode"></param>
        /// <param name="data"></param>
        
        public void CreateResponse(HttpStatusCode statusCode, object data)
        {
            status_code = (int)statusCode;
            this.data = data;
        }
    }

    

}
