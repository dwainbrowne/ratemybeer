using ClassLibrary.Application;
using DataStore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Service
{
    public abstract class AbstractService
    {
        internal IDataStore? _store;

        //Globaly set the query and body so all methods can have access for further processing
        internal IQueryCollection _query;
        internal string _body;

        internal ApplicationResponse _response;

        public AbstractService(IQueryCollection query, string body)
        {
            _query = query;
            _body = body;
            _response = new ApplicationResponse();
        }


    }
}
