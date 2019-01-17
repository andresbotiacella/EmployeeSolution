using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeManager.Service;

namespace EmployeeManager.DataAccess
{
    public class MASGlobalModel<T> : IModel<T>
    {
        static string _address = "http://masglobaltestapi.azurewebsites.net/";
        internal readonly HttpClient client;

        public MASGlobalModel()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(_address);
        }

        public virtual Task<IEnumerable<T>> Get()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
