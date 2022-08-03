using ClassLibrary;
using DataStore;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Validation
{
   
    public class BaseDataValidator : AbstractValidator<BaseData>
    {
        public BaseDataValidator()
        {           
            IDataStore _store = new APIDataStore();
            bool exists = false;


            RuleFor(r => r.Id).NotEmpty().WithMessage("Please provide a valid id");


            //Validate id by calling an external api
            RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
            {
                try
                {
                    Beer? beer = await _store.Get<Beer>(id,DataStoreContainer.beer);

                    if (beer?.Id == id)
                        exists = true;
                }
                catch(Exception e) { throw new Exception("Unable to lookup and validate id", e); }

                return exists;

            }).WithMessage("Sorry this id does not exist");
        }
    }
}
