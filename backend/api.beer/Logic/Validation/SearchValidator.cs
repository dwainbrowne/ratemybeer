using ClassLibrary.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Validation
{

    public class SearchValidator : AbstractValidator<SearchQuery>
    {
        public SearchValidator()
        {
            //Rating is required
            RuleFor(r => r.Keyword).NotEmpty().WithMessage("Please provide a search paramater");

        }
    }
}
