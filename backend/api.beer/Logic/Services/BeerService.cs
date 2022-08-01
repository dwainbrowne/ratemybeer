using ClassLibrary;
using Logic.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Logic
{
    public class BeerService : AbstractService, IService
    {
        Beer? _beer;

        public BeerService(IQueryCollection query, string body) : base(query, body)
        {

        }


        public async void SetDataProperties()
        {
            _beer = DataExtractor.Extract<Beer>(_body);
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public bool StoreData()
        {
            throw new NotImplementedException();
        }

        public dynamic GetData()
        {
            throw new NotImplementedException();
        }
    }
}
