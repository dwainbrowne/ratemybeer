using ClassLibrary;
using ClassLibrary.Application;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Validation
{
    public static class DataValidator
    {
        
        /// <summary>
        /// Evaluate if the requet has a valid id, by calling an external api
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<bool> IsValidId(HttpRequest req)
        {  

            string id = req.Query["id"];

            BaseData baseData = new BaseData();

            baseData.Id = id;

            BaseDataValidator validator = new BaseDataValidator();

            ValidationResult result = await validator.ValidateAsync(baseData);

            if(!result.IsValid)             
            {
                throw new Exception(result.ToString());
            }

            return true;
        }

        /// <summary>
        /// Evaluate if the requet has a valid id, by calling an external api
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<SearchQuery> IsValidQuery(HttpRequest req)
        {

            string keyword = req.Query["q"];

            SearchQuery query = new SearchQuery();

            query.Keyword = keyword;

            SearchValidator validator = new SearchValidator();

            ValidationResult result = validator.Validate(query);

            if (!result.IsValid)
            {
                throw new Exception(result.ToString());
            }

            return query;
        }
    }
}
