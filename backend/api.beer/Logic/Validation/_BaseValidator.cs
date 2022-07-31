using ClassLibrary;
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
            HttpClient _client = new HttpClient();
            //Id is required
            RuleFor(r => r.Id).NotEmpty().WithMessage("Please provide a valid id");

            RuleFor(x => x.Id).MustAsync(async (id, cancellation) =>
            {
                try { await _client.GetAsync(id); } catch { }

                bool exists = false;


                return !exists;

            }).WithMessage("Sorry this id does not exist");
        }
    }
}
