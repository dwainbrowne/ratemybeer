﻿using ClassLibrary;
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
        
        public static async Task<(bool,string)> IsValidId(HttpRequest req)
        {
            string id = req.Query["id"];

            BaseData baseData = new BaseData();

            baseData.Id = "";//id;

            BaseDataValidator validator = new BaseDataValidator();

           ValidationResult result = await validator.ValidateAsync(baseData);



            return (result.IsValid, result.ToString());
        }
    }
}