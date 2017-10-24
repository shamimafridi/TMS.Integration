using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Enum;

namespace TMS.Common.ServicePattren
{
    public interface IPostServiceHandler<T> where T : PostResponse
    {
        Task<T> AsyncSetter(string token);
    }
    public abstract class PostServiceHandler<T>: IPostServiceHandler<T> where T : PostResponse
    {
        protected readonly HttpClient _client;

       protected PostServiceHandler()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["CloudApiBaseUrl"])
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InNoYW1pbSIsImlhdCI6MTUwODY3MTA3Nn0.dFJhbvg7HjJWcDDxejU038js5sF_qFClG5iu0c73FHQ");
            _client.DefaultRequestHeaders.Add("subdomain", "azam");

        }
        public abstract Task<T> AsyncSetter(string token);


    }
    public  class PostResponse
    {
        public int NoOfRecordEffected { set; get; }
        public string Status { set; get; }

    }

}
