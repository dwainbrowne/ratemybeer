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

            RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
            {

                //Call External API and lookup data
                try
                {
                    List<Beer> beers = await _store.Read<Beer>(DataStoreContainer.beer, where: "?ids=" + id);

                    if (beers.Any())
                        exists = true;
                }
                catch(Exception e) { throw new Exception("Unable to lookup and validate id", e); }

                return exists;

            }).WithMessage("Sorry this id does not exist");
        }
    }
}
