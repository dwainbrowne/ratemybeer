using ClassLibrary;
using FluentValidation.Results;
using Logic.Service;
using Logic.Validation;
using Logic.Validator;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using Utilities;

namespace Logic
{
    public class RatingsService : AbstractService, IService
    {
        Ratings? _ratings;

        public RatingsService(IQueryCollection query, string body):base(query, body)
        {

        }


        public async void SetDataProperties()
        {
            _ratings = DataExtractor.Extract<Ratings>(_body);
        }

        public bool IsValid()
        {
            if (_ratings != null)
            {
                RatingsValidator validator = new RatingsValidator();
                ValidationResult result = validator.Validate(_ratings);

                if (!result.IsValid)
                    throw new Exception(result.ToString());
            }
            else
                throw new Exception("No ratings data");

           return true;
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