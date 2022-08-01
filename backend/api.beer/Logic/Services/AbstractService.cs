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
        //Globaly set the query and body so all methods can have access for further processing
        internal IQueryCollection _query;
        internal string _body;

        public AbstractService(IQueryCollection query, string body)
        {
            _query = query;
            _body = body;
        }


    }
}
